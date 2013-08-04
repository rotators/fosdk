using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FOnline
{
	public interface IMisc
	{
        string GetPlayerName(uint id);
        void SetBestScore(int score, Critter cl, string name);
		void RadioMessage(ushort channel, string text);
		void RadioMessageMsg(ushort channel, ushort textMsg, uint strNum);
		void RadioMessageMsg(ushort channel, ushort textMsg, uint strNum, string lexems);
        uint GetBagItems(uint bag_id, IList<ushort> pids, IList<uint> min_counts, IList<uint> max_counts, IList<ItemSlot> slots);
        uint GetScriptId(string script_name, string func_decl);
        string GetScriptName(uint script_id);
    }
	public class Misc : IMisc
	{
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static string Global_GetPlayerName(uint id);
        public string GetPlayerName(uint id)
        {
            return Global_GetPlayerName(id);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_SetBestScore(int score, IntPtr cl, string name);
        public void SetBestScore(int score, Critter cl, string name)
        {
            Global_SetBestScore(score, cl.ThisPtr, name);
        }
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern static void Global_RadioMessage(ushort channel, string text);
		public void RadioMessage(ushort channel, string text)
		{
            if (text == null)
                throw new ArgumentNullException ("text");
			Global_RadioMessage(channel, text);
		}
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern static void Global_RadioMessageMsg(ushort channel, ushort text_msg, uint str_num);
		public void RadioMessageMsg(ushort channel, ushort text_msg, uint str_num)
		{
			Global_RadioMessageMsg(channel, text_msg, str_num);
		}
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern static void Global_RadioMessageMsgLex(ushort channel, ushort text_msg, uint str_num, string lexems);
		public void RadioMessageMsg(ushort channel, ushort text_msg, uint str_num, string lexems)
		{
			Global_RadioMessageMsgLex(channel, text_msg, str_num, lexems);
		}
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetBagItems(uint bag_id, IList<ushort> pids, IList<uint> min_counts, IList<uint> max_counts, IList<ItemSlot> slots);
        public uint GetBagItems(uint bag_id, IList<ushort> pids, IList<uint> min_counts, IList<uint> max_counts, IList<ItemSlot> slots)
        {
            return Global_GetBagItems(bag_id, pids, min_counts, max_counts, slots);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetScriptId(string script_name, string func_decl);
        public uint GetScriptId(string script_name, string func_decl)
        {
            return Global_GetScriptId(script_name, func_decl);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static string Global_GetScriptName(uint script_id);
        public string GetScriptName(uint script_id)
        {
            return Global_GetScriptName(script_id);
        }
    }
}
