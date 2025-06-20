using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware
{
    internal class Program
    {
        static void Main(string[] args)
        {//Each year, n / 3 new llamas are born, and n / 4 llamas pass away.
            try
			{
                //  --COMENT THIS SECTION IF YOU WANT TO GET THE YEARS --
                //  FROM HERE--
               Console.WriteLine("Enter the years");
               int years = Convert.ToInt32(Console.ReadLine());
                //  --TO HERE

                Console.WriteLine("Enter the the start Size of the population of llamas (>=9)");
                bool notHigherThanNine = true;
                int StartSize = 0;


                    while (notHigherThanNine)// this is a boolean flag. Will ocurre till is false
                    {
                    StartSize = Convert.ToInt32(Console.ReadLine());
                        if(StartSize>9) //restriction
                        notHigherThanNine = false;
                     }

                // -- DISCOMENT THIS SECTION IF YOU WANT TO GET THE YEARS: --
                //FROM HERE--
                /*Console.WriteLine("Enter the end size population: "); 
                int EndSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("For the Llamas to reach that population would take: " +
                CalculateYears(StartSize, EndSize) + " years");*/
                // --TO HERE


                // -- IF YOU WANT TO GET THE FINAL POPULATION --
                //DISCOMENT FROM HERRE --
                Console.WriteLine("at the end the population of llamas would be: " + 
                    CalculateEndPopulation(years, StartSize));
       

            }
			catch (Exception ex)
			{
                Console.WriteLine("Error:"+ ex.Message);
			}
        }

        static int CalculateEndPopulation(int years, int StartSize)
        {
            decimal EndPopulation = StartSize; 

            for (int i = 0; i < years; i++)
            {
                decimal born = EndPopulation / 3; 
                decimal pass = EndPopulation / 4;

                EndPopulation += born - pass; //this adds a value to a variable and assigns the result because each year the
                                              //start size increments

            }
            return (int)Math.Truncate(EndPopulation); //better to truncate at the end to not lose decimals in the process
        }

        static int CalculateYears(int StartSize, int EndSize)
        {
            // 1 year =  / 3 new llamas are born, and n / 4 llamas pass away. cuanto tiempo le lleva pasar de startSize a
            //endSize
            int Years = 0;
            decimal CurrentPopulation = StartSize; 

            while (CurrentPopulation <= EndSize)
            {
                decimal born = CurrentPopulation / 3;
                decimal pass = CurrentPopulation / 4;

                CurrentPopulation += born - pass; // is like doing CurrentPopulation = CurrentPopulation + born - pass;  
                //adds a value to a variable and assigns the result to that variable.
                 Years++; //this is like doing =+1;
            }
            return Years;

        }
    }
}
