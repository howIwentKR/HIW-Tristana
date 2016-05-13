using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = HIW_Tristana.Configuration.ModesMenu.Flee;
using SettingsMana = HIW_Tristana.Configuration.ManaManagerMenu;

namespace HIW_Tristana.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (Settings.UseR && R.IsReady() && PlayerMana >= SettingsMana.MinRManaF)
            {
                var target =
                    EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(R.Range))
                        .OrderBy(e => e.Distance(_PlayerPos))
                        .FirstOrDefault();
                if (target != null)
                {
                    if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield))
                    {
                        R.Cast(target);
                        return;
                    }
                }
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= SettingsMana.MinWManaF)
            {
                var cursorPos = Game.CursorPos;
                var castPos = _PlayerPos.Distance(cursorPos) <= W.Range
                    ? cursorPos
                    : _PlayerPos.Extend(cursorPos, W.Range).To3D();
                W.Cast(castPos);
            }
        }
    }
}
