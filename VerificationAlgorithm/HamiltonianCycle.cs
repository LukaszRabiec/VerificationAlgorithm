using System.Collections.Generic;

namespace VerificationAlgorithm
{
    using System.Linq;

    public static class HamiltonianCycle
    {
        private static int _graphSize;
        private static int _cycleSize;

        public static bool Verify(int[,] graphMatrix, List<int> cycleTestimony)
        {
            _graphSize = graphMatrix.GetLength(0);
            _cycleSize = cycleTestimony.Count;

            if (HaveDifferentSize())
            {
                return false;
            }

            if (FirstAndLastCycleVerticeAreDifferent(cycleTestimony))
            {
                return false;
            }

            if (CycleDoesntCoverGraphConnections(graphMatrix, cycleTestimony))
            {
                return false;
            }

            return CycleVerticesAppearsOnlyOnce(cycleTestimony);
        }

        private static bool HaveDifferentSize()
        {
            return _graphSize + 1 != _cycleSize;
        }

        private static bool FirstAndLastCycleVerticeAreDifferent(List<int> cycle)
        {
            int firstVertice = cycle[0];
            int lastVertice = cycle[_cycleSize - 1];

            return firstVertice != lastVertice;
        }

        private static bool CycleDoesntCoverGraphConnections(int[,] graph, List<int> cycle)
        {
            for (int i = 1; i < _cycleSize; i++)
            {
                if (graph[cycle[i - 1], cycle[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CycleVerticesAppearsOnlyOnce(List<int> cycle)
        {
            var counter = new int[cycle.Count - 1];

            for (int vertice = 0; vertice < counter.Length; vertice++)
            {
                counter[vertice]++;
            }

            return counter.All(x => x == 1);
        }
    }
}
