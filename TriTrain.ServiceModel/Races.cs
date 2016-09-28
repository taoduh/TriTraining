using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using TriTrain.ServiceModel.Types;

namespace TriTrain.ServiceModel
{

    [Route("/races", "GET")]
    [Route("/races/distance/{raceDistance}", "GET")]
    public class Races : IReturn<List<Race>>
    {
        public int? RaceDistance { get; set; }
    }

    [Route("/races/{Id}", "GET")]
    public class GetRace : IReturn<Race>
    {
        public int Id { get; set; }
    }

    [Route("/races", "POST")]
    public class CreateRace : IReturn<Race>
    {
        public string Name { get; set; }
        public int RaceDistanceId { get; set; }
        public DateTime RaceDay { get; set; }
    }

    [Route("/races/{Id}", "PUT")]
    public class UpdateRace : IReturn<Race>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RaceDistanceId { get; set; }
        public DateTime RaceDay { get; set; }
        public double SwimResult { get; set; }
        public double T1Result { get; set; }
        public double BikeResult { get; set; }
        public double T2Result { get; set; }
        public double RunResult { get; set; }
    }

    [Route("/races/{Id}/delete")]
    public class DeleteRace
    {
        public int Id { get; set; }
    }

}
