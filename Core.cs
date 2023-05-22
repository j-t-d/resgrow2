using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace resregrow2
{
    class resregrow2CoreSystem : ModSystem
    {

        public override void StartServerSide(ICoreServerAPI api)
        {
            var harmony = new Harmony(Mod.Info.ModID);
            harmony.PatchAll();
            base.StartServerSide(api);
        }

        public override bool ShouldLoad(EnumAppSide forSide)  {
            return forSide == EnumAppSide.Server;
        }
    }
}
