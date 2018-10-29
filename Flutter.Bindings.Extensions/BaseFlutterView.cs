using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using IO.Flutter.Plugin.Common;
using IO.Flutter.View;

namespace Flutter.Bindings
{
    public class BaseFlutterView : FlutterView
    {
        private readonly BasicMessageChannel _lifecycleMessages;

        protected BaseFlutterView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public BaseFlutterView(Context context) : base(context)
        {
        }

        public BaseFlutterView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public BaseFlutterView(Context context, IAttributeSet attrs, FlutterNativeView nativeView) : base(context, attrs, nativeView)
        {
            _lifecycleMessages = new BasicMessageChannel(this, "flutter/lifecycle", StringCodec.Instance);

        }

        public override void OnFirstFrame()
        {
            base.OnFirstFrame();
            this.Alpha = 1.0f;

        }

        public override void OnPostResume()
        {
            _lifecycleMessages.Send("AppLifecycleState.resumed");
        }
    }

}