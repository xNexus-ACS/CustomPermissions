using Exiled.API.Features;
using System;
using HarmonyLib;

namespace CustomPermissions
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;

        public override string Name { get; } = "CustomPermissions";
        public override string Author { get; } = "xNexus-ACS";
        public override string Prefix { get; } = "custom_permissions";
        public override Version Version { get; } = new Version(0, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        public Harmony Harmony { get; private set; }
        private int patchCounter;

        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
            
            this.Patch();
            Log.Info($"[OnEnabled] CustomPermissions(Ver{Version}) Enabled Complete.");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Singleton = null;
            
            this.Unpatch();
            Log.Info($"[OnDisabled] CustomPermissions(Ver{Version}) Disabled Complete.");
        }
        private void Patch()
        {
            try
            {
                Harmony = new Harmony(Author + "." + Name + ++patchCounter);
                Harmony.DEBUG = false;
                Harmony.PatchAll();
            }
            catch(Exception ex)
            {
                Log.Error($"[Patch] Patching Failed : {ex}");
            }
        }

        private void Unpatch()
        {
            try
            {
                Harmony.UnpatchAll(this.Harmony.Id);
            }
            catch(Exception ex)
            {
                Log.Error($"[Unpatch] Unpatching Failed : {ex}");
            }
        }
    }
}