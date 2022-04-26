using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Surface_Tension.API;
using Surface_Tension.Configs;
using UnityEngine;

namespace Surface_Tension
{
    public class EventHandler
    {
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        private BaseConfig Config = Plugin.Instance.Config;

        public void OnRoundStart()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
            Coroutines.Clear();

            SurfaceTensionAPI.IsDetonated = false;
        }

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
            Coroutines.Clear();
        }

        public void OnWarheadDetonation()
        {
            if (SurfaceTensionAPI.IsDetonated)
                return;

            SurfaceTensionAPI.IsDetonated = true;

            if (Config.Damage.DamageDelay == -1f)
            {
                Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealPlayerDamage()));
                SurfaceTensionAPI.Announce();
            }
            else
            {
                Timing.CallDelayed(Mathf.Clamp(Config.Damage.DamageDelay, 0.5f, 300f), () =>
                {
                    Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealPlayerDamage()));
                    SurfaceTensionAPI.Announce();
                });
            }
        }
    }
}