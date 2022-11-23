using OptionPricing.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OptionPricing.UI.WPF.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
    {
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
        private string _model;
        private double _stockPrice;
        private string _underlyingType;

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
        public DateTime PricingDate {
            get => _pricingDate;
            set => SetProperty(ref _pricingDate, value);
        }
        public string Model { 
            get => _model;
            set => SetProperty(ref _model, value);
        }
        public double StockPrice {
            get => _stockPrice;
            set => SetProperty(ref _stockPrice, value);
        }
        public string UnderlyingType {
            get => _underlyingType;
            set => SetProperty(ref _underlyingType, value);
        }

        public MainViewModel()
        {
            AppName = "Option Pricer";
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue) )
            {
                field = newValue;
                Trace.WriteLine(newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}
