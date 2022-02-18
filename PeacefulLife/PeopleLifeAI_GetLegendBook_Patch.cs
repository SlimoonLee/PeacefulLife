using System;
using System.Collections.Generic;
using HarmonyLib;
namespace PeacefulLife
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(PeopleLifeAI), "GetLegendBook")]
	public static class PeopleLifeAI_GetLegendBook_Patch
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002698 File Offset: 0x00000898
		private static bool Prefix(ref int skillType, ref bool setMassage)
		{
			if (!Main.enabled || (!Main.settings.summer && !Main.settings.harvest))
			{
				return true;
			}
			if (Main.settings.summer)
			{
				return false;
			}
			if (Main.settings.harvest)
			{
				int num = DateFile.instance.MianActorID();
				int mianPartId = DateFile.instance.mianPartId;
				int mianPlaceId = DateFile.instance.mianPlaceId;
				int num2 = new List<int>(DateFile.instance.legendBookId.Keys)[skillType];
				DateFile.instance.GetItem(num, num2, 1, false, -1, 0);
				DateFile.instance.legendBookId[num2] = num;
				PeopleLifeAI.instance.aiTrunEvents.Add(new int[]
				{
					257,
					mianPartId,
					mianPlaceId,
					num,
					num2
				});
				DateFile.instance.SetActorMood(num, 20, 100, false);
				if (setMassage)
				{
					PeopleLifeAI.instance.AISetMassage(131, num, mianPartId, mianPlaceId, new int[]
					{
						num2
					}, -1, true);
				}
			}
			return false;
		}
	}
}
