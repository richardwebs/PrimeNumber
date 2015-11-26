using System.Collections.Generic;

namespace PrimeLib
{
    public interface IMatrix
    {
        long[,] MatrixValues { get; set; } // this is the matrix of long values in a double array
        void CreateEmptyMatrix(int matrixSize); // this initializes the matrix with values set all to zero
        void SetOriginValue(); // sets the top left cell of the matrix, with zero as a value
        void SetFirstRowValues(); // sets the top row of the matrix to prime numbers
        void SetFirstColumnValues(); // sets the left column of the matrix to prime numbers
        void SetCalculatedValues(); // sets the rest of the cells in the table; depends on the first row and first column to be set
    }

    public class Matrix : IMatrix
    {
        private readonly IPrimeNumber _primeNumber;
        protected int MatrixSize { get; set; }
        protected List<long> PrimeNumbers { get; set; }
        public long[,] MatrixValues { get; set; }

        public Matrix(IPrimeNumber primeNumber)
        {
            _primeNumber = primeNumber;
        }

        public void CreateEmptyMatrix(int matrixSize)
        {
            MatrixSize = matrixSize;
            MatrixValues = new long[matrixSize + 1, matrixSize + 1];
            PrimeNumbers = _primeNumber.GetFirstNPrimeNumbers(matrixSize);
        }

        public void SetOriginValue() // origin cell
        {
            var cell = new BaseMatrixCell();
            SetValue(cell);
        }

        public void SetFirstRowValues() // first row
        {
            for (var colIndex = 1; colIndex < MatrixSize + 1; colIndex++) SetValue(new PrimeNumberColumnHeader(colIndex));
        }

        public void SetFirstColumnValues() // first column
        {
            for (var rowIndex = 1; rowIndex < MatrixSize + 1; rowIndex++) SetValue(new PrimeNumberRowHeader(rowIndex));
        }

        public void SetCalculatedValues() // rest of values - not first row or first column
        {
            for (var rowIndex = 1; rowIndex < MatrixSize + 1; rowIndex++)
            {
                for (var colIndex = 1; colIndex < MatrixSize + 1; colIndex++) SetValue(new CalculatedCell(rowIndex, colIndex));
            }
        }

        private void SetValue(IBaseMatrixCell cell)
        {
            cell.CalculateValue(PrimeNumbers);
            MatrixValues[cell.RowIndex, cell.ColIndex] = cell.Value;
        }
    }
}

