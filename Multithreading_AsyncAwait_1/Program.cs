using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_AsyncAwait_1
{
    public class WeatherServiceAsyncTester
    {
        //Синхронная версия
        public Forecast[] GetForecastForAllCities(City[] cities)
        {
            Forecast[] forecasts = new Forecast[cities.Length];
            using (WeatherService weather = new WeatherService())
            {
                for (int i = 0; i < cities.Length; ++i)
                {
                    forecasts[i] = weather.GetForecast(cities[i]);
                }
            }

            return forecasts;
        }

        //Асинхронная версия
        public Task<Forecast[]> GetForecastsForAllCitiesAsync(City[] cities)
        {
            if (cities.Length == 0)
            {
                return Task.Run(() => new Forecast[0]);
            }

            WeatherService weather = new WeatherService();
            Forecast[] forecasts = new Forecast[cities.Length];
            var resTsk = GetForecastHelper(weather, 0, cities, forecasts);
            return resTsk.ContinueWith(_ => forecasts);
        }

        private static Task GetForecastHelper(WeatherService weather, int i, City[] cities, Forecast[] forecasts)
        {
            if (i >= cities.Length)
                return Task.Run(() => { });
            Task<Forecast> forecast = weather.GetForecastAsync(cities[i]);
            forecast.ContinueWith(task =>
            {
                forecasts[i] = task.Result;
                return GetForecastHelper(weather, i + 1, cities, forecasts);
            });
            return forecast;
        }

        //Асинхронная версия с await
        public async Task<Forecast[]> GetForecastForAllCities2Async(City[] cities)
        {
            Forecast[] forecasts = new Forecast[cities.Length];
            using (WeatherService weather = new WeatherService())
            {
                for (int i = 0; i < cities.Length; ++i)
                {
                    forecasts[i] = await weather.GetForecastAsync(cities[i]);
                }
            }

            return forecasts;
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            var tst = new WeatherServiceAsyncTester();
            var cities = new[]
            {
                new City("city01"), new City("city02"), new City("city03"), new City("city04"), new City("city05"),
                new City("city06"), new City("city07"), new City("city08"), new City("city09"), new City("city10")
            };
            //var res = tst.GetForecastForAllCities(cities);

            var res = tst.GetForecastsForAllCitiesAsync(cities).Result;

            //var res = tst.GetForecastForAllCities2Async(cities).Result;

            foreach (var forecast in res)
                Console.WriteLine($"Forecast:{forecast.Temp} City:{forecast.City.Name}");

            Console.ReadKey();
        }
    }

    public class WeatherService : IDisposable
    {
        public Forecast GetForecast(City city)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var num = new Random().Next(-50,50);
            Thread.Sleep(num+50);
            return new Forecast(num, city);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<Forecast> GetForecastAsync(City city)
        {
            return Task.Run(() => GetForecast(city));
        }
    }

    public class City
    {
        public City(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class Forecast
    {
        public Forecast(int temp, City city)
        {
            Temp = temp;
            City = city;
        }

        public int Temp { get; set; }
        public City City { get; set; }
    }
}
