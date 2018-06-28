//
//  Weather.h
//  WeatherGadget
//
//  Created by Chris van Wyk on 2017/02/13.
//  Copyright © 2017 Chris van Wyk. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Weather.h"

typedef void(^result)(NSError *error);
typedef void(^weatherResult)(Weather *, NSError *error);

// I am going to call these methods on you...
@protocol WeatherGadgetDelegate <NSObject>

@required
- (void) didFetchWeather:(Weather *)weather withError: (NSError*) withError;

@optional
- (void) didRaiseBuzzerStatus:(BOOL) status withError: (NSError*) withError;
- (void) didCancelBuzzerStatus:(BOOL) status withError: (NSError*) withError;
- (void) didLightLEDStatus:(BOOL) status withError: (NSError*) withError;
- (void) didCancelLEDStatus:(BOOL) status withError: (NSError*) withError;

@end

// this is where you register yourself with me
@interface WeatherGadget : NSObject

- (void) pollSensors:(result) execute;
- (void) fetchWeather;
- (NSMutableArray*) fetchHistoricWeather;
- (void) raiseBuzzer:(BOOL) status;
- (void) lightLED:(BOOL) status;

@property double calibrationOffset;

@property (nonatomic, retain) id <WeatherGadgetDelegate> delegate;

@end


