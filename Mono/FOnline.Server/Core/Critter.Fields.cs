using System;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public partial class Critter
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetId(IntPtr thisptr);
        public virtual UInt32 Id { get { return GetId (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetCrType(IntPtr thisptr);
        public virtual UInt32 CrType { get { return GetCrType (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexX(IntPtr thisptr);
        public virtual UInt16 HexX { get { return GetHexX (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexY(IntPtr thisptr);
        public virtual UInt16 HexY { get { return GetHexY (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWorldX(IntPtr thisptr);
        public virtual UInt16 WorldX { get { return GetWorldX (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWorldY(IntPtr thisptr);
        public virtual UInt16 WorldY { get { return GetWorldY (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static char GetDir(IntPtr thisptr);
        public virtual Direction Dir { get { return (Direction)GetDir (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static char GetCond(IntPtr thisptr);
        public virtual Cond Cond { get { return (Cond)GetCond (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim1Life(IntPtr thisptr);
        public virtual UInt32 Anim1Life { get { return GetAnim1Life (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim1Knockout(IntPtr thisptr);
        public virtual UInt32 Anim1Knockout { get { return GetAnim1Knockout (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim1Dead(IntPtr thisptr);
        public virtual UInt32 Anim1Dead { get { return GetAnim1Dead (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim2Life(IntPtr thisptr);
        public virtual UInt32 Anim2Life { get { return GetAnim2Life (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim2Knockout(IntPtr thisptr);
        public virtual UInt32 Anim2Knockout { get { return GetAnim2Knockout (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAnim2Dead(IntPtr thisptr);
        public virtual UInt32 Anim2Dead { get { return GetAnim2Dead (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetFlags(IntPtr thisptr);
        public virtual UInt32 Flags { get { return GetFlags (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetShowCritterDist1(IntPtr thisptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetShowCritterDist1(IntPtr thisptr, uint val);
        public virtual UInt32 ShowCritterDist1 { get { return GetShowCritterDist1 (thisptr); } set { SetShowCritterDist1 (thisptr, value); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetShowCritterDist2(IntPtr thisptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetShowCritterDist2(IntPtr thisptr, uint val);
        public virtual UInt32 ShowCritterDist2 { get { return GetShowCritterDist2 (thisptr); } set { SetShowCritterDist2 (thisptr, value); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetShowCritterDist3(IntPtr thisptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetShowCritterDist3(IntPtr thisptr, uint val);
        public virtual UInt32 ShowCritterDist3 { get { return GetShowCritterDist3 (thisptr); } set { SetShowCritterDist3 (thisptr, value); }}

        //public virtual Boolean IsRuning { get { return NativeFields.GetBoolean(thisptr, 16); } set { NativeFields.SetBoolean(thisptr, offsetIsNotValid, value); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetIsNotValid(IntPtr thisptr);
        public virtual Boolean IsNotValid { get { return GetIsNotValid (thisptr); }}
    }
}
