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

        // Propriedade para controlar se o utilizador pode comprar a Avó
        public bool CanBuyAvo => CookieCount >= 10;

        // Método para comprar a Avó
        public void BuyAvo()
        {
            if (CookieCount >= 10)
            {
                CookieCount -= 10;
                AvoCount++;
                OnPropertyChanged(nameof(CanBuyAvo));
                StartAvoTimer();
            }
        }

        private System.Timers.Timer _avoTimer;

        private void StartAvoTimer()
        {
            if (_avoTimer == null)
            {
                _avoTimer = new System.Timers.Timer(5000); // 5 segundos
                _avoTimer.Elapsed += (s, e) =>
                {
                    // Como o timer corre numa thread separada, precisamos de atualizar na thread principal
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        CookieCount += AvoCount;
                    });
                };
                _avoTimer.Start();
            }
        }

        // Método para notificar a mudança de propriedade
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método para incrementar cookies
        public void IncrementCookie()
        {
            CookieCount++;
        }
    }
}
