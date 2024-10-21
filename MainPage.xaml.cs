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

        private void BuyClickerButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyClicker();
        }

        private void BuyAvoButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyAvo();
        }

        private void BuyWhite_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyWhiteUpgrade();
        }

        private void BuyRed_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyRedUpgrade();
        }

        private void BuyRoller_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyRollerUpgrade();
        }
    }

}
