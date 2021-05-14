using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using Restly.Core;

namespace Restly.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<DroidSetup, App>, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState) { }

        public void OnActivityStarted(Activity activity) { }

        public void OnActivityResumed(Activity activity) { }

        public void OnActivityPaused(Activity activity) { }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }

        public void OnActivityStopped(Activity activity) { }

        public void OnActivityDestroyed(Activity activity) { }
    }
}