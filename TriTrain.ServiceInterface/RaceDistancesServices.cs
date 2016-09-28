using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.ServiceInterface;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using TriTrain.ServiceModel;
using TriTrain.ServiceModel.Types;
//using Dapper;

namespace TriTrain.ServiceInterface
{
    public class RaceDistancesServices : Service
    {
        public object Any(RaceDistances request)
        {
            return Db.Select<RaceDistance>();
        }
        public RaceDistance Any(GetRaceDistance request)
        {
            return Db.SingleWhere<RaceDistance>("Id", request.Id);
        }

        public static void AddInitialRecords(IDbConnection db)
        {
            db.Insert(new RaceDistance { Name = "Ironman 140.6", SwimDistance = 2.4, BikeDistance = 112, RunDistance = 26.2 });
            db.Insert(new RaceDistance { Name = "Ironman 70.3", SwimDistance = 1.2, BikeDistance = 56, RunDistance = 13.1 });
            db.Insert(new RaceDistance { Name = "Olympic", SwimDistance = 0.8, BikeDistance = 24, RunDistance = 6.2 });
        }
    }

}
