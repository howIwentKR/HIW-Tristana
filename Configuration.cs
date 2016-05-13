using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HIW_Tristana
{
    class Configuration
    {
        private const string MenuName = "Tristana";
        private static readonly Menu Menu;

        static Configuration()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Tristana coded by howIwentKR");
            ModesMenu.Initialize();
            ManaManagerMenu.Initialize();
        }

        public static void Initialize()
        { }

        public static class ModesMenu
        {
            private static readonly Menu MenuModes;

            static ModesMenu()
            {
                MenuModes = Menu.AddSubMenu("Modes");

                Combo.Initialize();
                MenuModes.AddSeparator();

                Harass.Initialize();
                MenuModes.AddSeparator();

                LaneClear.Initialize();
                MenuModes.AddSeparator();

                JungleClear.Initialize();
                MenuModes.AddSeparator();

                Flee.Initialize();
            }

            public static void Initialize()
            {
            }
            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                static Combo()
                {
                    MenuModes.AddGroupLabel("Combo");
                    _useQ = MenuModes.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = MenuModes.Add("comboUseW", new CheckBox("Use W", false));
                    _useE = MenuModes.Add("comboUseE", new CheckBox("Use E"));
                    _useR = MenuModes.Add("comboUseR", new CheckBox("Use R"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;

                static Harass()
                {
                    MenuModes.AddGroupLabel("Harass");
                    _useQ = MenuModes.Add("harassUseQ", new CheckBox("Use Q"));
                    _useE = MenuModes.Add("harassUseE", new CheckBox("Use E"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minWTargets;
                private static readonly Slider _minETargets;

                static LaneClear()
                {
                    MenuModes.AddGroupLabel("Lane Clear");
                    _useQ = MenuModes.Add("laneUseQ", new CheckBox("Use Q", false));
                    _useE = MenuModes.Add("laneUseE", new CheckBox("Use E", false));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int MinETargets
                {
                    get { return _minETargets.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

                static JungleClear()
                {
                    MenuModes.AddGroupLabel("Jungle Clear");
                    _useQ = MenuModes.Add("jungleUseQ", new CheckBox("Use Q", false));
                    _useE = MenuModes.Add("jungleUseE", new CheckBox("Use E", false));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }


                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;

                static Flee()
                {
                    MenuModes.AddGroupLabel("Flee");
                    _useW = MenuModes.Add("fleeUseW", new CheckBox("Use W"));
                    _useR = MenuModes.Add("fleeUseR", new CheckBox("Use R", false));
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        

        public static class ManaManagerMenu
        {
            private static readonly Menu MenuManaManager;
            private static readonly Slider _minWManaC;
            private static readonly Slider _minEManaC;
            private static readonly Slider _minRManaC;

            private static readonly Slider _minEManaH;

            private static readonly Slider _minWManaLC;
            private static readonly Slider _minEManaLC;

            private static readonly Slider _minWManaJC;
            private static readonly Slider _minEManaJC;

            private static readonly Slider _minWManaF;
            private static readonly Slider _minRManaF;


            static ManaManagerMenu()
            {
                MenuManaManager = Menu.AddSubMenu("Mana Manager");
                MenuManaManager.AddGroupLabel("Combo");

                _minWManaC = MenuManaManager.Add("minWManaC", new Slider("Minimum mana % to use W", 35, 0, 100));
                _minEManaC = MenuManaManager.Add("minEManaC", new Slider("Minimum mana % to use E", 35, 0, 100));
                _minRManaC = MenuManaManager.Add("minRManaC", new Slider("Minimum mana % to use R", 35, 0, 100));

                MenuManaManager.AddGroupLabel("Harass");
                _minEManaH = MenuManaManager.Add("minEManaH", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("Lane Clear");
                _minEManaLC = MenuManaManager.Add("minEManaLC", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("JungleClear");
                _minEManaJC = MenuManaManager.Add("minEManaJC", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("Flee");
                _minWManaF = MenuManaManager.Add("minWManaF", new Slider("Minimum mana % to use W", 0, 0, 100));
                _minRManaF = MenuManaManager.Add("minRManaF", new Slider("Minimum mana % to use R", 0, 0, 100));
            }

            public static int MinWManaC
            {
                get { return _minWManaC.CurrentValue; }
            }

            public static int MinEManaC
            {
                get { return _minEManaC.CurrentValue; }
            }

            public static int MinRManaC
            {
                get { return _minRManaC.CurrentValue; }
            }


            public static int MinEManaH
            {
                get { return _minEManaH.CurrentValue; }
            }


            public static int MinEManaLC
            {
                get { return _minEManaLC.CurrentValue; }
            }


            public static int MinEManaJC
            {
                get { return _minEManaJC.CurrentValue; }
            }

            public static int MinWManaF
            {
                get { return _minWManaF.CurrentValue; }
            }

            public static int MinRManaF
            {
                get { return _minRManaF.CurrentValue; }
            }

            public static void Initialize()
            {
            }
        }

        }
}
