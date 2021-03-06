using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Adamsone.Infrastructure;
using Adamsone.Services;
using Adamsone.ViewModels;
using Caliburn.Micro;

namespace Adamsone
{
    public class AppBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<ConfigManager>()
                .Singleton<WebSessionManager>()
                .Singleton<KeepAliveService>()
                .Singleton<ProfileService>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel") && type.Name != "BrowserViewModel")
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));

            base.Configure();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}