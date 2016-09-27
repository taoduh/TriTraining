using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using TriTrainingSSThree.ServiceModel.Types;

namespace TriTrainingSSThree.ServiceModel
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
        public DateTime SwimResult { get; set; }
        public DateTime T1Result { get; set; }
        public DateTime BikeResult { get; set; }
        public DateTime T2Result { get; set; }
        public DateTime RunResult { get; set; }
    }

    [Route("/races/{Id}/delete")]
    public class DeleteRace
    {
        public int Id { get; set; }
    }

}
