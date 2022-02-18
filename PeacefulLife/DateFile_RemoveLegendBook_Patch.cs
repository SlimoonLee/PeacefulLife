using System;
using System.Collections.Generic;
using HarmonyLib;

namespace PeacefulLife
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(DateFile), "RemoveLegendBook")]
	public static class DateFile_RemoveLegendBook_Patch
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000027A4 File Offset: 0x000009A4
		private static bool Prefix(ref int actorId, ref int partId, ref int placeId)
		{
			if (!Main.enabled || !Main.settings.summer)
			{
				return true;
			}
			new List<int>(DateFile.instance.legendBookId.Keys);
			foreach (int num in DateFile.instance.legendBookId.Keys)
			{
				if (DateFile.instance.legendBookId[num] == actorId)
				{
					DateFile.instance.legendBookId[num] = 0;
					DateFile.instance.LoseItem(actorId, num, 1, false, true);
				}
				PeopleLifeAI.instance.AISetMassage(159, actorId, partId, placeId, new int[]
				{
					num
				}, -1, true);
			}
			return false;
		}
	}
}
