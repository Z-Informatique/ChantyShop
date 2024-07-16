
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChantyShop.ViewModel
{
    public class CreativeViewModel : INotifyPropertyChanged
    {
        const int RefreshDuration = 2;
        bool isCreativeRefreshing;

        public bool IsCreativeRefreshing
        {
            get { return isCreativeRefreshing; }
            set
            {
                isCreativeRefreshing = value;
                OnPropertyChanged();
            }
        }
        string siteCreativeLink;
        public string SiteCreativeLink
        {
            get { return siteCreativeLink; }
            set
            {
                siteCreativeLink = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCreativeCommand => new Command(async () => await RefreshCreativeItemsAsync());
        public CreativeViewModel()
        {
            SiteCreativeLink = "https://creative-more-africa.com";
        }
        async Task RefreshCreativeItemsAsync()
        {
            IsCreativeRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            SiteCreativeLink = "https://creative-more-africa.com";
            IsCreativeRefreshing = false;
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
