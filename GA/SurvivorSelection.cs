using System.Collections.Generic;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Reinsertions;

namespace AlgorithmJSSP.GA
{
    public class SurvivorSelection : ReinsertionBase
    {

        public ISelection Selection;
        public IFitness Fitness;

        public SurvivorSelection(ISelection eliteSelection, IFitness fitness) : base(true, true)
        {
            this.Selection = eliteSelection;
            this.Fitness = fitness;
        }

        protected override IList<IChromosome> PerformSelectChromosomes(IPopulation population, IList<IChromosome> offspring, IList<IChromosome> parents)
        {
            throw new System.NotImplementedException();
        }
    }
}