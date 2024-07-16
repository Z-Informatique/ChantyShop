using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChantyShop.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        const int RefreshDuration = 2;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        string siteLink;
        public string SiteLink
        {
            get { return siteLink; }
            set
            {
                siteLink = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        public HomeViewModel()
        {
            SiteLink = "https://chantycp.fr";
        }
        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            SiteLink = "https://chantycp.fr";
            IsRefreshing = false;
        }
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
