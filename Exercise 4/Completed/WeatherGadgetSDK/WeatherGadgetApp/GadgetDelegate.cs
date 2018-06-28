using System;
using System.Diagnostics;
using Foundation;
using WeatherGadgetSDK;

namespace WeatherGadgetApp {
    public class GadgetDelegate: WeatherGadgetDelegate {

        public override void DidFetchWeather(Weather weather, NSError withError) {
            if (withError == null)
                Debug.WriteLine($"Delegate Answering {weather.CurrentTemperature}");
        }
    }
}