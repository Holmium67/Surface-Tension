using System.ComponentModel;

namespace Surface_Tension.Configs
{
    public sealed class CassieAnnouncementConfig
    {
        [Description("This is the text that will be announced by Cassie.")]
        public string CassieText { get; set; } = "The underground section of the facility has been detonated . . . . Radiation has been detected . Please evacuate immediately .";

        [Description("These are the subtitles for the Cassie announcement.")]
        public string CassieSubtitles { get; set; } = "The underground section of the facility has been detonated. Radiation has been detected, please evacuate immediately.";

        [Description("This is the delay (seconds) before the Cassie announcement will be made. Set to -1 to disable. Minimum is 0.5, maximum is 300")]
        public float CassieTime { get; set; } = -1f;
    }
}
