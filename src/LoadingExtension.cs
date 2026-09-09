using ICities;
using UnityEngine;

namespace ElevatedRailAlongRoad
{
    public sealed class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            Debug.Log("[ElevatedRailAlongRoad] Loaded.");
            // MVP TODO:
            // Initialize the runtime tool here only after the minimal build works.
        }

        public override void OnLevelUnloading()
        {
            Debug.Log("[ElevatedRailAlongRoad] Unloaded.");
        }
    }
}
