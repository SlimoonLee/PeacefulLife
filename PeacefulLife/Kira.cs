using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PeacefulLife
{
	// Token: 0x02000004 RID: 4
	public static class Kira
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002315 File Offset: 0x00000515
		public static void Rest()
		{
			Kira.num = 0;
			Kira.money = 0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002324 File Offset: 0x00000524
		public static void gain(int id, int level)
		{
			int num = DateFile.instance.MianActorID();
			int num2 = Math.Min(DateFile.instance.ActorResource(id)[5], level * level * 400);

			UIDate.instance.ChangeTwoActorResource(id, num, 5, num2, false);
			int num3 = 1;
			int num4 = 0;
			if (Random.Range(0, 10) > 4)
			{
				num3++;
			}
			if (Random.Range(0, 7) == 6)
			{
				num4++;
			}
			if (Random.Range(0, 4) == 1)
			{
				num4++;
			}
			Kira.num++;
			Kira.money += num2;
			DateFile.instance.GetItem(num, Mathf.Clamp(21, 16 + level + num4, 29), num3, true, -1, 0);
		}

		// Token: 0x04000009 RID: 9
		public static int num;

		// Token: 0x0400000A RID: 10
		public static int money;
	}
}
