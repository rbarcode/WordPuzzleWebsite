using CapstoneBlazorServerSite.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;


namespace CapstoneBlazorServerSite.Components
{
    public partial class RankingsComponent
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<string> PlayerNames { get; set; }

        [Parameter]
        public List<uint> PlayerHighScores { get; set; }

        [Parameter]
        public List<double> PlayerPointsPerMetric { get; set; }

        [Parameter]
        public bool IsHighScore { get; set; }

        [Parameter]
        public List<byte> FrequencyHistogramData { get; set; }

        [Parameter]
        public uint UserHighScore { get; set; }

        [Parameter]
        public double UserPointsPerWord { get; set; }

        [Parameter]
        public double UserPointsPerMinute { get; set; }

        [Parameter]
        public sbyte UserInterval { get; set; }

    }
}
