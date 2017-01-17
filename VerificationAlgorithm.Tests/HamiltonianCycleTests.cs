namespace VerificationAlgorithm.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class HamiltonianCycleTests
    {
        int[,] _graph = CreateGraph();

        [Fact]
        public void GraphWithHamiltonianCycle()
        {
            var cycle1 = new List<int> { 0, 1, 5, 4, 2, 3, 0 };
            var cycle2 = new List<int> { 4, 5, 1, 3, 2, 0, 4 };

            var isHamiltonian1 = HamiltonianCycle.Verify(_graph, cycle1);
            var isHamiltonian2 = HamiltonianCycle.Verify(_graph, cycle2);

            isHamiltonian1.Should().BeTrue();
            isHamiltonian2.Should().BeTrue();
        }

        [Fact]
        public void CycleAndGraphHaveDifferentSizes()
        {
            var cycle1 = new List<int> { 0, 1, 2, 0 };
            var cycle2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 0 };

            var isHamiltonian1 = HamiltonianCycle.Verify(_graph, cycle1);
            var isHamiltonian2 = HamiltonianCycle.Verify(_graph, cycle2);

            isHamiltonian1.Should().BeFalse();
            isHamiltonian2.Should().BeFalse();
        }

        [Fact]
        public void SameSizesButDifferentFirstAndLastVertices()
        {
            var cycle = new List<int> { 0, 1, 5, 4, 2, 3, 1 };

            var isHamiltonian = HamiltonianCycle.Verify(_graph, cycle);

            isHamiltonian.Should().BeFalse();
        }

        [Fact]
        public void CycleDoesntCoverGraphConnections()
        {
            var cycle = new List<int> { 0, 5, 5, 4, 3, 2, 0 };

            var isHamiltonian = HamiltonianCycle.Verify(_graph, cycle);

            isHamiltonian.Should().BeFalse();
        }

        private static int[,] CreateGraph()
        {
            return new[,]
            {
                { 0, 1, 1, 1, 1, 0 },
                { 1, 0, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 1, 0 },
                { 1, 1, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 1 },
                { 0, 1, 0, 0, 1, 0 },
            };
        }
    }
}
