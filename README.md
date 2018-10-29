# Xamarin host for Flutter

## Introduction

An experimental release of code allowing for Flutter solutions to be hosted within an Xamarin Android / iOS solution.

## Motivation

* Allow for a single code base to be used where native code needs to be constructed with a Flutter based solution.
* Better partition ones solution playing to each others strengths. For me Flutter is better for a quick turnaround of consistent user interfaces across Android & iOS, Xamarin for more of the lower level services and utilization of 3rd party libraries and platform APIs.

## Prerequisites

* Visual Studio 2017 15.8.6 for Windows or Visual Studio for Mac 7.6.10
* Flutter 0.9.4 - to edit/update the Flutter elements.  

## Caveats

* This is a work in progress, more of a 'could it work' than neccessarily how it should work.  

* There is currently no built in tooling provided to allow for editing of dart/flutter solutions and for it be reflected in the Xamarin solution (ala Visual Code/Android Studio).

* This has only been tested in a Nexus 6P device for Android, on iOS an iPhone 6S+ and the standard emulators. **No other devices or emulators have been tried with this solution.**

* This not designed to allow for the delivery of release solutions.

## Installation

### Android

1. Install the package Vistian.Flutter.Bindings available from nuget.
2. In the Assets folder of your application create a 'flutter_shared' folder.
3. In this folder place the icudtl.dat file available here https://github.com/VistianOpenSource/Vistian.Flutter.Bindings/blob/master/FlutterAssets/flutter_shared/icudtl.dat on github.
4. If your application targets 64-bit solutions e.g. arm64-v8a **turn this option off** in your project settings. Similarly delete all of the installed common libraries and the existing app from your device (Mono Shared Runtime, Xamarin.*).
5. To see that the Flutter view is correctly installed, change your startup activities OnCreate to be the following:

```C#
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);

    var flutterView = Flutter.Bindings.Flutter.CreateView(this, this.Lifecycle, "home");
    var layout = new FrameLayout.LayoutParams(600, 800) {LeftMargin = 200, TopMargin = 400};

    AddContentView(flutterView, layout);
}
```

6. To be able to adjust the Flutter content, goto a terminal / console and in the folder where your flutter solution exists type :

```
flutter attach 
```
or if you have more than one device connected , get the device id first then use that with attach
```
flutter devices
flutter attach -d device Id

```
7. Once the Flutter attach is running restart your Xamarin solution and now you can use Shift+R & R in the terminal to refresh your solution.

### iOS

Coming once I update by bindings from an older installation of Flutter to Flutter 0.9.4

## Common Issues

### Android

#### Application starts and immediately exits

More than likely this is down to the fact that the shared runtime and libraries haven't been removed from the device. The device log can confirm this.

#### Application starts but crashes when the Flutter View is created

This typically happens when the icudtl.dat hasn't been included in the application.  I have been trying to get this installed automatically as part of the nuget package but for some reason the current version of Visual Studio doesn't want to install Android Assets from a nuget package. Once again the device log can confirm this.

