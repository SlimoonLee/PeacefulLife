using System;
using HarmonyLib;
using UnityEngine;

namespace PeacefulLife
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(PeopleLifeAI), "DoTrunAIChange")]
	[HarmonyPriority(0)]
	public static class PeopleLifeAI_KIRADoTrunAIChange_Patch
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002498 File Offset: 0x00000698
		private static void Postfix(ref int actorId, ref int mapId)
		{
			if (!Main.enabled || !Main.settings.kira)
			{
				return;
			}
			if (DateFile.instance.GetActorDate(actorId, 6, false) != "1")
			{
				return;
			}
			int gangId = int.Parse(DateFile.instance.GetActorDate(actorId, 19, false));
			int num = int.Parse(DateFile.instance.GetActorDate(actorId, 20, false));
			if (DateFile.instance.GetGangValueId(gangId, num) != 99)
			{
				if (!DateFile.instance.xxPartIds.Contains(mapId))
				{
					DateFile.instance.xxPartIds.Add(mapId);
				}
				int level = 10 - Mathf.Abs(num);
				Kira.gain(actorId, level);
				if (!Main.settings.kira2)
				{
					int[] item = new int[]
					{
						0,
						actorId,
						252,
						actorId
					};
					DateFile.instance.eventId.Add(item);
					return;
				}
				DateFile.instance.SetActorXXChange(actorId, -200, false, false);
				DateFile.instance.RemoveGangActor(gangId, Mathf.Abs(num), actorId);
				DateFile.instance.AddGangDate(gangId, 9, actorId, true);
			}
		}
	}
}
