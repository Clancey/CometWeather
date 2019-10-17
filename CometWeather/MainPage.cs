using System;
using Comet;
using CometWeather.Views;

namespace CometWeather
{
    public class MainPage : View
    {
        readonly State<WeatherItem> WeatherItem = new State<WeatherItem>();
        WeatherService service;
        public MainPage()
        {
            service = new WeatherService(WeatherItem);
        }
        [Body]
        View body() => new ZStack{
            
            new GradientView(()=> GetColor(true), ()=> GetColor(false)),
            new VStack
            {
                new Text("Delhi"),
                new Image("spaceneedle.png").Frame(alignment: Alignment.Center),
                new Text(() => $"{(int)WeatherItem.Value?.Temp}")
                    .FontSize(60),
                
            }
        };

        Color GetColor(bool isStart)
        {
            var temp = WeatherItem.Value?.Temp ?? -100;
            if (temp > 60)
                return isStart ? AppStyle.WarmStartColor : AppStyle.WarmEndColor;

            if (temp == -100)
                return isStart ? AppStyle.NightStartColor : AppStyle.NightEndColor;

            return isStart ? AppStyle.ColdStartColor : AppStyle.ColdEndColor;
        }
        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            service = null;
            base.Dispose(disposing);
        }
        public override void ViewPropertyChanged(string property, object value)
        {
            base.ViewPropertyChanged(property, value);
        }
    }
}
