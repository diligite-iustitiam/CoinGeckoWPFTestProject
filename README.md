# CoinGeckoWPFTestProject
This program built on MVVM pattern. It includes two services to get data from https://www.coingecko.com/en/api/documentation.
Also, this program has views that communicate and output data from services.
Converter made by static data in ConverterView.xaml.cs
Implemented possibility of navigation and renavigation(without DI)
ServiceRegistrator and ViewModelsRegistrator separated from main app.
Resources are stored in separate folder.
To make the architecture cleaner, you can create a Domain layer(must not have any dependecies) of the program in which the main models will be stored,
the logic of data transfer from the service can be transferred separately to Infrastructure.
WPF UI Interface(Resources, ViewModels,Commands,Images) must also be implemented separately too.
