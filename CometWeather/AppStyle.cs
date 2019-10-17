using System;
using System.Runtime.CompilerServices;
using Comet;

namespace CometWeather
{
    public static class AppStyle
    {
        static AppStyle()
        {
            ColdStartColor = new Color("#BDE3FA");
            ColdEndColor = new Color("#A5C9FD");
            WarmStartColor = new Color("#F6CC66");
            WarmEndColor = new Color("#FCA184");
            NightStartColor = new Color("#172941");
            NightEndColor = new Color("#3C6683");
            MainTextColor = Color.White;
            View.SetGlobalEnvironment(EnvironmentKeys.Colors.Color, Color.White);
        }

        public static Color ColdStartColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color ColdEndColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color WarmStartColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color WarmEndColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color NightStartColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color NightEndColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        public static Color MainTextColor
        {
            get => GetColorFromEnvironment();
            set => SetColorFromEnvironment(value);
        }

        static Color GetColorFromEnvironment([CallerMemberName] string propertyName = "")
            => View.GetGlobalEnvironment<Color>(propertyName);

        static void SetColorFromEnvironment(Color color, [CallerMemberName] string propertyName = "")
            => View.SetGlobalEnvironment(propertyName, color);
    }
}
