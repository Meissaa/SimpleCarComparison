using CarComparison.WebApp.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace CarComparison.WebApp.App_Start
{
    public class UnityConfig
    {
        private static IUnityContainer _container = new UnityContainer();
        public static void ConfiguredContainer()
        {
            _container.LoadConfiguration();
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
        }
    }
}