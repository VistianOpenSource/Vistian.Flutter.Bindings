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
using Fragment = Android.Support.V4.App.Fragment;

namespace Flutter.Bindings
{
    public class FlutterFragment : Fragment
    {
        private const string ArgumentRoute = "route";

        private string _route = "/";

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Arguments != null)
            {
                _route = Arguments.GetString(ArgumentRoute);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return Flutter.CreateView(Activity, Lifecycle, _route);
        }
    }
}