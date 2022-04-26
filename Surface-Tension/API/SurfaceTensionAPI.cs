using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using Surface_Tension.API.Enums;
using Surface_Tension.Configs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Surface_Tension.API
{
    public static class SurfaceTensionAPI
    {
        public static bool IsDetonated = false;
        public static BaseConfig Config = Plugin.Instance.Config;

        public static void Announce()
        {
            if (Config.Announcement.AnnouncementType == AnnouncementType.None)
                return;

            if (Config.Announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie))
            {
                if (Config.Announcement.CassieDetonation.CassieTime == -1f)
                {
                    Cassie.MessageTranslated(Config.Announcement.CassieDetonation.CassieText, Config.Announcement.CassieDetonation.CassieSubtitles);
                    Log.Debug("Created CASSIE announcement.", Config.DebugMode);
                }
                else
                {
                    Timing.CallDelayed(Mathf.Clamp(Config.Announcement.CassieDetonation.CassieTime, 0.5f, 300f), () =>
                    {
                        Cassie.MessageTranslated(Config.Announcement.CassieDetonation.CassieText, Config.Announcement.CassieDetonation.CassieSubtitles);
                        Log.Debug("Created CASSIE announcement.", Config.DebugMode);
                    });
                }
            }

            if (Config.Announcement.AnnouncementType.HasFlag(AnnouncementType.Hint))
            {
                foreach (Player player in Player.List)
                {
                    if (Config.Announcement.HintDetonation.HintTime == -1f)
                    {
                        player.ShowHint(Config.Announcement.HintDetonation.HintText, 10f);
                    }
                    else
                    {
                        Timing.CallDelayed(Config.Announcement.HintDetonation.HintTime, () =>
                        {
                            player.ShowHint(Config.Announcement.HintDetonation.HintText, 10f);
                        });
                    }
                }
                Log.Debug("Created Hint announcement.", Config.DebugMode);
            }

            if (Config.Announcement.AnnouncementType.HasFlag(AnnouncementType.Broadcast))
            {
                foreach (Player player in Player.List)
                {
                    if (Config.Announcement.BroadcastDetonation.BroadcastTime == -1f)
                    {
                        player.Broadcast(10, Config.Announcement.BroadcastDetonation.BroadcastText);
                    }
                    else
                    {
                        Timing.CallDelayed(Config.Announcement.BroadcastDetonation.BroadcastTime, () =>
                        {
                            player.Broadcast(10, Config.Announcement.BroadcastDetonation.BroadcastText);
                        });
                    }
                }
                Log.Debug("Created Broadcast announcement.", Config.DebugMode);
            }
        }

        public static float DamageCalculation(Player player)
        {
            if (player.Role.Side == Side.Scp) {
                if (Config.Damage.DamageIsPercent)
                    return (player.MaxHealth / 100) * Config.Damage.DamageScp;
                return Config.Damage.DamageScp;
            }
            else
            {
                if (Config.Damage.DamageIsPercent)
                    return (player.MaxHealth / 100) * Config.Damage.DamagePlayer;
                return Config.Damage.DamagePlayer;
            }
        }

        public static IEnumerator<float> DealPlayerDamage()
        {
            while (true)
            {
                foreach (Player player in Player.List)
                {
                    if (!player.IsAlive || player.IsGodModeEnabled)
                        continue;

                    if (player.Health > DamageCalculation(player))
                        player.Health -= DamageCalculation(player);
                    else
                        player.Kill("Died to radiation.");
                }

                yield return Timing.WaitForSeconds(Config.Damage.DamageInterval);
            }
        }
    }
}
