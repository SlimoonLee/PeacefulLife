using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace PeacefulLife
{
	// Token: 0x02000003 RID: 3
	public static class Main
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		public static bool Load(UnityModManager.ModEntry modEntry)
		{
			var harmony = new Harmony(modEntry.Info.Id);
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			settings = Settings.Load<Settings>(modEntry);

			Logger = modEntry.Logger;
			modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
			modEntry.OnGUI = new Action<UnityModManager.ModEntry>(Main.OnGUI);
			modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(Main.OnSaveGUI);
			return true;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020E4 File Offset: 0x000002E4
		public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
		{
			if (!value)
			{
				return false;
			}
			Main.enabled = value;
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020F4 File Offset: 0x000002F4
		private static void OnGUI(UnityModManager.ModEntry modEntry)
		{
			//bool flag = DateFile.instance == null || DateFile.instance.actorsDate == null || !DateFile.instance.actorsDate.ContainsKey(DateFile.instance.mianActorId);
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			Main.settings.havensdoor = GUILayout.Toggle(Main.settings.havensdoor, "【天堂之门】每月自动将NPC争夺奇书的念头抹除", new GUILayoutOption[0]);
			Main.settings.harvest = GUILayout.Toggle(Main.settings.harvest, "【钱宝宝】奇书出世时，书主必为太吾（*夺书奇遇除外）", new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			Main.settings.kira = GUILayout.Toggle(Main.settings.kira, "【杀手皇后】每月自动收服相枢化魔NPC（*并得到金钱和血露 *拿不到恩义 *对入魔的太吾无效）", new GUILayoutOption[0]);
			Main.settings.kira2 = GUILayout.Toggle(Main.settings.kira2, "自动处理收服的NPC（*处理=遣返为当前门派底层群众 ）", new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			Main.settings.summer = GUILayout.Toggle(Main.settings.summer, "【太吾的奇妙暑假】奇书不会再出世啦！(*钱宝宝无法获得未出世的奇书)", new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			if (false)//(flag)
			{
				GUILayout.Label("To Be Continue→", new GUILayoutOption[0]);
			}
			else
			{
				GUILayout.Label("【天堂之门】主动发动一次天堂之门", new GUILayoutOption[0]);
				if (GUILayout.Button("Havens'Door！", new GUILayoutOption[]
				{
					GUILayout.Width(180f)
				}))
				{
					UpSky.haven2();
				}
				GUILayout.Label("【空间魔手】随机将一个执迷化魔的NPC拉到太吾身边", new GUILayoutOption[0]);
				if (GUILayout.Button("The Hand!", new GUILayoutOption[]
				{
					GUILayout.Width(180f)
				}))
				{
					UpSky.thehand();
				}
				GUILayout.Label("【修BUG】总之就是修BUG", new GUILayoutOption[0]);
				if (GUILayout.Button("fix the bug!", new GUILayoutOption[]
				{
					GUILayout.Width(180f)
				}))
				{
					UpSky.fix();
				}
			}
			GUILayout.EndVertical();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002308 File Offset: 0x00000508
		private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
		{
			Main.settings.Save(modEntry);
		}

		// Token: 0x04000006 RID: 6
		public static bool enabled;

		// Token: 0x04000007 RID: 7
		public static Settings settings;

		// Token: 0x04000008 RID: 8
		public static UnityModManager.ModEntry.ModLogger Logger;
	}
}
