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
using IO.Flutter.Plugins;
using IO.Flutter.View;
using Java.Interop;


namespace Flutter.Bindings
{
    public class FlutterLifecycleObserver : Java.Lang.Object, ILifecycleObserver
    {
        private readonly Context _context;
        private readonly FlutterView _view;

        public FlutterLifecycleObserver(Context context, FlutterView view)
        {
            _context = context;
            _view = view;
        }

        [Lifecycle.Event.OnCreate]
        [Export]
        public void OnCreate()
        {
            var arguments = new FlutterRunArguments
            {
                BundlePath = FlutterMain.FindAppBundlePath(_context), Entrypoint = "main"
            };

            _view.RunFromBundle(arguments);
            GeneratedPluginRegistrant.RegisterWith(_view.PluginRegistry);
        }

        [Lifecycle.Event.OnStart]
        [Export]
        public void OnStart()
        {
            _view.OnStart();
        }

        [Lifecycle.Event.OnResume]
        [Export]
        public void OnResume()
        {
            _view.OnPostResume();
        }


        [Lifecycle.Event.OnPause]
        [Export]
        public void OnPause()
        {
            _view.OnPause();
        }

        [Lifecycle.Event.OnDestroy]
        [Export]
        public void OnDestroy()
        {
            _view.Destroy();
        }
    }
}