using CapstoneBlazorServerSite.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace CapstoneBlazorServerSite.Pages
{
    public partial class Leaderboards
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public DataContext DataContext { get; set; }


        public uint UserHighScore { get; set; }

        public double UserPointsPerWord { get; set; }

        public double UserPointsPerMinute { get; set; }

        public string UserName { get; set; }

        public List<string> PlayerNamesHS { get; set; }

        public List<uint> HighScores { get; set; }

        public List<byte> FrequencyHistogramHS { get; set; }

        public List<string> PlayerNamesPPW { get; set; }

        public List<double> PointsPerWords { get; set; }

        public List<byte> FrequencyHistogramPPW { get; set; }

        public List<string> PlayerNamesPPM { get; set; }

        public List<double> PointsPerMinutes { get; set; }

        public List<byte> FrequencyHistogramPPM { get; set; }

        public sbyte UserHighScoreInterval { get; set; }

        public sbyte UserPointsPerWordInterval { get; set; }

        public sbyte UserPointsPerMinuteInterval { get; set; }

        public uint MinHighScore {  get; set; }

        public uint MaxHighScore { get; set; }

        public double MinPointsPerWord { get; set; }

        public double MaxPointsPerWord { get; set; }

        public double MinPointsPerMinute { get; set; }

        public double MaxPointsPerMinute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlayerNamesHS = DataContext.CareerStats.OrderByDescending(cs => cs.HighScore)
                                            .Select(cs => cs.PlayerName)
                                            .Take(10)
                                            .ToList();

            HighScores = DataContext.CareerStats.OrderByDescending(cs => cs.HighScore)
                                        .Select(cs => cs.HighScore)
                                        .Take(10)
                                        .ToList();

            PlayerNamesPPW = DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerWord)
                                            .Select(cs => cs.PlayerName)
                                            .Take(10)
                                            .ToList();

            PointsPerWords = DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerWord)
                                            .Select(cs => cs.CareerPointsPerWord)
                                            .Take(10)
                                            .ToList();

            PlayerNamesPPM = DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerMinute)
                                            .Select(cs => cs.PlayerName)
                                            .Take(10)
                                            .ToList();

            PointsPerMinutes = DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerMinute)
                                            .Select(cs => cs.CareerPointsPerMinute)
                                            .Take(10)
                                            .ToList();

            MinHighScore = DataContext.CareerStats.Where(cs => cs.HighScore > 0).Min(cs => cs.HighScore);

            MaxHighScore = DataContext.CareerStats.Max(cs => cs.HighScore);

            MinPointsPerWord = DataContext.CareerStats.Where(cs => cs.CareerPointsPerWord > 0).Min(cs => cs.CareerPointsPerWord);

            MaxPointsPerWord = DataContext.CareerStats.Max(cs => cs.CareerPointsPerWord);

            MinPointsPerMinute = DataContext.CareerStats.Where(cs => cs.CareerPointsPerMinute > 0).Min(cs => cs.CareerPointsPerMinute);

            MaxPointsPerMinute = DataContext.CareerStats.Max(cs => cs.CareerPointsPerMinute);

            FrequencyHistogramHS = CalculateHistogramHighScore(DataContext.CareerStats.Max(cs => cs.HighScore), DataContext.CareerStats.Where(cs => cs.HighScore > 0).Min(cs => cs.HighScore), DataContext.CareerStats.OrderByDescending(cs => cs.HighScore).Select(cs => cs.HighScore).ToList());

            FrequencyHistogramPPW = CalculateHistogramOtherMetric(DataContext.CareerStats.Max(cs => cs.CareerPointsPerWord), DataContext.CareerStats.Where(cs => cs.CareerPointsPerWord > 0).Min(cs => cs.CareerPointsPerWord), DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerWord).Select(cs => cs.CareerPointsPerWord).ToList());

            FrequencyHistogramPPM = CalculateHistogramOtherMetric(DataContext.CareerStats.Max(cs => cs.CareerPointsPerMinute), DataContext.CareerStats.Where(cs => cs.CareerPointsPerMinute > 0).Min(cs => cs.CareerPointsPerMinute), DataContext.CareerStats.OrderByDescending(cs => cs.CareerPointsPerMinute).Select(cs => cs.CareerPointsPerMinute).ToList());

            string userId = GetUserId().Result;

            UserName = GetUserName().Result;

            UserHighScore = DataContext.CareerStats.Where(cs => cs.PlayerId == userId)
                                            .Select(cs => cs.HighScore)
                                            .FirstOrDefault();

            UserPointsPerWord = DataContext.CareerStats.Where(cs => cs.PlayerId == userId)
                                            .Select(cs => cs.CareerPointsPerWord)
                                            .FirstOrDefault();

            UserPointsPerMinute = DataContext.CareerStats.Where(cs => cs.PlayerId == userId)
                                            .Select(cs => cs.CareerPointsPerMinute)
                                            .FirstOrDefault();

            UserHighScoreInterval = CalcUserHighScoreInterval(UserHighScore, MaxHighScore, MinHighScore);

            UserPointsPerWordInterval = CalcUserPPWInterval(UserPointsPerWord, MaxPointsPerWord, MinPointsPerWord);

            UserPointsPerMinuteInterval = CalcUserPPMInterval(UserPointsPerMinute, MaxPointsPerMinute, MinPointsPerMinute);
        }

        private async Task<string> GetUserId()
        {
            var user = (await AuthenticationStateTask).User;
            var userId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userId;
        }

        private async Task<string> GetUserName()
        {
            var user = (await AuthenticationStateTask).User;
            var userName = user.FindFirstValue(ClaimTypes.Name);
            return userName;
        }

        //Determines frequency of scores that fall in each of the 10 intervals between the max score and minimum non-zero score
        private static List<byte> CalculateHistogramHighScore(uint maxScore, uint minNonZeroScore, List<uint> hs)
        {
            List<byte> result = new();
            List<uint> dataset = hs;
            double numOfColumns = 10;
            double range = maxScore - (minNonZeroScore - 0.1);
            double interval = range / numOfColumns;
            double intervalMaxScore = maxScore;

            for (int i = 0; i < 10; i++)
            {
                double intervalCount = dataset.Count(data => data <= intervalMaxScore && data > (intervalMaxScore - interval));               
                byte normalizedIntervalCount = (byte)((intervalCount / (double)dataset.Count) * 100);               
                result.Add(normalizedIntervalCount);
                intervalMaxScore = Math.Round((intervalMaxScore - interval), 2);
            }
            result.Reverse();
            return result;
        }

        //Determines frequency of scores that fall in each of the 10 intervals between the max score and minimum non-zero score
        private static List<byte> CalculateHistogramOtherMetric(double maxScore, double minNonZeroScore, List<double> ppwm)
        {
            List<byte> result = new();
            List<double> dataset = ppwm;
            double numOfColumns = 10;
            double range = maxScore - (minNonZeroScore - 0.1);
            double interval = range / numOfColumns;
            double intervalMaxScore = maxScore;
            for (int i = 0; i < 10; i++)
            {
                double intervalCount = dataset.Count(data => data <= intervalMaxScore && data > (intervalMaxScore - interval));
                byte normalizedIntervalCount = (byte)((intervalCount / (double)dataset.Count) * 100);
                result.Add(normalizedIntervalCount);
                intervalMaxScore = Math.Round((intervalMaxScore - interval), 2);
            }
            result.Reverse();
            return result;
        }

        //Determines in which histogram interval (0 - 9) the player falls (or returns -1 if player score is 0)
        private static sbyte CalcUserHighScoreInterval(uint userHS, uint maxScore, uint minNonZeroScore)
        {
            sbyte userInterval = -1;
            double numOfColumns = 10;
            double range = maxScore - (minNonZeroScore - 1);
            double interval = range / numOfColumns;
            double intervalMinScore = minNonZeroScore;

            if (userHS == minNonZeroScore)
            {
                userInterval = 0;
            }
            else if (userHS > minNonZeroScore)
            {
                for (sbyte i = 0; i < 10; i++)
                {
                    if (userHS > intervalMinScore && userHS <= (intervalMinScore + interval))
                    {
                        userInterval = i;                        
                    }
                    intervalMinScore += interval;
                }
            }

            return userInterval;
        }

        //Determines in which histogram interval (0 - 9) the player falls (or returns -1 if player score is 0)
        private static sbyte CalcUserPPWInterval(double userPPW, double maxScore, double minNonZeroScore)
        {
            sbyte userInterval = -1;
            double numOfColumns = 10;
            double range = maxScore - (minNonZeroScore - 0.1);            
            double interval = range / numOfColumns;
            double intervalMinScore = minNonZeroScore;

            if (userPPW == minNonZeroScore)
            {
                userInterval = 0;
            }
            else if (userPPW > minNonZeroScore)
            {
                for (sbyte i = 0; i < 10; i++)
                {
                    if (userPPW > intervalMinScore && userPPW <= (intervalMinScore + interval))
                    {
                        userInterval = i;                       
                    }
                    intervalMinScore += interval;
                }
            }

            return userInterval;
        }

        //Determines in which histogram interval (0 - 9) the player falls (or returns -1 if player score is 0)
        private static sbyte CalcUserPPMInterval(double userPPM, double maxScore, double minNonZeroScore)
        {
            sbyte userInterval = -1;
            double numOfColumns = 10;
            double range = maxScore - (minNonZeroScore - 0.1);            
            double interval = range / numOfColumns;
            double intervalMinScore = minNonZeroScore;

            if (userPPM == minNonZeroScore)
            {
                userInterval = 0;
            }
            else if (userPPM > minNonZeroScore)
            {
                for (sbyte i = 0; i < 10; i++)
                {
                    if (userPPM > intervalMinScore && userPPM <= (intervalMinScore + interval))
                    {
                        userInterval = i;
                    }
                    intervalMinScore += interval;
                }
            }

            return userInterval;
        }
    }
}
