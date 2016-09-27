using ServiceStack.DataAnnotations;

namespace TriTrainingSSThree.ServiceModel.Types
{
    public class RaceDistance
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double SwimDistance { get; set; }
        public double BikeDistance { get; set; }
        public double RunDistance { get; set; }

        public double TotalDistance
        {
            get
            {
                // TODO: nicely round
                return SwimDistance + BikeDistance + RunDistance;
            }
        }
    }
}
