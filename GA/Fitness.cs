using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace AlgorithmJSSP.GA
{
    public class Fitness : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            return Evaluate((Chromosome) chromosome);
        }
        public double Evaluate(Chromosome chromosome)
        {
            if(chromosome.Fitness != null)
                return chromosome.Fitness.Value;
            
            chromosome.TheLength = CalculateLength();
            chromosome.Fitness = 1 / (chromosome.Length + 1);
            return chromosome.Fitness.Value;
        }

        public int CalculateLength()
        {
            throw new System.NotImplementedException();
        }
    }
}