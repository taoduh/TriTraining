using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using TriTrain.ServiceModel.Types;

namespace TriTrain.ServiceModel
{

    [Route("/workouts/plan/{planId}", "GET")]
    public class Workouts : IReturn<List<Workout>>
    {
        public int PlanId { get; set; }
    }

    [Route("/workouts/{Id}", "GET")]
    public class GetWorkout : IReturn<Workout>
    {
        public int Id { get; set; }
    }

    [Route("/workouts", "POST")]
    public class CreateWorkout : IReturn<Workout>
    {
        public int PlanId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string Sport { get; set; }
        public double Duration { get; set; }
    }

    [Route("/workouts/{Id}", "PUT")]
    public class UpdateWorkout : IReturn<Workout>
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string Sport { get; set; }
        public double Duration { get; set; }
    }

    [Route("/workouts/{Id}/delete")]
    public class DeleteWorkout
    {
        public int Id { get; set; }
    }

}
