using System.Collections.Generic;

namespace ElevatedRailAlongRoad
{
    public sealed class SelectionState
    {
        private readonly List<ushort> _segmentIds = new List<ushort>();

        public IReadOnlyList<ushort> SegmentIds => _segmentIds;

        public void Clear() => _segmentIds.Clear();

        public void Add(ushort segmentId)
        {
            if (segmentId == 0 || _segmentIds.Contains(segmentId))
                return;

            _segmentIds.Add(segmentId);
        }
    }
}
