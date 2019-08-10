using System;
using System.Collections.Generic;
using System.IO;
using Funq;
using MyApp.ServiceInterface;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation;
using ServiceStack.Web;

namespace MyApp
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("MyApp", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any Plugins or IOC dependencies used by your web services
        /// </summary>
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get("DebugMode", false),
                WebHostPhysicalPath = MapProjectPath("~/wwwroot"),
                AddRedirectParamsToQueryString = true,
                UseSecureCookies = true,
                UseCamelCase = true,
            });

            Plugins.Add(new SharpPagesFeature());
        }
    }

}
