using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Reinsertions;

namespace AlgorithmJSSP.GA
{
    public class SurvivorSelection : ReinsertionBase
    {
        public SurvivorSelection(bool canCollapse, bool canExpand) : base(canCollapse, canExpand)
        {
            throw new System.NotImplementedException();
        }

        protected override IList<IChromosome> PerformSelectChromosomes(IPopulation population, IList<IChromosome> offspring, IList<IChromosome> parents)
        {
            throw new System.NotImplementedException();
        }
    }
}