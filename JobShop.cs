using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmJSSP
{
    class JobShop
    {
        private string FilePath;

        //number of jobs
        public readonly int JNumber;
        
        //number of stations
        public readonly int WNumber;

        public List<Job> Jobs { get; set; }

        public JobShop(string filePath)
        {
            this.FilePath = filePath;
            this.Jobs = new List<Job>();
            
            using(StreamReader streamReader = new StreamReader(this.FilePath))
            {
                var num = (from str in streamReader.ReadLine().Split(' ') select int.Parse(str)).ToList();
                this.JNumber = num[0];
                this.WNumber = num[1];

                FillJobs(streamReader);
            }

        }

        private void FillJobs(StreamReader streamReader)
        {
            for(int i = 0; i < this.JNumber; i++)
            {
                var temp = (from str in streamReader.ReadLine().Split(' ') select int.Parse(str)).ToList();
                var tempFirst = temp.First();
                temp.RemoveAt(0);
                this.Jobs.Add(new Job(tempFirst, temp));
            }
        }
    }

}