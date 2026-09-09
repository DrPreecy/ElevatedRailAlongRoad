using System.Collections.Generic;

namespace ElevatedRailAlongRoad
{
    public sealed class UndoState
    {
        public readonly List<ushort> CreatedSegments = new List<ushort>();
        public readonly List<ushort> CreatedNodes = new List<ushort>();

        public void Clear()
        {
            CreatedSegments.Clear();
            CreatedNodes.Clear();
        }
    }
}
