using System;

namespace Surface_Tension.API.Enums
{
    [Flags]
    public enum AnnouncementType
    {
        None = -1,
        Cassie = 1,
        Hint = 2,
        Broadcast = 4
    }
}
