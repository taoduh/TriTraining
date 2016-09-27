using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using TriTrainingSSThree.ServiceModel.Types;

namespace TriTrainingSSThree.ServiceModel
{

    [Route("/plans", "GET")]
    [Route("/plans/race/{RaceId}", "GET")]
    public class Plans : IReturn<List<Plan>>
    {
        public int? RaceId { get; set; }
    }

    [Route("/plans/{Id}", "GET")]
    public class GetPlan : IReturn<Plan>
    {
        public int Id { get; set; }
    }

    [Route("/plans", "POST")]
    public class CreatePlan : IReturn<Plan>
    {
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int MinSwimWorkouts { get; set; }
        public int MinBikeWorkouts { get; set; }
        public int MinRunWorkouts { get; set; }
        public int MaxWorkouts { get; set; }
        public int MaxBricks { get; set; }
        public int MinRestDays { get; set; }
    }

    [Route("/plans/{Id}", "PUT")]
    public class UpdatePlan : IReturn<Plan>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int MinSwimWorkouts { get; set; }
        public int MinBikeWorkouts { get; set; }
        public int MinRunWorkouts { get; set; }
        public int MaxWorkouts { get; set; }
        public int MaxBricks { get; set; }
        public int MinRestDays { get; set; }
    }

    [Route("/plans/{Id}/delete")]
    public class DeletePlan
    {
        public int Id { get; set; }
    }

    /*
    ui: as I set preferences, show a sample week
    Calendar view
     */
}
