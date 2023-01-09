using CoinGeckoWPFTestProject.Infrastructure.Commands.Base;
using System;
using System.Windows;

namespace CoinGeckoWPFTestProject.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;
        public override void Execute(object? parameter) => Application.Current.Shutdown();
        
    }
}
