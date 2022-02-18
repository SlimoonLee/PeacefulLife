using System;
using HarmonyLib;

namespace PeacefulLife
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(UIDate), "ChangeTrun")]
	public static class UIDate_ChangeTrun_Patch
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000023CF File Offset: 0x000005CF
		private static void Prefix()
		{
			if (!Main.enabled || !Main.settings.kira)
			{
				return;
			}
			Kira.Rest();
		}
	}
}
