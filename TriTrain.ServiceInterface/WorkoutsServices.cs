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
    public class WorkoutsValidator : AbstractValidator<CreateWorkout>
    {
        public WorkoutsValidator()
        {
            RuleFor(x => x.PlanId).NotEmpty().WithMessage("A workout must be a part of a plan.");
        }
    }

    public class WorkoutsServices : Service
    {
        public List<Workout> Any(Workouts request)
        {
            return Db.Where<Workout>("PlanId", request.PlanId);
        }

        public Workout Any(GetWorkout request)
        {
            return Db.SingleWhere<Workout>("Id", request.Id);
        }

        public Workout Post(CreateWorkout request)
        {
            //var workout = request.ConvertTo<Workout>();
            Workout workout = new Workout();
            workout.PlanId = request.PlanId;
            workout.WorkoutDate = request.WorkoutDate;
            workout.Sport = request.Sport;
            workout.Duration = request.Duration;

            Db.Save(workout);
            return workout;
        }

        public Workout Put(UpdateWorkout request)
        {
            //var workout = request.ConvertTo<Workout>();
            Workout workout = new Workout();
            workout.Id = request.Id;
            workout.PlanId = request.PlanId;
            workout.WorkoutDate = request.WorkoutDate;
            workout.Sport = request.Sport;
            workout.Duration = request.Duration;

            Db.Update(workout);
            return workout;
        }

        public void Any(DeleteWorkout request)
        {
            Db.DeleteById<Workout>(request.Id);
        }

        public static void AddInitialRecords(IDbConnection db)
        {
            db.Insert(new Workout { PlanId = 2, WorkoutDate = DateTime.Now.Date, Sport = "swim", Duration = 45 });
            db.Insert(new Workout { PlanId = 2, WorkoutDate = DateTime.Now.AddDays(1).Date, Sport = "run", Duration = 5 });
        }
    }
}
