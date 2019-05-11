---
id: "42D7A7A4-C45E-4393-8731-9304602D1B11"
title: "Verify the WeatherGadgetSDK binding in your iOS app"
nav-title: "Verify the binding"
---

Now, we can test the bindings library is working correctly in the new iOS app.

1. In your app view controller's `ViewDidLoad` method, create an instance of the `Weather` type.
2. Set the `CurrentTemperature` property to `99f`.
3. Call `Debug.WriteLine` with your instance variable's `CurrentTemperature` property to see if the value was set properly.

~~~csharp
public override void ViewDidLoad() {
    base.ViewDidLoad();

    Weather myWeather = new Weather();
    myWeather.CurrentTemperature = 99f;
    Debug.WriteLine($"Temperature - {myWeather.CurrentTemperature}");
}
~~~

We can also test out the `WeatherGadgetDelegate` class.

1. Create a new `GadgetDelegate` class in the iOS app which inherits from the `WeatherGadgetDelegate` class.
1. Implement the required delegate member `DidFetchWeather`. When implementing the member, make sure to check the `NSError` parameter is `null`.
1. Call `Debug.WriteLine` to report the value of the returned `CurrentTemperature`.

~~~csharp
using System.Diagnostics;
using Foundation;
using WeatherSDK;

namespace WeatherGadgetApp {
    public class GadgetDelegate : WeatherGadgetDelegate{
        public override void DidFetchWeather(Weather weather, NSError withError) {
            if (withError == null) {
                Debug.WriteLine($"Delegate Answering {weather.CurrentTemperature}");
            }
        }
    }
}
~~~

To test the delegate, we need to create a new **GadgetDelegate** for the **WeatherGadget** we created earlier.

1. Back in your app view controller's `ViewDidLoad` method, create an instance of `GadgetDelegate`.
2. Set the `Delegate` property to the new GadgetDelegate instance.
3. Invoke the `FetchWeather` method on the **WeatherGadget** instance to test the delegate implementation.

~~~csharp
public override void ViewDidLoad() {
    base.ViewDidLoad();
    // Perform any additional setup after loading the view, typically from a nib.

    ...

    WeatherGadget wGadget = new WeatherGadget();
    wGadget.Delegate = new GadgetDelegate();
    wGadget.FetchWeather();
}
~~~

Finally, run the application to make sure the expected `Debug` statements are logged.
