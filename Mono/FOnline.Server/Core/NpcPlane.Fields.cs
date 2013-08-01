using System;
using System.Runtime.CompilerServices;
namespace FOnline
{
    public partial class NpcPlane
    {
        public virtual PlaneType Type
        {
            get { return (PlaneType)GetType_(thisptr); }
            set { SetType(thisptr, (int)value); }
        }
        public virtual UInt32 Priority
        {
            get { return GetPriority(thisptr); }
            set { SetPriority(thisptr, value); }
        }
        public virtual Int32 Identifier
        {
            get { return GetIdentifier(thisptr); }
            set { SetIdentifier(thisptr, value); }
        }
        public virtual UInt32 IdentifierExt
        {
            get { return GetIdentifierExt(thisptr); }
            set { SetIdentifierExt(thisptr, value); }
        }
        public virtual Boolean Run
        {
            get { return GetRun(thisptr); }
            set { SetRun(thisptr, value); }
        }
        public virtual UInt32 Misc_WaitSecond
        {
            get { return GetMisc_WaitSecond(thisptr); }
            set { SetMisc_WaitSecond(thisptr, value); }
        }
        public virtual Int32 Misc_ScriptId
        {
            get { return GetMisc_ScriptId(thisptr); }
            set { SetMisc_ScriptId(thisptr, value); }
        }
        public virtual UInt32 Attack_TargId
        {
            get { return GetAttack_TargId(thisptr); }
            set { SetAttack_TargId(thisptr, value); }
        }
        public virtual Int32 Attack_MinHp
        {
            get { return GetAttack_MinHp(thisptr); }
            set { SetAttack_MinHp(thisptr, value); }
        }
        public virtual Boolean Attack_IsGag
        {
            get { return GetAttack_IsGag(thisptr); }
            set { SetAttack_IsGag(thisptr, value); }
        }
        public virtual UInt16 Attack_GagHexX
        {
            get { return GetAttack_GagHexX(thisptr); }
            set { SetAttack_GagHexX(thisptr, value); }
        }
        public virtual UInt16 Attack_GagHexY
        {
            get { return GetAttack_GagHexY(thisptr); }
            set { SetAttack_GagHexY(thisptr, value); }
        }
        public virtual UInt16 Attack_LastHexX
        {
            get { return GetAttack_LastHexX(thisptr); }
            set { SetAttack_LastHexX(thisptr, value); }
        }
        public virtual UInt16 Attack_LastHexY
        {
            get { return GetAttack_LastHexY(thisptr); }
            set { SetAttack_LastHexY(thisptr, value); }
        }
        public virtual UInt16 Walk_HexX
        {
            get { return GetWalk_HexX(thisptr); }
            set { SetWalk_HexX(thisptr, value); }
        }
        public virtual UInt16 Walk_HexY
        {
            get { return GetWalk_HexY(thisptr); }
            set { SetWalk_HexY(thisptr, value); }
        }
        public virtual Direction Walk_Dir
        {
            get { return (Direction)GetWalk_Dir(thisptr); }
            set { SetWalk_Dir(thisptr, (byte)value); }
        }
        public virtual UInt32 Walk_Cut
        {
            get { return GetWalk_Cut(thisptr); }
            set { SetWalk_Cut(thisptr, value); }
        }
        public virtual UInt16 Pick_HexX
        {
            get { return GetPick_HexX(thisptr); }
            set { SetPick_HexX(thisptr, value); }
        }
        public virtual UInt16 Pick_HexY
        {
            get { return GetPick_HexY(thisptr); }
            set { SetPick_HexY(thisptr, value); }
        }
        public virtual UInt16 Pick_Pid
        {
            get { return GetPick_Pid(thisptr); }
            set { SetPick_Pid(thisptr, value); }
        }
        public virtual UInt32 Pick_UseItemId
        {
            get { return GetPick_UseItemId(thisptr); }
            set { SetPick_UseItemId(thisptr, value); }
        }
        public virtual Boolean Pick_ToOpen
        {
            get { return GetPick_ToOpen(thisptr); }
            set { SetPick_ToOpen(thisptr, value); }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetType_(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetPriority(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetIdentifier(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetIdentifierExt(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetRun(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetMisc_WaitSecond(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetMisc_ScriptId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetAttack_TargId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetAttack_MinHp(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetAttack_IsGag(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAttack_GagHexX(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAttack_GagHexY(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAttack_LastHexX(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAttack_LastHexY(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWalk_HexX(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWalk_HexY(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetWalk_Dir(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetWalk_Cut(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetPick_HexX(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetPick_HexY(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetPick_Pid(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetPick_UseItemId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetPick_ToOpen(IntPtr ptr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetType(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPriority(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetIdentifier(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetIdentifierExt(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRun(IntPtr ptr, bool val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetMisc_WaitSecond(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetMisc_ScriptId(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_TargId(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_MinHp(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_IsGag(IntPtr ptr, bool val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_GagHexX(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_GagHexY(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_LastHexX(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAttack_LastHexY(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWalk_HexX(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWalk_HexY(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWalk_Dir(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWalk_Cut(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPick_HexX(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPick_HexY(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPick_Pid(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPick_UseItemId(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPick_ToOpen(IntPtr ptr, bool val);
	}
}
