using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = HIW_Tristana.Configuration.ModesMenu.JungleClear;
using SettingsMana = HIW_Tristana.Configuration.ManaManagerMenu;

namespace HIW_Tristana.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
        }
    }
}
