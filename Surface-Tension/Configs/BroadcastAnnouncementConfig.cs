using System.ComponentModel;

namespace Surface_Tension.Configs
{
    public sealed class BroadcastAnnouncementConfig
    {
        [Description("This is the text that will be displayed when announced.")]
        public string BroadcastText { get; set; } = "The underground section of the facility has been detonated. Radiation has been detected, please evacuate immediately.";

        [Description("This is the delay (seconds) before the announcement will be made. Set to -1 to disable. Minimum is 0.5, maximum is 300")]
        public float BroadcastTime { get; set; } = -1f;
    }
}
