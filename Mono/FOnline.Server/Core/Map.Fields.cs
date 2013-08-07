using System;
using System.Runtime.CompilerServices;

namespace FOnline.Server
{
    public partial class Map
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetId(IntPtr thisptr);
        public virtual UInt32 Id { get { return GetId (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetIsNotValid(IntPtr thisptr);
        public virtual Boolean IsNotValid { get { return GetIsNotValid (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetTurnBasedRound(IntPtr thisptr);
        public virtual UInt32 TurnBasedRound { get { return GetTurnBasedRound(thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetTurnBasedTurn(IntPtr thisptr);
        public virtual UInt32 TurnBasedTurn { get { return GetTurnBasedTurn(thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetTurnBasedWholeTurn(IntPtr thisptr);
        public virtual UInt32 TurnBasedWholeTurn { get { return GetTurnBasedWholeTurn (thisptr); }}
	}
}
