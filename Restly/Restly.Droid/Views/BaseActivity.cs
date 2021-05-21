using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Restly.Core.ViewModels;
using Xamarin.Essentials;

namespace Restly.Droid.Views
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel> where TViewModel : BaseViewModel
    {
        protected abstract int LayoutId { get; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}