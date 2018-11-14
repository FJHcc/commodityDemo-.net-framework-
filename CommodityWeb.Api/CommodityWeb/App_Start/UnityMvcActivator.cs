using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CommodityWeb.UnityMvcActivator), nameof(CommodityWeb.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CommodityWeb.UnityMvcActivator), nameof(CommodityWeb.UnityMvcActivator.Shutdown))]

namespace CommodityWeb
{
    /// <summary>
    /// ��δ��벻֪��������ʲô���
    /// </summary>
    public class UnityHttpControllerActivator : IHttpControllerActivator
    {
        /// <summary>
        /// 
        /// </summary>
        public IUnityContainer UnityContainer { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unityContainer"></param>
        public UnityHttpControllerActivator(IUnityContainer unityContainer)
        {
            this.UnityContainer = unityContainer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)this.UnityContainer.Resolve(controllerType);
        }
    }
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
            //��һ�д��벻�Ӿ�ע�벻�ɹ�����ʱ��֪��Ϊʲô��
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new UnityHttpControllerActivator(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}