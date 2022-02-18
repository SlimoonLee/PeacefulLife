using System;
using HarmonyLib;
using UnityEngine;

namespace PeacefulLife
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(MessageEventManager), "EndEvent253_2")]
	public static class MassageWindow_EndEvent253_2_Patch
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000023EC File Offset: 0x000005EC
		private static bool Prefix(MessageEventManager __instance)
		{
			if (!Main.settings.kira || !Main.enabled)
			{
				return true;
			}
			int actorId = __instance.MainEventData[1];
			int gangId = DateFile.instance.GetActorDate(actorId, 19, false).ParseInt();
			DateFile.instance.RemoveGangActor(gangId, Mathf.Abs(DateFile.instance.GetActorDate(actorId, 20, false).ParseInt()), actorId);
			DateFile.instance.AddGangDate(gangId, 9, actorId, true);
			UIDate.instance.UpdateManpower();
			WorldMapSystem.instance.UpdatePlaceActor(WorldMapSystem.instance.choosePartId, WorldMapSystem.instance.choosePlaceId);
			return false;
		}
	}
}
