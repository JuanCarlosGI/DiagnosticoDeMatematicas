using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace DiagnosticoDeMatematicas
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new SiteContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) =>
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context.Get<SiteContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}