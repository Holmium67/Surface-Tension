using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Surface_Tension.Configs
{
    public class BaseConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Enable to help find bug sources.")]
        public bool DebugMode { get; set; } = false;

        public DamageConfig Damage { get; private set; } = new DamageConfig();

        public AnnouncementConfig Announcement { get; private set; } = new AnnouncementConfig();
    }
}
