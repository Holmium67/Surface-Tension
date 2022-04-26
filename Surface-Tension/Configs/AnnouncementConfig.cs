using Surface_Tension.API.Enums;
using System.ComponentModel;

namespace Surface_Tension.Configs
{
    public sealed class AnnouncementConfig
    {
        [Description("This is the type of announcement that will be made. Options are: None (-1), Cassie (1), Hint (2) or Broadcast (4).")]
        public AnnouncementType AnnouncementType { get; set; } = AnnouncementType.None;

        [Description("_____________This will be made on detonation_____________")]
        public CassieAnnouncementConfig CassieDetonation { get; private set; } = new CassieAnnouncementConfig();

        public HintAnnouncementConfig HintDetonation { get; private set; } = new HintAnnouncementConfig();

        public BroadcastAnnouncementConfig BroadcastDetonation { get; private set; } = new BroadcastAnnouncementConfig();
    }
}
