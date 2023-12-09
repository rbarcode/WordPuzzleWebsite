using System.ComponentModel.DataAnnotations;

namespace CapstoneBlazorServerSite.Models
{
    public class CareerStats
    {
        [Key]
        public string PlayerId { get; set; }

        public string PlayerName { get; set; }

        public uint HighScore { get; set; }

        public uint CareerScore { get; set; }

        public double CareerMinutesPlayed { get; set; }

        private double _careerPointsPerMinute;

        public double CareerPointsPerMinute
        {
            get => _careerPointsPerMinute;
            set => _careerPointsPerMinute = (CareerScore / CareerMinutesPlayed);
        }

        public uint CareerNumberOfWords { get; set; }

        private double _careerPointsPerWord;

        public double CareerPointsPerWord
        {
            get => _careerPointsPerWord;
            set => _careerPointsPerWord = (CareerScore / CareerNumberOfWords);
        }
    }
}
