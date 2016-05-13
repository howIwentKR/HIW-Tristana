using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace HIW_Tristana.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Active Q
        {
            get { return SpellManager.Q; }
        }

        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }

        protected Spell.Targeted E
        {
            get { return SpellManager.E; }
        }

        protected Spell.Targeted R
        {
            get { return SpellManager.R; }
        }

        protected float PlayerHealth
        {
            get { return Player.Instance.HealthPercent; }
        }

        protected float PlayerMana
        {
            get { return Player.Instance.ManaPercent; }
        }

        protected float PlayerManaExact
        {
            get { return Player.Instance.Mana; }
        }

        protected AIHeroClient _Player
        {
            get { return Player.Instance; }
        }

        protected Vector3 _PlayerPos
        {
            get { return Player.Instance.Position; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}