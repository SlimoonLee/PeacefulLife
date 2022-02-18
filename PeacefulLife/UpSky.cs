using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PeacefulLife
{
	// Token: 0x0200000C RID: 12
	public static class UpSky
	{
		
		// Token: 0x06000011 RID: 17 RVA: 0x0000287C File Offset: 0x00000A7C
		public static void fix()
		{
			int num = 0;
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (int num2 in DateFile.instance.gangGroupDate.Keys)
			{
				foreach (int num3 in DateFile.instance.gangGroupDate[num2].Keys)
				{
					foreach (int num4 in DateFile.instance.gangGroupDate[num2][num3].Keys)
					{
						foreach (int num5 in DateFile.instance.gangGroupDate[num2][num3][num4])
						{
							if (Math.Abs(DateFile.instance.GetActorDate(num5, 20, false).ParseInt()) != num4 && !dictionary.ContainsKey(num5))
							{
								dictionary.Add(num5, new List<int>
								{
									num2,
									num3
								});
								num++;
							}
						}
					}
				}
			}
			Main.Logger.Log("find error:" + num.ToString());
			foreach (int num6 in dictionary.Keys)
			{
				foreach (int key in DateFile.instance.gangGroupDate[dictionary[num6][0]][dictionary[num6][1]].Keys)
				{
					if (DateFile.instance.gangGroupDate[dictionary[num6][0]][dictionary[num6][1]][key].Contains(num6))
					{
						DateFile.instance.gangGroupDate[dictionary[num6][0]][dictionary[num6][1]][key].Remove(num6);
					}
				}
			}
			foreach (int num7 in dictionary.Keys)
			{
				//DateFile.instance.actorsDate[num7][20] = "9";
				GameData.Characters.SetCharProperty(num7, 20, "9");
				if (DateFile.instance.gangGroupDate[dictionary[num7][0]][dictionary[num7][1]].ContainsKey(9))
				{
					DateFile.instance.gangGroupDate[dictionary[num7][0]][dictionary[num7][1]][9].Add(num7);
				}
				else
				{
					DateFile.instance.gangGroupDate[dictionary[num7][0]][dictionary[num7][1]].Add(9, new List<int>
					{
						num7
					});
				}
			}
			int num8 = 0;
			int[] allcharIds = GameData.Characters.GetAllCharIds();
			foreach (int num9 in allcharIds)
			{
				if (DateFile.instance.GetActorDate(num9, 26, false) == "0")
				{
					int id = DateFile.instance.GetActorDate(num9, 19, false).ParseInt();
					int key2 = Math.Abs(DateFile.instance.GetActorDate(num9, 20, false).ParseInt());
					int key3 = DateFile.instance.GetGangDate(id, 3).ParseInt();
					int key4 = DateFile.instance.GetGangDate(id, 4).ParseInt();
					if (DateFile.instance.gangGroupDate.ContainsKey(key3) && DateFile.instance.gangGroupDate[key3].ContainsKey(key4))
					{
						if (!DateFile.instance.gangGroupDate[key3][key4].ContainsKey(key2))
						{
							DateFile.instance.gangGroupDate[key3][key4].Add(key2, new List<int>
							{
								num9
							});
							num8++;
						}
						else if (!DateFile.instance.gangGroupDate[key3][key4][key2].Contains(num9))
						{
							DateFile.instance.gangGroupDate[key3][key4][key2].Add(num9);
							num8++;
						}
					}
				}
			}
			Main.Logger.Log("find error2:" + num8.ToString());
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002EC8 File Offset: 0x000010C8
		public static void thehand()
		{
			List<int> list = new List<int>();
			List<int> family = DateFile.instance.GetFamily(true, true);
			int[] allcharIds = GameData.Characters.GetAllCharIds();
			foreach (int num in allcharIds)
			{
				if (DateFile.instance.GetActorDate(num, 26, false) == "0" && !family.Contains(num) && Enumerable.ToList<string>(DateFile.instance.GetActorDate(num, 101, false).Split(new char[]
				{
					'|'
				})).Contains("6002"))
				{
					list.Add(num);
				}
			}
			int actorId = list[Random.Range(0, list.Count)];
			DateFile.instance.MoveToPlace(DateFile.instance.mianPartId, DateFile.instance.mianPlaceId, actorId, true);
			WorldMapSystem.instance.UpdatePlaceActor(WorldMapSystem.instance.choosePartId, WorldMapSystem.instance.choosePlaceId);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002FE0 File Offset: 0x000011E0
		public static void haven2()
		{
			int[] allcharIds = GameData.Characters.GetAllCharIds();
			foreach (int num in allcharIds)
			{
				if (DateFile.instance.GetActorDate(num, 26, false) == "0")
				{
					if (DateFile.instance.HaveLifeDate(num, 709))
					{
						DateFile.instance.actorLife[num].Remove(709);
						int id = DateFile.instance.GetActorDate(num, 19, false).ParseInt();
						int toPartId = DateFile.instance.GetGangDate(id, 3).ParseInt();
						int toPlaceId = DateFile.instance.GetGangDate(id, 4).ParseInt();
						DateFile.instance.MoveToPlace(toPartId, toPlaceId, num, true);
					}
					if (DateFile.instance.HaveLifeDate(num, 710))
					{
						DateFile.instance.actorLife[num].Remove(710);
						int id2 = DateFile.instance.GetActorDate(num, 19, false).ParseInt();
						int toPartId2 = DateFile.instance.GetGangDate(id2, 3).ParseInt();
						int toPlaceId2 = DateFile.instance.GetGangDate(id2, 4).ParseInt();
						DateFile.instance.MoveToPlace(toPartId2, toPlaceId2, num, true);
					}
				}
			}
			WorldMapSystem.instance.UpdatePlaceActor(WorldMapSystem.instance.choosePartId, WorldMapSystem.instance.choosePlaceId);
		}
	}
}
