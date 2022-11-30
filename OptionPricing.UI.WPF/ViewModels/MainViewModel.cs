using CommunityToolkit.Mvvm.Input;
using OptionPricing.Domain;
using OptionPricing.Transport;
using OptionPricing.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OptionPricing.UI.WPF.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITransport _transport;
        public string AppName { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _firstName;
        private string _lastName;
        private string _deskName;
        private double _volatility;
        private DateTime _maturity = DateTime.Now;
        private double _strike;
        private double _riskFreeRate;
        private DateTime _pricingDate = DateTime.Now;
        private Model _model;
        private double _stockPrice;
        private UnderlyingType _underlyingType;
        private float _premium;

        public string FirstName {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string LastName {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        public string DeskName {
            get => _deskName;
            set => SetProperty(ref _deskName, value);
        }
        public double Volatility {
            get => _volatility;
            set => SetProperty(ref _volatility, value);
        }
        public DateTime Maturity {
            get => _maturity;
            set => SetProperty(ref _maturity, value);
        }
        public double Strike {
            get => _strike;
            set => SetProperty(ref _strike, value);
        }
        public double RiskFreeRate {
            get => _riskFreeRate;
            set => SetProperty(ref _riskFreeRate, value);
        }
        public float Premium {
            get => _premium;
            set => SetProperty(ref _premium, value);
        }
        public DateTime PricingDate {
            get => _pricingDate;
            set => SetProperty(ref _pricingDate, value);
        }
        public Model Model {
            get => _model;
            set => SetProperty(ref _model, value);
        }
        public double StockPrice {
            get => _stockPrice;
            set => SetProperty(ref _stockPrice, value);
        }
        public UnderlyingType UnderlyingType {
            get => _underlyingType;
            set => SetProperty(ref _underlyingType, value);
        }

        public ICommand PriceButton { get; set; }

        public MainViewModel(ITransport transport)
        {
            AppName = "Option Pricer";
            _transport = transport;
            PriceButton = new RelayCommand(OnClickButton);
        }

        private void OnClickButton()
        {
            DeskName deskName = new DeskName(DeskName);
            Desk desk = new Desk(deskName);
            FirstName firstName = new FirstName(FirstName);
            LastName lastName = new LastName(LastName);
            Trader trader = new Trader(firstName, lastName, desk);

            InitialStockPrice initialStockPrice = new InitialStockPrice((float)StockPrice);
            ImpliedVolatility implied_volatility = new ImpliedVolatility((float)Volatility);
            Maturity maturity = new Maturity(DateTime.Today);
            Strike strike = new Strike((float)Strike);
            PricingDate pricingDate = new PricingDate(DateTime.Today);
            RiskFreeRate riskFreeRate = new RiskFreeRate((float)RiskFreeRate);

            UnderlyingType underlyingType = UnderlyingType;
            Model model = Model;
            Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

            Option option = new Option(strike, maturity, trader, underlying);
            Pricing pricing = new Pricing(pricingDate, option, model);

            //Premium premium = new Premium(2);
            //pricing.Premium = premium;
            pricing = _transport.Connect("localhost", 5555, pricing);
            Premium = pricing.Premium.Value;
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue) )
            {
                field = newValue;
               // Trace.WriteLine(newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}
