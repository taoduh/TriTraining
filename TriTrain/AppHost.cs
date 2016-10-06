using System;
using System.Data;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Common.Utils;

using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
//using ServiceStack.OrmLite.SqlServer;
using ServiceStack.OrmLite.MySql;
using TriTrain.ServiceInterface;
using TriTrain.ServiceModel.Types;

namespace TriTrain
{
    // http://www.curlette.com/?p=1068

    public class AppHost
        : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost() : base("TriTrain", typeof(RaceDistancesServices).Assembly) { }
        // TODO: what's going on here?
        // where is hello registered?

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Funq.Container container)
        {
            //register any dependencies your services use, e.g:
            //container.Register<ICacheClient>(new MemoryCacheClient());

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            //this.Plugins.Add(new RazorFormat());

            // TODO: store properties as below
            //            container.Register<IDbConnectionFactory>
            //                (new OrmLiteConnectionFactory
            //                    //(Properties.Settings.Default.LocalSQLConnectionString,
            //                    ("",
            //                    SqlServerOrmLiteDialectProvider.Instance));

            String server = "localhost";
            String database = "TriTrain";
            String uid = "tritrain";
            String password = "runningman";
            String connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";

            container.Register<IDbConnectionFactory>(
                c => new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider)
                {
                    ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
                }
            );

        }

    }

}