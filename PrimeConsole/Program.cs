using System;
using PrimeLib;

namespace PrimeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer number, for example '4': ");
            var inputString = Console.ReadLine();
            var inputInt = Convert.ToInt32(inputString);

            IPrimeNumber primeNumber = new PrimeNumber();
            IMatrix matrix = new Matrix(primeNumber);
            ICsvWriter csvWriter = new CsvWriter();
            IController controller = new Controller(matrix, csvWriter);

            var matrixSize = inputInt;
            controller.CalculateValues(matrixSize);
            controller.WriteCsvFile();
            Console.WriteLine("A CSV file 'matrix.csv' has been generated; press any key to exit.");
            Console.ReadKey();
        }
    }
}
