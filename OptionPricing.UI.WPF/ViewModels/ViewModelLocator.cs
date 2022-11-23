using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OptionPricing.Infrastructure;
using OptionPricing.Transport;
using System;

namespace OptionPricing.UI.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel Main => Ioc.Default.GetService<MainViewModel>();
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(
                    (IServiceProvider)new ServiceCollection()

                    // Dependancies : 
                    .AddSingleton<IOptionPricingSerializer, OptionPricingSerializer>()
                    .AddSingleton<ITransport, OptionPricingTransport>()

                    // View Models : 
                    .AddTransient<MainViewModel>()

                    // building Servicer : 
                    .BuildServiceProvider()
                    );
        }
    }
}
