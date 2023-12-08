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

        public uint CareerMinutesPlayed { get; set; }

        private float _careerPointsPerMinute;

        public float CareerPointsPerMinute
        {
            get => _careerPointsPerMinute;
            set => _careerPointsPerMinute = (CareerScore / CareerMinutesPlayed);
        }

        public uint CareerNumberOfWords { get; set; }

        private float _careerPointsPerWord;

        public float CareerPointsPerWord
        {
            get => _careerPointsPerWord;
            set => _careerPointsPerWord = (CareerScore / CareerNumberOfWords);
        }
    }
}
