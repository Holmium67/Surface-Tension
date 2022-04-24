using System.Collections.Generic;
using Exiled.Events.EventArgs;
using MEC;
using Surface_Tension.API;

namespace Surface_Tension
{ 
    public class EventHandler
    {
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }

        public void OnWarheadDetonation()
        {
            if (!Plugin.Instance.Config.EnableDelay)
                Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealDamage()));

            Timing.CallDelayed(Plugin.Instance.Config.DelayTime, () =>
            {
                Coroutines.Add(Timing.RunCoroutine(SurfaceTensionAPI.DealDamage()));
            });
        }
    }
}