using System.ComponentModel;

namespace Surface_Tension.Configs
{
    public sealed class DamageConfig
    {
        [Description("This is the time (seconds) you want to delay the damage for. Set to -1 to disable. Minimum is 0.5, maximum is 300")]
        public float DamageDelay { get; set; } = -1f;

        [Description("This is the amount you want to damage SCPs by. Set to -1 to disable.")]
        public int DamageScp { get; set; } = 5;

        [Description("This is the amount you want to damage players by. Set to -1 to disable.")]
        public int DamagePlayer { get; set; } = 1;

        [Description("This is the interval (seconds) that you want to damage players. Minimum is 0.5, maximum is 60")]
        public float DamageInterval { get; set; } = 1f;

        [Description("The type of damage done (HP or percentage of HP).")]
        public bool DamageIsPercent { get; set; } = false;
    }
}
