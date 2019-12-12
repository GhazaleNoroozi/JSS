using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;

namespace AlgorithmJSSP.GeneticAlgorithm
{
    public class OperatorsStrategy : IOperatorsStrategy
    {
        public IList<IChromosome> Cross(IPopulation population, ICrossover crossover, float crossoverProbability, IList<IChromosome> parents)
        {
             var minSize = population.MinSize;
            var offspring = new List<IChromosome>(minSize);

            for (int i = 0; i < minSize; i += crossover.ParentsNumber)
            {
                var selectedParents = parents.Skip(i).Take(crossover.ParentsNumber).ToList();

                // If match the probability cross is made, otherwise the offspring is an exact copy of the parents.
                // Checks if the number of selected parents is equal which the crossover expect, because the in the end of the list we can
                // have some rest chromosomes.
                if (selectedParents.Count == crossover.ParentsNumber && RandomizationProvider.Current.GetDouble() <= crossoverProbability)
                    offspring.AddRange(crossover.Cross(selectedParents));
                else
                {
                    var left = crossover.ParentsNumber - selectedParents.Count;
                    for(int j = 0; j < left; j++)
                        offspring.Add(parents[RandomizationProvider.Current.GetInt(0, parents.Count)].Clone());
                }
            }
            
            return offspring;

        }

        public void Mutate(IMutation mutation, float mutationProbability, IList<IChromosome> chromosomes)
        {
            foreach(var c in chromosomes)
                mutation.Mutate(c, mutationProbability);
        }
    }
}