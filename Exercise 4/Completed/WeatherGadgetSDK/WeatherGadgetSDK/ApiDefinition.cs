using Foundation;
using ObjCRuntime;

namespace WeatherGadgetSDK {
    // @interface Weather : NSObject
    [BaseType(typeof(NSObject))]
    interface Weather {
        // @property (readwrite, nonatomic) double currentTemperature;
        [Export("currentTemperature")]
        double CurrentTemperature { get; set; }
    }

    // typedef void (^result)(NSError *);
    delegate void result(NSError arg0);

    // typedef void (^weatherResult)(Weather *, NSError *);
    delegate void weatherResult(Weather arg0, NSError arg1);

    // @protocol WeatherGadgetDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WeatherGadgetDelegate {
        // @required -(void)didFetchWeather:(Weather *)weather withError:(NSError *)withError;
        [Abstract]
        [Export("didFetchWeather:withError:")]
        void DidFetchWeather(Weather weather, NSError withError);

        // @optional -(void)didRaiseBuzzerStatus:(BOOL)status withError:(NSError *)withError;
        [Export("didRaiseBuzzerStatus:withError:")]
        void DidRaiseBuzzerStatus(bool status, NSError withError);

        // @optional -(void)didCancelBuzzerStatus:(BOOL)status withError:(NSError *)withError;
        [Export("didCancelBuzzerStatus:withError:")]
        void DidCancelBuzzerStatus(bool status, NSError withError);

        // @optional -(void)didLightLEDStatus:(BOOL)status withError:(NSError *)withError;
        [Export("didLightLEDStatus:withError:")]
        void DidLightLEDStatus(bool status, NSError withError);

        // @optional -(void)didCancelLEDStatus:(BOOL)status withError:(NSError *)withError;
        [Export("didCancelLEDStatus:withError:")]
        void DidCancelLEDStatus(bool status, NSError withError);
    }

    // @interface WeatherGadget : NSObject
    [BaseType(typeof(NSObject))]
    interface WeatherGadget {
        // -(void)pollSensors:(result)execute;
        [Export("pollSensors:")]
        void PollSensors(result execute);

        // -(void)fetchWeather;
        [Export("fetchWeather")]
        void FetchWeather();

        // -(NSMutableArray *)fetchHistoricWeather;
        [Export("fetchHistoricWeather")]
        Weather[] FetchHistoricWeather { get; }

        // -(void)raiseBuzzer:(BOOL)status;
        [Export("raiseBuzzer:")]
        void RaiseBuzzer(bool status);

        // -(void)lightLED:(BOOL)status;
        [Export("lightLED:")]
        void LightLED(bool status);

        // @property double calibrationOffset;
        [Export("calibrationOffset")]
        double CalibrationOffset { get; set; }

        [Wrap("WeakDelegate")]
        WeatherGadgetDelegate Delegate { get; set; }

        // @property (retain, nonatomic) id<WeatherGadgetDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Retain)]
        NSObject WeakDelegate { get; set; }
    }
}
