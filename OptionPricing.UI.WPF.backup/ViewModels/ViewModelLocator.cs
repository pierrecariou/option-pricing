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
                    .AddSingleton<IOptionPricingSerialiser, OptionPricingSerialiser>()
                    .AddSingleton<ITransport, OptionPricingTransport>()

                    // View Models : 
                    .AddTransient<MainViewModel>()

                    // building Servicer : 
                    .BuildServiceProvider()

                    );

        }
    }
}
