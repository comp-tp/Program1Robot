using System;
using System.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        public abstract class Robot
        {
            public int[] Input { get; set; }
            public static int ChipsInstalled { get; protected set; } //Total count for unique chips installed

            public virtual int[] GetChipResult() //virtual method to be overridden by chip
            {
                return Input;
            }
        } 

        public class ChipSort : Robot //Chip for sorting Array
        {
            private static bool _installed = false;
           
            private ChipSort(){} //Private Constructor to not allow user Instatiate without Input
            public ChipSort(int[] input)
            {
                if(!_installed)
                {
                    _installed = true;
                    ChipsInstalled++;
                }
                Input = input; //Set up base Input
            }
            public override int[] GetChipResult()
            {
                return Input.OrderBy(x => x).ToArray();
            }
        }
        public class ChipSum : Robot //Chip for getting Sum of Array
        {
            private static bool _installed = false;

            private ChipSum() { } //Private Constructor to not allow user Instatiate without Input
            public ChipSum(int[] input)
            {
                if (!_installed)
                {
                    _installed = true;
                    ChipsInstalled++;
                }
                Input = input; //Set up base Input
            }
            public override int[] GetChipResult()
            {
                return new int[] { Input.Sum(x => x) };
            }
        }

        public class ChipMax : Robot //Chip for getting Sum of Array
        {
            private static bool _installed = false;

            private ChipMax() { } //Private Constructor to not allow user Instatiate without Input
            public ChipMax(int[] input)
            {
                if (!_installed)
                {
                    _installed = true;
                    ChipsInstalled++;
                }
                Input = input; //Set up base Input
            }
            public override int[] GetChipResult()
            {
                return new int[] { Input.OrderByDescending(x => x).FirstOrDefault() }; //Returns 0 if Input Array is empty
            }
        }
        static void Main(string[] args)
        {
            var inputArray = new int[] { 8, 20, 5, 2, 12, 1, 8 };
            Console.WriteLine(string.Format(@"Input Array - {0}", string.Join(",", inputArray)));

            Robot testRobot = new ChipSort(inputArray);//Only one Robot variable declared, Robots are expensive!!
            Console.WriteLine(string.Format(@"ChipSort Result - {0}", string.Join(",", testRobot.GetChipResult())));
            Console.WriteLine(string.Format(@"Unique Chips Installed - {0}", Robot.ChipsInstalled));

            testRobot = new ChipSum(inputArray);//ChipSum  Instantiation
            Console.WriteLine(string.Format(@"ChipSum Result - {0}", string.Join(",", testRobot.GetChipResult())));
            Console.WriteLine(string.Format(@"Unique Chips Installed - {0}", Robot.ChipsInstalled));

            testRobot = new ChipMax(inputArray);//ChipMax  Instantiation
            Console.WriteLine(string.Format(@"ChipMax Result - {0}", string.Join(",", testRobot.GetChipResult())));
            Console.WriteLine(string.Format(@"Unique Chips Installed - {0}", Robot.ChipsInstalled));

            testRobot = new ChipSum(inputArray);//ChipSum  Instantiation second time
            Console.WriteLine(string.Format(@"ChipSum Result - {0}", string.Join(",", testRobot.GetChipResult())));
            Console.WriteLine(string.Format(@"Unique Chips Installed - {0}", Robot.ChipsInstalled));
            
            Console.ReadKey();
        }
    }
}
