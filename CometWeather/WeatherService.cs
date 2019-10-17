using System;
using System.Threading.Tasks;
using System.Linq;
using Comet;

namespace CometWeather
{
    public class WeatherService : IDisposable
    {
        bool isRunning = true;
        Task runningTask;
        public WeatherService(State<WeatherItem> state)
        {
            runningTask = Task.Run(Polling);
            State = state;
        }

        async Task Polling()
        {
            while(isRunning)
            {
                try
                {
                    await Task.Delay(100);
                    var weather = CreateRandom();
                    await ThreadHelper.SwitchToMainThreadAsync();
                    State.Value = weather;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    await Task.Delay(3000);
                }
            }
        }

        public void Dispose()
        {
            isRunning = false;
        }

        static Random random = new Random();
        const double globalMaxTemp = 110;

        public State<WeatherItem> State { get; }

        WeatherItem CreateRandom()
        {
            var percents = new[]{
                random.NextDouble(),
                random.NextDouble(),
                random.NextDouble(),
            }.OrderBy(x=> x).ToList();
            return new WeatherItem
            {
                MinTemp = percents[0] * globalMaxTemp,
                Temp = percents[1] * globalMaxTemp,
                MaxTemp = percents[2] * globalMaxTemp,
            };
        }
    }
}
