using HIW_Tristana;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Constants;
using SharpDX;
using SharpDX.Direct3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIW_Tristana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Tristana")
                return;

            Configuration.Initialize();
            Events.Initialize();
            ModeManager.Initialize();
            SpellManager.Initialize();

            Chat.Print("HIW Tristana loaded.");
            Chat.Print("Coded by howIwentKR to EloBuddy. Enjoy.");
        }
    }
}
