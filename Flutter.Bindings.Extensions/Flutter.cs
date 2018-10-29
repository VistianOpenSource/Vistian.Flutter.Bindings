using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Arch.Lifecycle;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IO.Flutter.View;

namespace Flutter.Bindings
{
    public class Flutter
    {
        public static FlutterView CreateView(Activity activity,Lifecycle lifecycle,string initialRoute)
        {
            FlutterMain.StartInitialization(activity.ApplicationContext);
            FlutterMain.EnsureInitializationComplete(activity.ApplicationContext, new string[] { });

            var nativeView = new FlutterNativeView(activity);

            var flutterView = new BaseFlutterView(activity, null, nativeView);

            if (initialRoute != null)
            {
                flutterView.SetInitialRoute(initialRoute);
            }

            var o = new FlutterLifecycleObserver(activity.ApplicationContext, flutterView);

            lifecycle.AddObserver(o);

            flutterView.Alpha = 0.0f;

            return flutterView;
        }
    }
}