using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Collections;

namespace FOnline
{
    /// <summary>
    /// Wrapper for native CScriptArray class.
    /// </summary>
    public class ScriptArray
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void AddRef(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void Release(IntPtr ptr); // this needs to be thread safe
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern internal static int ScriptArray_GetRefCount(IntPtr thisptr);
		[MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void ReleaseRefs(IntPtr ptr); // this needs to be thread safe
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static IntPtr Create(IntPtr type);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static IntPtr CreateSize(uint length, IntPtr type);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public static IntPtr GetType(string type);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static IntPtr At(IntPtr ptr, uint index);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static uint Length(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void Resize(IntPtr ptr, uint length);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void InsertAt(IntPtr thisptr, uint index, IntPtr value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern internal static void RemoveAt(IntPtr thisptr, uint index);
    }    
    /// <summary>
    /// Base class for arrays that keeps handles to the objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class HandleArray<T> : ScriptArray<T> where T: IManagedWrapper
    {
        public HandleArray(IntPtr type)
            : base(type)
        {

        }
        public HandleArray(IntPtr ptr, bool wrap)
            : base(ptr, wrap)
        {
        }
        protected IntPtr GetObjectAddress(IntPtr handle_ptr)
        {
            unsafe
            {
                return *(IntPtr*)handle_ptr;
            }
        }
        public override void ToNative(IntPtr ptr, T value)
        {
            unsafe
            {
                *(IntPtr*)ptr = value != null ? value.ThisPtr : IntPtr.Zero;
            }
        }
		public override T this[uint index]
        {
            get
            {
                return FromNative(ScriptArray.At(thisptr, index));
            }
            set
            {
				var ptr = ScriptArray.At (thisptr, index);
				var obj = FromNative(ptr);
				if(obj != null)
					obj.Release();
				if(value != null)
					value.AddRef();
                ToNative(ptr, value);
            }
        }
    }
	
    public abstract class ScriptArray<T> : IEnumerable<T>, IList<T>
    {
        protected readonly IntPtr thisptr;
        /// <summary>
        /// Instantiates wrapper given the native pointer.
        /// </summary>
        /// <param name="ptr"></param>
        protected ScriptArray(IntPtr ptr, bool wrap)
        {
            thisptr = ptr;
            ScriptArray.AddRef(thisptr);
        }
        protected ScriptArray(IntPtr type)
        {
            thisptr = ScriptArray.Create(type);
        }
        protected ScriptArray(IList<T> list, IntPtr type)
        {
            thisptr = ScriptArray.CreateSize((uint)list.Count, type);
            for (uint i = 0; i < list.Count; i++)
                this[i] = list[(int)i];
        }
        protected ScriptArray(uint size, IntPtr type)
        {
            thisptr = ScriptArray.CreateSize(size, type);
        }
        ~ScriptArray()
        {
            ScriptArray.Release(thisptr); 
        }
        public IntPtr ThisPtr { get { return thisptr; } }
		public int RefCount
		{
			get { return ScriptArray.ScriptArray_GetRefCount(thisptr); }
		}
        public static explicit operator IntPtr(ScriptArray<T> self)
        {
            return self != null ? self.ThisPtr : IntPtr.Zero;
        }
        public uint Length
        {
            get
            {
                return ScriptArray.Length(thisptr);
            }
        }
        public virtual T this[uint index]
        {
            get
            {
                if(!CheckRange((int)index))
                    throw new ArgumentOutOfRangeException("index");
                return FromNative(ScriptArray.At(thisptr, index));
            }
            set
            {
                if(IsReadOnly)
                    throw new NotSupportedException("Array is read only");
                var ptr = ScriptArray.At(thisptr, index);
                ToNative(ptr, value);
            }
        }
        public void Resize(uint length)
        {
            ScriptArray.Resize(thisptr, length);
        }
        public void Add(T elem)
        {
            uint index = Length;
            Resize(Length + 1);
            this[index] = elem;
        }
        public void AddRange(IEnumerable<T> elems)
        {
            uint index = Length;
            var arr = elems.ToArray();
            Resize(Length + (uint)arr.Length);
            for (uint i = index; i < Length; i++)
                this[i] = arr[i - index];
        }
        public abstract void ToNative(IntPtr ptr, T value);
        public abstract T FromNative(IntPtr ptr);
        
        public class Enumerator : IDisposable, IEnumerator<T>
        {
            int current = -1;
            readonly ScriptArray<T> array;
            public Enumerator(ScriptArray<T> array)
            {
                this.array = array;
                ScriptArray.AddRef(array.ThisPtr);
            }
            public void Dispose()
            {
                ScriptArray.Release(array.ThisPtr);
            }
            public T Current
            {
                get 
                {
                    IntPtr el = ScriptArray.At(array.ThisPtr, (uint)current);
                    return array.FromNative(el);
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (++current < ScriptArray.Length(array.ThisPtr))
                    return true;
                
                return false;
            }

            public void Reset()
            {
                current = -1;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region IList
        public int IndexOf(T item)
        {
            for(int i = 0; i < this.Length; i++)
            {
                if(EqualityComparer<T>.Default.Equals(this[i], item))
                    return i;
            }
            return -1;
        }
        bool CheckRange(int index)
        {
            return index >= 0 && index < Length;
        }
        public void Insert(int index, T item)
        {
            uint len = this.Length;
            if(index < 0 || index > len)
                throw new ArgumentOutOfRangeException("index");
            if(IsReadOnly)
                throw new NotSupportedException("Array read-only");
            // we cannot obtain needed ptr in generic way, so we just insert 'manually'
            //ScriptArray.InsertAt(thisptr, (uint)index, ptr);
            ScriptArray.Resize(thisptr, len + 1);
            for (uint i = len; i > (int)index; i--)
                this[i] = this[i-1];
            this[index] = item;
        }

        public void RemoveAt(int index)
        {
            if(!CheckRange(index))
                throw new ArgumentOutOfRangeException("index");
            if(IsReadOnly)
                throw new NotSupportedException("Array is read-only");
            ScriptArray.RemoveAt(thisptr, (uint)index);
        }

        public T this[int index]
        {
            get
            {
                return this[(uint)index];
            }
            set
            {
                this[(uint)index] = value;
            }
        }


        public void Clear()
        {
            ScriptArray.Resize(thisptr, 0);
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < this.Length; i++) 
            {
                if(EqualityComparer<T>.Default.Equals(this[i], item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null) throw new ArgumentNullException("array");
            if(arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex");
            if(array.Length - arrayIndex < this.Length)
                throw new ArgumentException("The number of elements in the source ICollection<T> is greater than the available space from arrayIndex to the end of the destination array");
            for(int i = arrayIndex; i < array.Length; i++) 
                array[i] = this[i - arrayIndex];
        }

        public int Count
        {
            get { return (int)Length;  }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            var idx = IndexOf(item);
            if (idx != -1)
            {
                RemoveAt(idx);
                return true;
            }
            return false;
        }
        #endregion
    }
}
