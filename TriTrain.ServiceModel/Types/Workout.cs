using System;
using ServiceStack.DataAnnotations;

namespace TriTrain.ServiceModel.Types
{
    public class Workout
    {
        [AutoIncrement]
        public int Id { get; set; }
        public int PlanId { get; set; }

        public DateTime WorkoutDate { get; set; }
        public string Sport { get; set; }
        public double Duration { get; set; }
    }

}
