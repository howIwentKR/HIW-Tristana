using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsMana = HIW_Tristana.Configuration.ManaManagerMenu;
using Settings = HIW_Tristana.Configuration.ModesMenu.Combo;

namespace HIW_Tristana.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseR && R.IsReady() && PlayerMana >= SettingsMana.MinRManaC)
            {
                var target = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (target != null)
                {
                    if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield))
                    {
                        var targetHealth = target.TotalShieldHealth();
                        if (target.HasBuff("TristanaEChargeSound"))
                        {
                            targetHealth -= Damage.EDamage(target);
                        }
                        if (targetHealth < Damage.RDamage(target))
                        {
                            R.Cast(target);
                            return;
                        }
                    }
                }

            }
        }
    }

}