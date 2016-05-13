using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SettingsMana = HIW_Tristana.Configuration.ManaManagerMenu;
using SettingsModes = HIW_Tristana.Configuration.ModesMenu;

namespace HIW_Tristana
{
    public static class Events
    {
        static Events()
        {
            Orbwalker.OnPreAttack += OrbwalkerOnPreAttack;
            Orbwalker.OnAttack += OrbwalkerOnAttack;
        }

        private static float PlayerMana
        {
            get { return Player.Instance.ManaPercent; }
        }

        private static void OrbwalkerOnAttack(AttackableUnit target, EventArgs args)
        {
            if (!SpellManager.Q.IsReady())
            {
                return;
            }
            if ((SettingsModes.Combo.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) ||
                (SettingsModes.Harass.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass)) ||
                (SettingsModes.LaneClear.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear)) ||
                (SettingsModes.JungleClear.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear)))
            {
                if (target is AIHeroClient)
                {
                    SpellManager.Q.Cast();
                    return;
                }
            }


            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) ||
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                if (target is Obj_AI_Minion)
                {
                    if (SettingsModes.JungleClear.UseQ && target.Team == GameObjectTeam.Neutral)
                    {
                        SpellManager.Q.Cast();
                    }
                    else if (SettingsModes.LaneClear.UseQ && target.IsEnemy)
                    {
                        SpellManager.Q.Cast();
                    }
                }
            }
        }

        private static void OrbwalkerOnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!SpellManager.E.IsReady())
            {
                return;
            }
            if ((SettingsModes.Combo.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) &&
                 PlayerMana >= SettingsMana.MinEManaC) ||
                (SettingsModes.Harass.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) &&
                 PlayerMana >= SettingsMana.MinEManaH) ||
                (SettingsModes.LaneClear.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                 PlayerMana >= SettingsMana.MinEManaLC) ||
                (SettingsModes.JungleClear.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) &&
                 PlayerMana >= SettingsMana.MinEManaJC))
            {
                if (target is AIHeroClient)
                {
                    SpellManager.E.Cast((Obj_AI_Base)target);
                    return;
                }
            }


            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) ||
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                if (target is Obj_AI_Minion)
                {
                    if (SettingsModes.LaneClear.UseE && target.IsEnemy && PlayerMana >= SettingsMana.MinEManaLC)
                    {
                        var ETargets =
                            EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                                target.Position, 250.0f).Count();
                        if (ETargets >= SettingsModes.LaneClear.MinETargets)
                        {
                            SpellManager.E.Cast((Obj_AI_Base)target);
                        }
                    }
                    if (SettingsModes.JungleClear.UseE && target.Team == GameObjectTeam.Neutral &&
                        PlayerMana >= SettingsMana.MinEManaJC)
                    {
                        SpellManager.E.Cast((Obj_AI_Base)target);
                    }
                }
            }
        }

        public static void Initialize()
        {
        }

        private static bool HasEBuff(this Obj_AI_Base target)
        {
            return target.HasBuff("TristanaECharge");
        }
    }
}