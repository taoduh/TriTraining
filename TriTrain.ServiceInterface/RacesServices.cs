using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.ServiceInterface;
using ServiceStack.FluentValidation;
using ServiceStack.OrmLite;
using TriTrain.ServiceModel;
using TriTrain.ServiceModel.Types;

namespace TriTrain.ServiceInterface
{
    public class RacesValidator : AbstractValidator<CreateRace>
    {
        public RacesValidator()
        {
            RuleFor(x => x.RaceDistanceId).NotEmpty().WithMessage("A distance is required to understand a race.");
        }
    }
    
    public class RacesServices : Service
    {
        public List<Race> Any(Races request)
        {
            if (request.RaceDistance == null)
            {
                return Db.Select<Race>();
            }
            else
            {
                return Db.Where<Race>("RaceDistanceId", request.RaceDistance);
            }
        }

        public Race Any(GetRace request)
        {
            return Db.SingleWhere<Race>("Id", request.Id);
        }

        public Race Post(CreateRace request)
        {
            //var race = request.ConvertTo<Race>();
            Race race = new Race();
            race.Name = request.Name;
            race.RaceDistanceId = request.RaceDistanceId;
            race.RaceDay = request.RaceDay;

            Db.Save(race);
            return race;
        }

        public Race Put(UpdateRace request)
        {
            //var race = request.ConvertTo<Race>();
            Race race = new Race();
            race.Id = request.Id;
            race.Name = request.Name;
            race.RaceDistanceId = request.RaceDistanceId;
            race.RaceDay = request.RaceDay;
            race.SwimResult = request.SwimResult;
            race.T1Result = request.T1Result;
            race.BikeResult = request.BikeResult;
            race.T2Result = request.T2Result;
            race.RunResult = request.RunResult;

            Db.Update(race);
            return race;
        }

        public void Any(DeleteRace request)
        {
            Db.DeleteById<Race>(request.Id);
        }

        public static void AddInitialRecords(IDbConnection db)
        {
            db.Insert(new Race { Name = "Ironman Oceanside 70.3", RaceDistanceId = 2, RaceDay = DateTime.Parse("4/2/2016") });
            db.Insert(new Race { Name = "Vineman 70.3", RaceDistanceId = 2, RaceDay = DateTime.Parse("7/31/2016") });
        }
    }
}
