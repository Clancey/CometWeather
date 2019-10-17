using System;
using Comet;

namespace CometWeather
{
    public class WeatherItem : BindingObject
    {
        public double Pressure {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double Temp
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double MinTemp
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double MaxTemp
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double WindSpeed
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double Humidity
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }

        public double Uv
        {
            get => this.GetProperty<double>();
            set => this.SetProperty(value);
        }
    }
}
