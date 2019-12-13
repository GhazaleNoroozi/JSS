using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;

namespace AlgorithmJSSP.GA
{
    public class Crossover : ICrossover
    {

        public int ParentsNumber => throw new System.NotImplementedException();

        public int ChildrenNumber => throw new System.NotImplementedException();

        public int MinChromosomeLength => throw new System.NotImplementedException();

        public bool IsOrdered => throw new System.NotImplementedException();

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            throw new System.NotImplementedException();
        }
    }
}