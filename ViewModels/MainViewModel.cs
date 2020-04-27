// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Watson Laboratory">
//   Copyright © 2020 Watson Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Caliburn.Micro;
using Dapplo.Microsoft.Extensions.Hosting.CaliburnMicro;
using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace intent.ViewModels
{
    /// <summary>
    /// A simple main view model
    /// </summary>
    public class MainViewModel : Screen, ICaliburnMicroShell
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IWindowManager windowManager;
        private readonly IWpfContext wpfContext;

        public MainViewModel(IWpfContext wpfContext, IServiceProvider serviceProvider, IWindowManager windowManager)
        {
            this.wpfContext = wpfContext;
            this.serviceProvider = serviceProvider;
            this.windowManager = windowManager;
        }

        public void Exit()
        {
            this.wpfContext.WpfApplication.Shutdown();
        }

        public void Open()
        {
            var otherWindow = this.serviceProvider.GetService<OtherViewModel>();
            this.windowManager.ShowWindow(otherWindow);
        }
    }
}