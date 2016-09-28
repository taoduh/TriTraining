using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using TriTrain.ServiceModel.Types;

namespace TriTrain.ServiceModel
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
