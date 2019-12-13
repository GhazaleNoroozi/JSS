
using GeneticSharp.Domain.Chromosomes;

namespace AlgorithmJSSP.GA
{
    public class Chromosome : ChromosomeBase
    {
        public Chromosome(int length) : base(length)
        {
            throw new System.NotImplementedException();
        }

        public int TheLength { get; set; }

        public override IChromosome CreateNew()
        {
            throw new System.NotImplementedException();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}