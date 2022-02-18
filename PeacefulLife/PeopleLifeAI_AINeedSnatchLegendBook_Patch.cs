using System;
using HarmonyLib;
namespace PeacefulLife
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(PeopleLifeAI), "AINeedSnatchLegendBook")]
	public static class PeopleLifeAI_AINeedSnatchLegendBook_Patch
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000267F File Offset: 0x0000087F
		private static bool Prefix()
		{
			return !Main.enabled || !Main.settings.havensdoor;
		}
	}
}
