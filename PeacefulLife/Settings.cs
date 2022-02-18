using System;
using UnityModManagerNet;

namespace PeacefulLife
{
	// Token: 0x02000002 RID: 2
	public class Settings : UnityModManager.ModSettings
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public override void Save(UnityModManager.ModEntry modEntry)
		{
			UnityModManager.ModSettings.Save<Settings>(this, modEntry);
		}

		// Token: 0x04000001 RID: 1
		public bool havensdoor = true;

		// Token: 0x04000002 RID: 2
		public bool kira = true;

		// Token: 0x04000003 RID: 3
		public bool kira2;

		// Token: 0x04000004 RID: 4
		public bool harvest;

		// Token: 0x04000005 RID: 5
		public bool summer;
	}
}
