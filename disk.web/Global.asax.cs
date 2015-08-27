using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using disk.Core;
using disk.Core.Data;
using disk.Core.Domain;
using disk.Core.Domain.Logging;
using disk.Core.Infrastructure;
using disk.Services.Logging;
//using disk.Services.Logging;
//using disk.Services.Tasks;
//using disk.Web.Controllers;
using disk.Web.Framework;
using disk.Web.Framework.Mvc;
using disk.Web.Framework.Mvc.Routes;
using Microsoft.Ajax.Utilities;
using Nop.Web.Framework.Mvc;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;


namespace disk.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //register custom routes (plugins, etc)
            var routePublisher = EngineContext.Current.Resolve<IRoutePublisher>();
            routePublisher.RegisterRoutes(routes);

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Nop.Web.Controllers" }
            );
        }

        protected void Application_Start()
        {
            EngineContext.Initialize(false);
           
            //启用该功能，则需要手动到数据库里创建一个表：
            //create table edmmetadata (id int,modelhash varchar(50));
            MiniProfilerEF6.Initialize();

            //bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();

            //set dependency resolver
            var dependencyResolver = new DiskDependencyResolver();
            DependencyResolver.SetResolver(dependencyResolver);

            //Add some functionality on top of the default ModelMetadataProvider
            ModelMetadataProviders.Current = new DiskMetadataProvider();

            //init data provider
            //var dataProviderInstance = EngineContext.Current.Resolve<BaseDataProviderManager>().LoadDataProvider();
            //dataProviderInstance.InitDatabase();

            //Registering some regular mvc stuff
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            //fluent validation
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new DiskValidatorFactory()));

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            //ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if (webHelper.IsStaticResource(this.Request))
                return;

            //keep alive page requested (we ignore it to prevent creating a guest customer records)
            //string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            //if (webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
            //    return;
            
            EnsureDatabaseIsInstalled();

            if (CanPerformProfilingAction())
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            
            //ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            
            if (webHelper.IsStaticResource(this.Request))
                return;
            
            if (CanPerformProfilingAction())
            {
                //stop as early as you can, even earlier with MvcMiniProfiler.MiniProfiler.Stop(discardResults: true);
                MiniProfiler.Stop();
            }
            
            //dispose registered resources
            //we do not register AutofacRequestLifetimeHttpModule as IHttpModule 
            //because it disposes resources before this Application_EndRequest method is called
            //and in this case the code above will throw an exception
            //UPDATE: we cannot do it. For more info see the following forum topic - http://www.nopcommerce.com/boards/t/22456/30-changeset-3db3868edcf2-loaderlock-was-detected.aspx
            //AutofacRequestLifetimeHttpModule.ContextEndRequest(sender, e);
             
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //we don't do it in Application_BeginRequest because a user is not authenticated yet
            SetWorkingCulture();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);

            //process 404 HTTP errors
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                if (!webHelper.IsStaticResource(this.Request))
                {
                    Response.Clear();
                    Server.ClearError();
                    Response.TrySkipIisCustomErrors = true;

                    /*
                    // Call target Controller and pass the routeData.
                    IController errorController = EngineContext.Current.Resolve<disk.Web.Controllers.CommonController>();

                    var routeData = new RouteData();
                    routeData.Values.Add("controller", "Common");
                    routeData.Values.Add("action", "PageNotFound");

                    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                     * */
                }
            }
        }

        protected void EnsureDatabaseIsInstalled()
        {
            /*
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
            if (!webHelper.IsStaticResource(this.Request) &&
                !DataSettingsHelper.DatabaseIsInstalled() &&
                !webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                this.Response.Redirect(installUrl);
            }*/
        }

        protected void SetWorkingCulture()
        {
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if (webHelper.IsStaticResource(this.Request))
                return;
            
            //keep alive page requested (we ignore it to prevent creating a guest customer records)
            //string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            //if (webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
            //    return;

            /*
            if (webHelper.GetThisPageUrl(false).StartsWith(string.Format("{0}admin", webHelper.GetStoreLocation()),
                StringComparison.InvariantCultureIgnoreCase))
            {
                //admin area


                //always set culture to 'en-US'
                //we set culture of admin area to 'en-US' because current implementation of Telerik grid 
                //doesn't work well in other cultures
                //e.g., editing decimal value in russian culture
                CommonHelper.SetTelerikCulture();
            }
            else
            {
                
                //public store
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                if (workContext.CurrentMember != null )
                {
                    var culture = new CultureInfo(workContext.WorkingLanguage.LanguageCulture);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }*/
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;
            /*
            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404 &&
                !EngineContext.Current.Resolve<CommonSettings>().Log404Errors)
                return;

            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                logger.InsertLog(LogLevel.Error,  exc.Message, exc, workContext.CurrentMember);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }*/
        }

        protected bool CanPerformProfilingAction()
        {
            //will not run in medium trust
            if (CommonHelper.GetTrustLevel() < AspNetHostingPermissionLevel.High)
                return false;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return false;

            return true;
            //return EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore;
        }
    }
}
