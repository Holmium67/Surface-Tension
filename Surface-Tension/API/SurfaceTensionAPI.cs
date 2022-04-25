using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace Surface_Tension.API
{
    public static class SurfaceTensionAPI
    {
        public static bool IsDetonated = false;

        public static float DamageCalculation(Player player)
        {
            if (Plugin.Instance.Config.IsDamagePercent)
                return (player.MaxHealth / 100) * Plugin.Instance.Config.Damage;
            return Plugin.Instance.Config.Damage;
        }

        public static IEnumerator<float> DealDamage()
        {
            while (true)
            {
                foreach (Player player in Player.List)
                {
                    if (!player.IsAlive)
                        continue;

                    if (player.Health > DamageCalculation(player))
                        player.Health -= DamageCalculation(player);
                    else
                        player.Kill("Died to radiation.");
                }

                yield return Timing.WaitForSeconds(Plugin.Instance.Config.TimeBetweenDamage);
            }
        }
    }
}
