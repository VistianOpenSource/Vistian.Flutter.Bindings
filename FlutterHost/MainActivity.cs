using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace FlutterHost
{
    [Activity(Label = "FlutterHost", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            var flutterView = Flutter.Bindings.Flutter.CreateView(this, this.Lifecycle, "home");
            var layout = new FrameLayout.LayoutParams(600, 800) {LeftMargin = 200, TopMargin = 400};

            AddContentView(flutterView, layout);
        }
    }
}

