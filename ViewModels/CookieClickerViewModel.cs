using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookieClicker.ViewModels
{
    public class CookieClickerViewModel : INotifyPropertyChanged
    {
        private int _cookieCount;
        public int CookieCount
        {
            get => _cookieCount;
            set
            {
                if (_cookieCount != value)
                {
                    _cookieCount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CanBuyAvo));
                    OnPropertyChanged(nameof(CanBuyClicker));
                    OnPropertyChanged(nameof(CanBuyWhiteUpgrade));
                    OnPropertyChanged(nameof(CanBuyRedUpgrade));
                    OnPropertyChanged(nameof(CanBuyRollerUpgrade));
                }
            }
        }

        private int _avoCount;
        public int AvoCount
        {
            get => _avoCount;
            set
            {
                if (_avoCount != value)
                {
                    _avoCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _clickerCount;
        public int ClickerCount
        {
            get => _clickerCount;
            set
            {
                if (_clickerCount != value)
                {
                    _clickerCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _whiteUpgradeBought;
        public bool WhiteUpgradeBought
        {
            get => _whiteUpgradeBought;
            set
            {
                if (_whiteUpgradeBought != value)
                {
                    _whiteUpgradeBought = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _redUpgradeBought;
        public bool RedUpgradeBought
        {
            get => _redUpgradeBought;
            set
            {
                if (_redUpgradeBought != value)
                {
                    _redUpgradeBought = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _rollerUpgradeBought;
        public bool RollerUpgradeBought
        {
            get => _rollerUpgradeBought;
            set
            {
                if (_rollerUpgradeBought != value)
                {
                    _rollerUpgradeBought = value;
                    OnPropertyChanged();
                }
            }
        }

        // Property to control if the user can buy the nanny 
        public bool CanBuyAvo => CookieCount >= 100;

        // Property to control if the user can buy the clicker 
        public bool CanBuyClicker => CookieCount >= 15;

        // Property to control if the user can buy the white upgrade
        public bool CanBuyWhiteUpgrade => CookieCount >= 100 && !WhiteUpgradeBought;

        // Property to control if the user can buy the red upgrade
        public bool CanBuyRedUpgrade => CookieCount >= 500 && !RedUpgradeBought;

        // Property to control if the user can buy the roller upgrade
        public bool CanBuyRollerUpgrade => CookieCount >= 1000 && !RollerUpgradeBought;

        // Method to buy the nanny 
        public void BuyAvo()
        {
            if (CookieCount >= 100)
            {
                CookieCount -= 100;
                AvoCount++;
                OnPropertyChanged(nameof(CanBuyAvo));
                StartAvoTimer();
            }
        }

        // Method to buy the clicker 
        public void BuyClicker()
        {
            if (CookieCount >= 15)
            {
                CookieCount -= 15;
                ClickerCount++;
                OnPropertyChanged(nameof(CanBuyClicker));
                StartClickerTimer();
            }
        }

        // Method to buy the white upgrade
        public void BuyWhiteUpgrade()
        {
            if (CookieCount >= 100 && !WhiteUpgradeBought)
            {
                CookieCount -= 100;
                WhiteUpgradeBought = true;
                OnPropertyChanged(nameof(CanBuyWhiteUpgrade));
            }
        }

        // Method to buy the red upgrade
        public void BuyRedUpgrade()
        {
            if (CookieCount >= 500 && !RedUpgradeBought)
            {
                CookieCount -= 500;
                RedUpgradeBought = true;
                OnPropertyChanged(nameof(CanBuyRedUpgrade));
            }
        }

        // Method to buy the roller upgrade
        public void BuyRollerUpgrade()
        {
            if (CookieCount >= 1000 && !RollerUpgradeBought)
            {
                CookieCount -= 1000;
                RollerUpgradeBought = true;
                OnPropertyChanged(nameof(CanBuyRollerUpgrade));
            }
        }

        private System.Timers.Timer _avoTimer;
        private System.Timers.Timer _clickerTimer;

        // Method to start the nanny timer
        private void StartAvoTimer()
        {
            if (_avoTimer == null)
            {
                _avoTimer = new System.Timers.Timer(1000); // 1 second
                _avoTimer.Elapsed += (s, e) =>
                {
                    // Since the timer runs on a separate thread, we need to update on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        CookieCount += AvoCount * (RollerUpgradeBought ? 2 : 1);
                    });
                };
                _avoTimer.Start();
            }
        }

        // Method to start the clicker timer
        private void StartClickerTimer()
        {
            if (_clickerTimer == null)
            {
                _clickerTimer = new System.Timers.Timer(10000); // 10 seconds
                _clickerTimer.Elapsed += (s, e) =>
                {
                    // Since the timer runs on a separate thread, we need to update on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        CookieCount += ClickerCount;
                    });
                };
                _clickerTimer.Start();
            }
        }

        // Method to notify property change
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to increment cookies
        public void IncrementCookie()
        {
            int increment = 1;
            if (WhiteUpgradeBought)
            {
                increment *= 2;
            }
            if (RedUpgradeBought)
            {
                increment *= 2;
            }
            CookieCount += increment;
        }
    }
}
