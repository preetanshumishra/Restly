using MvvmCross.Platforms.Ios.Views;
using Restly.Core.ViewModels;

namespace Restly.iOS.Views
{
    public abstract class BaseViewController<TViewModel> : MvxBaseViewController<TViewModel> where TViewModel : BaseViewModel
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateViews();
            AddSubviews();
            AddConstraints();
            SetBindings();
        }

        protected virtual void CreateViews() { }

        protected virtual void AddSubviews() { }

        protected virtual void AddConstraints() { }

        protected virtual void SetBindings() { }
    }
}