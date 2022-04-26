using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Surface_Tension.API;

namespace Surface_Tension
{
    public class EventHandler
    {
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

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

            if (Plugin.Instance.Config.EnableDelay)
            {
                Timing.CallDelayed(Plugin.Instance.Config.DelayTime, () =>
                {
                    Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealDamage()));
                });
            }
            else
            {
                Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealDamage()));
            }

            if (Plugin.Instance.Config.EnableDelay && Plugin.Instance.Config.CassieAnnounce)
            {
                Timing.CallDelayed(Plugin.Instance.Config.DelayTime, () =>
                {
                    Cassie.MessageTranslated(Plugin.Instance.Config.CassieText, Plugin.Instance.Config.CassieSubtitles);
                });
            }
            else if (Plugin.Instance.Config.CassieAnnounce)
            {
                Cassie.MessageTranslated(Plugin.Instance.Config.CassieText, Plugin.Instance.Config.CassieSubtitles, true);
            }
        }
    }
}