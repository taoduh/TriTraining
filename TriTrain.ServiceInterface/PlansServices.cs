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
    public class PlansValidator : AbstractValidator<CreatePlan>
    {
        public PlansValidator()
        {
            RuleFor(x => x.RaceId).NotEmpty().WithMessage("A plan can't exist without a race.");
        }
    }

    public class PlansServices : Service
    {
        public List<Plan> Any(Plans request)
        {
            if (request.RaceId == null)
            {
                return Db.Select<Plan>();
            }
            else
            {
                return Db.Where<Plan>("RaceId", request.RaceId);
            }
        }

        public Plan Any(GetPlan request)
        {
            return Db.SingleWhere<Plan>("Id", request.Id);
        }

        public Plan Post(CreatePlan request)
        {
            //var plan = request.ConvertTo<Plan>();
            Plan plan = new Plan();
            plan.Name = request.Name;
            plan.RaceId = request.RaceId;
            plan.MinSwimWorkouts = request.MinSwimWorkouts;
            plan.MinBikeWorkouts = request.MinBikeWorkouts;
            plan.MinRunWorkouts = request.MinRunWorkouts;
            plan.MaxWorkouts = request.MaxWorkouts;
            plan.MaxBricks = request.MaxBricks;
            plan.MinRestDays = request.MinRestDays;

            Db.Save(plan);
            return plan;
        }

        public Plan Put(UpdatePlan request)
        {
            //var plan = request.ConvertTo<Plan>();
            Plan plan = new Plan();
            plan.Id = request.Id;
            plan.Name = request.Name;
            plan.RaceId = request.RaceId;
            plan.MinSwimWorkouts = request.MinSwimWorkouts;
            plan.MinBikeWorkouts = request.MinBikeWorkouts;
            plan.MinRunWorkouts = request.MinRunWorkouts;
            plan.MaxWorkouts = request.MaxWorkouts;
            plan.MaxBricks = request.MaxBricks;
            plan.MinRestDays = request.MinRestDays;

            Db.Update(plan);
            return plan;
        }

        public void Any(DeletePlan request)
        {
            Db.DeleteById<Plan>(request.Id);
        }

        public static void AddInitialRecords(IDbConnection db)
        {
            db.Insert(new Plan { Name = "Aggressive Oceanside Plan", RaceId = 1, MinSwimWorkouts = 2, MinBikeWorkouts = 2, MinRunWorkouts = 2, MaxWorkouts = 8, MaxBricks = 2, MinRestDays = 1 });
            db.Insert(new Plan { Name = "Easy Oceanside Plan", RaceId = 1, MinSwimWorkouts = 2, MinBikeWorkouts = 1, MinRunWorkouts = 1, MaxWorkouts = 6, MaxBricks = 1, MinRestDays = 2 });
        }
    }
}
