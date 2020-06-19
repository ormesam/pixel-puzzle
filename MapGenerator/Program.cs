using System;

namespace MapGenerator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello! Welcome to the Pixel Puzzle Generator");

            Console.WriteLine("What size of puzzle would you like to generate? (8 - 15)");
            int size = GetNumber(8, 15);

            Console.WriteLine("How difficult should these puzzles be? (1 - 3)");
            int difficulty = GetNumber(1, 3);

            Console.WriteLine("How many puzzles should be generated?");
            int numberToCreate = GetNumber(1, 100);

            Generator generator = new Generator(size, difficulty);
            generator.Run(numberToCreate);

            Console.WriteLine("Press any key to quit...");
            Console.ReadLine();
        }

        private static int GetNumber(int lowerBound, int upperBound) {
            int number = -1;

            while (number < lowerBound || number > upperBound) {
                int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}
