using CookieClicker.ViewModels;

namespace CookieClicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CookieButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.IncrementCookie();
        }

        private void BuyAvoButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyAvo();
        }
    }

}
