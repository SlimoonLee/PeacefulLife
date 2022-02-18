using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace PeacefulLife
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(WindowManage), "WindowSwitch")]
	public static class WindowManage_WindowSwitch_patch
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000025B4 File Offset: 0x000007B4
		private static void Postfix(WindowManage __instance, bool on, GameObject tips)
		{
			if (!Main.enabled || !Main.settings.kira)
			{
				return;
			}
			if (tips == null || !on)
			{
				return;
			}
			if (tips.tag != "TrunEventIcon")
			{
				return;
			}
			string[] array = tips.name.Split(new char[]
			{
				','
			});
			if (((array.Length > 1) ? array[1].ParseInt() : 0) != 248)
			{
				return;
			}
			string str = string.Concat(new string[]
			{
				"以上入魔者均已被您的替身收服，合计",
				Kira.num.ToString(),
				"人，\n获得金钱：",
				Kira.money.ToString(),
				"。\n"
			});
			Text informationMassage = __instance.informationMassage;
			informationMassage.text += str;
		}
	}
}
