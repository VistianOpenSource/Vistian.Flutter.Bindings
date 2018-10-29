using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IO.Flutter.Plugin.Common;

namespace Flutter.Bindings
{
    public class GeneratedPluginRegistrant
    {

        public static void RegisterWith(IPluginRegistry registry)
        {
            if (AlreadyRegisteredWith(registry))
            {
                return;
            }
        }

        private static bool AlreadyRegisteredWith(IPluginRegistry registry)
        {
            string key = typeof(GeneratedPluginRegistrant).Name;

            if (registry.HasPlugin(key))
            {
                return true;
            }
            else
            {
                registry.RegistrarFor(key);
                return false;
            }
        }
    }
}