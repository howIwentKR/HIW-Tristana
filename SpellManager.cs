using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIW_Tristana
{
    class SpellManager
    {
        static SpellManager()
        {
            Q = new Spell.Active(SpellSlot.Q, 0);
            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular, 500, int.MaxValue, 250);
            W.AllowedCollisionCount = int.MaxValue;
            E = new Spell.Targeted(SpellSlot.E, 550);
            R = new Spell.Targeted(SpellSlot.R, 550);

            Recall = new Spell.Active(SpellSlot.Recall);
        }

        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Targeted R { get; private set; }
        public static Spell.Active Recall { get; private set; }

        private static AIHeroClient _Player
        {
            get { return Player.Instance; }
        }

        public static void Initialize()
        {
        }

        public static float ERRange()
        {
            return 550.0f + 7.0f * (_Player.Level - 1);
        }
    }
}
