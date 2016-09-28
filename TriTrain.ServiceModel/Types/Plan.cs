using ServiceStack.DataAnnotations;

namespace TriTrain.ServiceModel.Types
{
    public class Plan
    {
        [AutoIncrement]
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

    // %/week increase, focus on which (for a period?), max distance for each
}
