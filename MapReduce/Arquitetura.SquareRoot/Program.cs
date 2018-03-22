using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.SquareRoot
{
    class Program
    {
        public class SqrtMapper : MapperBase
        {

            public override void Map(string inputLine, MapperContext context)
            {
                int inputValue = int.Parse(inputLine);

                //Perform the work
                double sqtr = Math.Sqrt((double)inputValue);
                
                //write Output Data
                context.EmitKeyValue(inputValue.ToString(), sqtr.ToString());

            }
        }

        public class SqrtJob : HadoopJob<SqrtMapper>
        {
            public override HadoopJobConfiguration Configure(ExecutorContext context)
            {
                HadoopJobConfiguration config = new HadoopJobConfiguration();
                config.InputPath = "Input/sqrt";
                config.OutputFolder = "Output/sqrt";
                return config;
            }

        }

        static void Main(string[] args)
        {
            var hadoop = Hadoop.Connect();
            var result = hadoop.MapReduceJob.ExecuteJob<SqrtJob>();


        }
    }
}
