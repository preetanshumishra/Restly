using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected IRestlyNavigationService NavigationService { get; set; }
        protected IMvxAsyncCommand CloseCommand { get; set; }

        protected BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IRestlyNavigationService>();
            CloseCommand = new MvxAsyncCommand(() => NavigationService.Close(this));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);
    }
}