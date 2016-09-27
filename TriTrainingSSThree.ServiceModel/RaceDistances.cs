using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using TriTrainingSSThree.ServiceModel.Types;

namespace TriTrainingSSThree.ServiceModel
{

    [Route("/racedistances", "GET")]
    public class RaceDistances : IReturn<List<RaceDistance>>
    {
    }

    [Route("/racedistances/{Id}", "GET")]
    public class GetRaceDistance : IReturn<RaceDistance>
    {
        public int Id { get; set; }
    }

}
