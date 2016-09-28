using System;
using System.Data;
using System.Linq;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Common.Utils;

//using ServiceStack.Configuration;
//using ServiceStack.Data;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
//using ServiceStack.OrmLite.SqlServer;
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

            container.Register<IDbConnectionFactory>(
                c => new OrmLiteConnectionFactory("~/db.sqlite".MapHostAbsolutePath(), SqliteDialect.Provider)
                {
                    ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
                });

//            container.Register<IDbConnectionFactory>
//                (new OrmLiteConnectionFactory
//                    //(Properties.Settings.Default.LocalSQLConnectionString,
//                    ("",
//                    SqlServerOrmLiteDialectProvider.Instance));

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.DropAndCreateTable<RaceDistance>();
                db.DropAndCreateTable<Race>();
                db.DropAndCreateTable<Plan>();
                db.DropAndCreateTable<Workout>();
                RaceDistancesServices.AddInitialRecords(db);
                RacesServices.AddInitialRecords(db);
                PlansServices.AddInitialRecords(db);
                WorkoutsServices.AddInitialRecords(db);
            }
        }

    }

}