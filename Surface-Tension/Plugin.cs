using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using System;

namespace Surface_Tension
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        private EventHandler events;

        public override string Name => "SurfaceTension";
        public override string Author => "Holmium67, updated by Heisenberg3666";
        public override Version Version => new Version(2, 2, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 1, 3);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            events = new EventHandler();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            events = null;
            Instance = null;
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Server.RoundStarted += events.OnRoundStart;
            Server.EndingRound += events.OnRoundEnd;
            Warhead.Detonated += events.OnWarheadDetonation;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= events.OnRoundStart;
            Server.EndingRound -= events.OnRoundEnd;
            Warhead.Detonated -= events.OnWarheadDetonation;
        }
    }
}