using System.Collections.Generic;

namespace AlgorithmJSSP
{
    class Job
    {
        public int ArrivalTime { get; set; }
        public List<int> Time { get; set; }
        public Job(int arrivalTime, List<int> time)
        {
            this.ArrivalTime = arrivalTime;
            this.Time = time;
        }
    }
}