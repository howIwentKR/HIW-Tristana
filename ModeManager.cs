using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using HIW_Tristana.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIW_Tristana
{
    public static class ModeManager
    {
        static ModeManager()
        {
            Modes = new List<ModeBase>();


            Modes.AddRange(new ModeBase[]
            {
                new Combo(),
                new Harass(),
                new LaneClear(),
                new JungleClear(),
                new LastHit(),
                new Flee()
            });

            Game.OnTick += OnTick;
        }

        private static List<ModeBase> Modes { get; }

        public static void Initialize()
        {
        }

        private static void OnTick(EventArgs args)
        {
            Modes.ForEach(mode =>
            {
                try
                {
                    if (mode.ShouldBeExecuted())
                    {
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(LogLevel.Error, "Error trying to execute mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}
