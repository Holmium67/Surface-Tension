using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Surface_Tension
{
    public class Config : IConfig
    {
        [Description("Enables/Disables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enables/disables having to wait between the nuke going off and the damaging of players.")]
        public bool EnableDelay { get; set; } = true;
        [Description("Time (in seconds) to wait after the nuke is detonated before damaging players.")]
        public float DelayTime { get; set; } = 90f;
        [Description("Amount of damage to deal to players.")]
        public int Damage { get; set; } = 1;
        [Description("Time (in seconds) to wait in between dealing damage to players.")]
        public float TimeBetweenDamage { get; set; } = 1f;
        [Description("Changes what the damage type is set as. True treats the value passed in st_damage as % of max health, False treats the the damage as normal HP.")]
        public bool IsDamagePercent { get; set; } = true;

        [Description("Enable custom Cassie announcement on detonation.")]
        public bool CassieAnnounce { get; set; } = true;
        [Description("What do you want Cassie to announce on detonation?")]
        public string CassieText { get; set; } = "The alpha warhead has been detonated . . Radiation has been detected . please evacuate immediately .";
        [Description("Custom subtitles for the announcement.")]
        public string CassieSubtitles { get; set; } = "The Alpha Warhead has been detonated. Radiation has been detected, please evacuate immediately.";
    }
}
