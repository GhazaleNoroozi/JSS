using System.Diagnostics;
using System.Linq;
using System;
using GeneticSharp.Domain;
using AlgorithmJSSP.GA;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Domain.Selections;

namespace AlgorithmJSSP
{
    class WorkloadGeneticAlgorithm
    {
        public readonly int IterationsCount;
        public readonly int AdaptiveStartingPoint;
        public readonly float MutationProbability;
        public readonly float CrossoverProbability;
        public readonly float ProbabilityDecreaseRate;
        public readonly float ProbabilityIncreaseRate;
        public readonly float MinProbability;
        public readonly float MaxProbability;
        public readonly int MinPopulation;
        public readonly int MaxPopulation;
        public JobShop JobShop;
        public Chromosome bestChromosome { get; set; }


        public WorkloadGeneticAlgorithm(JobShop jobshop, int iterationsCount, int adaptiveStartingPoint = 10, float crossoverProbability = 0.75f,
         float mutationProbability = 0.3f, float minProbability = 0.2f, float maxProbability = 0.5f,float probabilityDecreaseRate = 1.15f,
          float probabilityIncreaseRate = 1.01f, int minPopulation = 100, int maxPopulation = 100)
        {
            this.JobShop = jobshop;
            this.IterationsCount = iterationsCount;
            this.AdaptiveStartingPoint = adaptiveStartingPoint;
            this.CrossoverProbability = crossoverProbability;
            this.MutationProbability = mutationProbability;
            this.ProbabilityDecreaseRate = probabilityDecreaseRate;
            this.ProbabilityIncreaseRate = probabilityIncreaseRate;
            this.MinProbability = minProbability;
            this.MaxProbability = maxProbability;
            this.MinPopulation = minPopulation;
            this.MaxPopulation = maxPopulation;
        }

        public void Run()
        {
            for (int i = 0; i < IterationsCount; i++)
            {
                var adamChromosome = new Chromosome(this.JobShop);
                var population = new Population(this.MinPopulation, this.MaxPopulation, adamChromosome);
                var fitness = new Fitness();
                var selection;
                var crossover = new Crossover(new CycleCrossover());
                var mutation;
                var operatorStrategy = new OperatorsStrategy();
                var geneticAlgorithm = 
                    new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
                    {
                        Termination = new GenerationNumberTermination(),
                        MutationProbability = this.MutationProbability,
                        CrossoverProbability = this.CrossoverProbability,
                        OperatorsStrategy = operatorStrategy,
                        Reinsertion = new SurvivorSelection(new EliteSelection(),fitness)
                    };
                var stopwatch = new Stopwatch();



            }
        }


        public void AdaptMutationRate(GeneticAlgorithm geneticAlgorithm)
        {
            var best = geneticAlgorithm.BestChromosome;
            var recentGenerations = geneticAlgorithm.Population.Generations.Take(10).ToList();

            //Change nothing at early generations
            if (recentGenerations.Count < this.AdaptiveStartingPoint)
                return;

            var shouldIncrease = recentGenerations.All(g => Math.Abs(g.BestChromosome.Fitness.Value - best.Fitness.Value) < float.Epsilon);

            if (shouldIncrease) //Increase mutation rate
                geneticAlgorithm.MutationProbability = Math.Min(geneticAlgorithm.MutationProbability * this.ProbabilityIncreaseRate, this.MinProbability);
            else //Decrease mutation rate
                geneticAlgorithm.MutationProbability = Math.Max(geneticAlgorithm.MutationProbability * this.ProbabilityDecreaseRate, this.MaxProbability);
        }
    }
}