using System;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public partial class Item
    {
        public virtual UInt32 Id { get { return GetId(thisptr); }}
        public virtual ProtoItem Proto { get { return (ProtoItem)GetProto(thisptr); }}
        public virtual Accessory Accessory { get { return (Accessory)GetAccessory(thisptr); }}
        public virtual UInt32 MapId { get { return GetMapId(thisptr); }}
        public virtual UInt16 HexX { get { return GetHexX(thisptr); }}
        public virtual UInt16 HexY { get { return GetHexY(thisptr); }}
        public virtual UInt32 CritId { get { return GetCritId(thisptr); }}
        public virtual Byte CritSlot { get { return GetCritSlot(thisptr); }}
        public virtual UInt32 ContainerId { get { return GetContainerId(thisptr); }}
        public virtual UInt32 StackId { get { return GetStackId(thisptr); }}
        public virtual Boolean IsNotValid { get { return GetIsNotValid(thisptr); }}
        public virtual Byte Mode { get { return GetMode(thisptr); }}
        public virtual UInt16 SortValue { get { return GetSortValue(thisptr); } set { SetSortValue(thisptr, value); }}
        public virtual Byte Info { get { return GetInfo(thisptr); } set { SetInfo(thisptr, value); }}
        public virtual UInt32 PicMap { get { return GetPicMap(thisptr); } set { SetPicMap(thisptr, value); }}
        public virtual UInt32 PicInv { get { return GetPicInv(thisptr); } set { SetPicInv(thisptr, value); }}
        public virtual UInt16 AnimWaitBase { get { return GetAnimWaitBase(thisptr); } set { SetAnimWaitBase(thisptr, value); }}
        public virtual Byte AnimStayBegin { get { return GetAnimStayBegin(thisptr); } set { SetAnimStayBegin(thisptr, value); }}
        public virtual Byte AnimStayEnd { get { return GetAnimStayEnd(thisptr); } set { SetAnimStayEnd(thisptr, value); }}
        public virtual Byte AnimShowBegin { get { return GetAnimShowBegin(thisptr); } set { SetAnimShowBegin(thisptr, value); }}
        public virtual Byte AnimShowEnd { get { return GetAnimShowEnd(thisptr); } set { SetAnimShowEnd(thisptr, value); }}
        public virtual Byte AnimHideBegin { get { return GetAnimHideBegin(thisptr); } set { SetAnimHideBegin(thisptr, value); }}
        public virtual Byte AnimHideEnd { get { return GetAnimHideEnd(thisptr); } set { SetAnimHideEnd(thisptr, value); }}
        public virtual UInt32 Cost { get { return _GetCost(thisptr); } set { SetCost(thisptr, value); }}
        public virtual Int32 Val0 { get { return GetVal0(thisptr); } set { SetVal0(thisptr, value); }}
        public virtual Int32 Val1 { get { return GetVal1(thisptr); } set { SetVal1(thisptr, value); }}
        public virtual Int32 Val2 { get { return GetVal2(thisptr); } set { SetVal2(thisptr, value); }}
        public virtual Int32 Val3 { get { return GetVal3(thisptr); } set { SetVal3(thisptr, value); }}
        public virtual Int32 Val4 { get { return GetVal4(thisptr); } set { SetVal4(thisptr, value); }}
        public virtual Int32 Val5 { get { return GetVal5(thisptr); } set { SetVal5(thisptr, value); }}
        public virtual Int32 Val6 { get { return GetVal6(thisptr); } set { SetVal6(thisptr, value); }}
        public virtual Int32 Val7 { get { return GetVal7(thisptr); } set { SetVal7(thisptr, value); }}
        public virtual Int32 Val8 { get { return GetVal8(thisptr); } set { SetVal8(thisptr, value); }}
        public virtual Int32 Val9 { get { return GetVal9(thisptr); } set { SetVal9(thisptr, value); }}
        public virtual SByte LightIntensity { get { return GetLightIntensity(thisptr); } set { SetLightIntensity(thisptr, value); }}
        public virtual Byte LightDistance { get { return GetLightDistance(thisptr); } set { SetLightDistance(thisptr, value); }}
        public virtual Byte LightFlags { get { return GetLightFlags(thisptr); } set { SetLightFlags(thisptr, value); }}
        public virtual UInt32 LightColor { get { return GetLightColor(thisptr); } set { SetLightColor(thisptr, value); }}
        public virtual Byte Indicator { get { return GetIndicator(thisptr); } set { SetIndicator(thisptr, value); }}
        public virtual BI BrokenFlags { get { return (BI)GetBrokenFlags(thisptr); } set { SetBrokenFlags(thisptr, (Byte)value); }}
        public virtual Byte BrokenCount { get { return GetBrokenCount(thisptr); } set { SetBrokenCount(thisptr, value); }}
        public virtual UInt16 Deterioration { get { return GetDeterioration(thisptr); } set { SetDeterioration(thisptr, value); }}
        public virtual UInt16 AmmoPid { get { return GetAmmoPid(thisptr); } set { SetAmmoPid(thisptr, value); }}
        public virtual UInt16 AmmoCount { get { return GetAmmoCount(thisptr); } set { SetAmmoCount(thisptr, value); }}
        public virtual UInt32 LockerId { get { return GetLockerId(thisptr); } set { SetLockerId(thisptr, value); }}
        public virtual UInt16 LockerCondition { get { return GetLockerCondition(thisptr); } set { SetLockerCondition(thisptr, value); }}
        public virtual UInt16 LockerComplexity { get { return GetLockerComplexity(thisptr); } set { SetLockerComplexity(thisptr, value); }}
        public virtual UInt16 RadioChannel { get { return GetRadioChannel(thisptr); } set { SetRadioChannel(thisptr, value); }}
        public virtual UInt16 RadioFlags { get { return GetRadioFlags(thisptr); } set { SetRadioFlags(thisptr, value); }}
        public virtual Byte RadioBroadcastSend { get { return GetRadioBroadcastSend(thisptr); } set { SetRadioBroadcastSend(thisptr, value); }}
        public virtual Byte RadioBroadcastRecv { get { return GetRadioBroadcastRecv(thisptr); } set { SetRadioBroadcastRecv(thisptr, value); }}
        public virtual UInt32 HolodiskNumber { get { return GetHolodiskNumber(thisptr); } set { SetHolodiskNumber(thisptr, value); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr GetProto(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAccessory(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetMapId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexX(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexY(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetCritId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetCritSlot(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetContainerId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetStackId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static Boolean GetIsNotValid(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetMode(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetSortValue(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetSortValue(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetInfo(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetInfo(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetPicMap(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPicMap(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetPicInv(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetPicInv(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAnimWaitBase(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimWaitBase(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimStayBegin(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimStayBegin(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimStayEnd(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimStayEnd(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimShowBegin(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimShowBegin(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimShowEnd(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimShowEnd(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimHideBegin(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimHideBegin(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetAnimHideEnd(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAnimHideEnd(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint _GetCost(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetCost(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal0(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal0(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal1(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal1(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal2(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal2(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal3(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal3(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal4(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal4(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal5(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal5(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal6(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal6(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal7(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal7(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal8(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal8(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetVal9(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVal9(IntPtr ptr, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static sbyte GetLightIntensity(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLightIntensity(IntPtr ptr, sbyte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetLightDistance(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLightDistance(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetLightFlags(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLightFlags(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetLightColor(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLightColor(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetIndicator(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetIndicator(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetBrokenFlags(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetBrokenFlags(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetBrokenCount(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetBrokenCount(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetDeterioration(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetDeterioration(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAmmoPid(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAmmoPid(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetAmmoCount(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAmmoCount(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetLockerId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLockerId(IntPtr ptr, uint val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetLockerCondition(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLockerCondition(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetLockerComplexity(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetLockerComplexity(IntPtr ptr, ushort val);
        //ushort GetCarFuel(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetCarFuel(IntPtr ptr, ushort val);
        //ushort GetCarDeterioration(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetCarDeterioration(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetRadioChannel(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRadioChannel(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetRadioFlags(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRadioFlags(IntPtr ptr, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetRadioBroadcastSend(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRadioBroadcastSend(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetRadioBroadcastRecv(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRadioBroadcastRecv(IntPtr ptr, byte val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetHolodiskNumber(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetHolodiskNumber(IntPtr ptr, uint val);
	}
}
