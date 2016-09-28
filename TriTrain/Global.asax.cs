using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

/*
 * TODOS
 * 
 * Test insert/update
 * Do I really need to construct the objects in the service layer insert/update methods like that
 */ 

namespace TriTrain
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}

/*
 * DOCS
 * 
 * ServiceStack v3
 * Installing
 * Install-Package ServiceStack -Version 3.9.71 -DependencyVersion Highest
 * but with this order
 * http://www.bettercms.com/support/bugs-and-suggestions/nuget-servicestack-upgrade-fails/
 *
 */