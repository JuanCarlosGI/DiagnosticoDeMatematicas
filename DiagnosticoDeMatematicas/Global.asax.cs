using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DiagnosticoDeMatematicas.DAL.Binders;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(Answer), new AnswerBinder()));
        }
    }
}
