namespace CapstoneBlazorServerSite.Models
{
    public class CareerStats
    {
        public int CareerStatsId { get; set; }

        public string PlayerId { get; set; }

        public ApplicationUser Player { get; }

        public uint CareerScore { get; set; }

        public uint CareerMinutesPlayed { get; set; }

        private float _pointsPerMinute;

        public uint CareerNumberOfWords { get; set; }

        private float _pointsPerWord;

        public float PointsPerMinute
        {
            get => _pointsPerMinute;
            set => _pointsPerMinute = (CareerScore / CareerMinutesPlayed);
        }

        public float PointsPerWord
        {
            get => _pointsPerWord;
            set => _pointsPerWord = (CareerScore / CareerNumberOfWords);
        }
    }
}
