using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using ProjectOne_Missions.Models;
using ProjectOne_Missions.DAL;

namespace ProjectOne_Missions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<MissionContext>(null);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
