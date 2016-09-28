using System;
using ServiceStack.DataAnnotations;

namespace TriTrain.ServiceModel.Types
{

    public class Race
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RaceDistanceId { get; set; }
        public DateTime RaceDay { get; set; }

        public double SwimResult { get; set; }
        public double T1Result { get; set; }
        public double BikeResult { get; set; }
        public double T2Result { get; set; }
        public double RunResult { get; set; }

        public double TotalResult
        {
            get
            {
                return SwimResult + T1Result + BikeResult + T2Result + RunResult;
            }
        }
    }

}