using System;
using System.Diagnostics;
using System.Globalization;

namespace primes // This is a new version for git! Run this in the command prompt (old school)
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();// used to time the main algorithm
            NumberFormatInfo nfi = new CultureInfo("en-CA").NumberFormat; //for thousands commas
	    Console.WriteLine("Find primes\n");
            int max, upperBoundry, chk;
            double maxD;
            string maxS, listem;
            Console.Write("Please give a maximum number -> ");
            maxS = Console.ReadLine();
            max = int.Parse(maxS);
            maxD = max;
            upperBoundry = (int)(Math.Floor(Math.Sqrt(maxD)));
            Console.WriteLine("The highest number would be {0}.", max.ToString("N0", nfi));// the output args are zero based
            Console.WriteLine("The floor of the square root of which is {0}.\n", upperBoundry.ToString("N0", nfi));
            Console.Write("Shall I list all the primes? yes or no -> ");
            listem = Console.ReadLine();
            Console.WriteLine();
	    stopwatch.Start();
            int[] nums = new int[max + 1];
	    int count = 0;
            for(int x = 2; x <= max; x++)
            {
                nums[x] = x;
            }
            for (int x = 2; x <= upperBoundry; x++)
            {
                chk = x;
                do
                {
                    if (nums[chk] % x == 0 && nums[chk] != x)
                    {
                        nums[chk] = 0;
                    }
                    chk++;
                } while (chk <= max);
            }
	    stopwatch.Stop();
            for(int z = 2; z<= max; z++)
            {
                if (nums[z] != 0)
		{
                    if(listem == "yes")
                    {
                        Console.WriteLine("{0} is prime.", nums[z].ToString("N0", nfi));
                    }
			count++;
		}
            }
		TimeSpan ts = stopwatch.Elapsed;
		string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10); //create a human readable time
            
		Console.WriteLine("RunTime = " + elapsedTime + "!");
            	Console.WriteLine("There are {0} prime numbers below {1}.",
                count.ToString("N0", nfi),
                max.ToString("N0", nfi));

            	long prSum = 0;
		foreach (int x in nums)
            {
                prSum += x;
            }
            Console.Write("The sum of all those is {0}.",prSum.ToString("N0", nfi));
        }
    }
}
