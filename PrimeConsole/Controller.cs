using PrimeLib;

namespace PrimeConsole
{
    public interface IController
    {
        void CalculateValues(int matrixSize);
        void WriteCsvFile();
    }

    public class Controller : IController
    {
        private readonly IMatrix _matrix;
        private readonly ICsvWriter _csvWriter;

        public Controller(IMatrix matrix, ICsvWriter csvWriter)
        {
            _matrix = matrix;
            _csvWriter = csvWriter;
        }

        public void CalculateValues(int matrixSize)
        {
            _matrix.CreateEmptyMatrix(matrixSize);
            _matrix.SetOriginValue();
            _matrix.SetFirstColumnValues();
            _matrix.SetFirstRowValues();
            _matrix.SetCalculatedValues();
        }

        public void WriteCsvFile()
        {
            const string filename = "matrix.csv";
            _csvWriter.WriteCsvFile(filename, _matrix.MatrixValues);
        }
    }
}

