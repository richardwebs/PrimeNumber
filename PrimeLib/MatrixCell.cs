using System.Collections.Generic;
namespace PrimeLib
{
    public interface IBaseMatrixCell
    {
        int RowIndex { get; set; } // zero-based: left to right, top to bottom
        int ColIndex { get; set; } // zero-based: left to right, top to bottom
        long Value { get; set; }
        void CalculateValue(List<long> primeNumbers);
    }

    public class BaseMatrixCell : IBaseMatrixCell // top left cell of matrix (no value essentially)
    {
        public int RowIndex { get; set; } // zero-based: left to right, top to bottom
        public int ColIndex { get; set; } // zero-based: left to right, top to bottom
        public long Value { get; set; }

        public BaseMatrixCell()
        {
            RowIndex = 0;
            ColIndex = 0;
        }

        public virtual void CalculateValue(List<long> primeNumbers)
        {
            Value = 0;
        }
    }

    public class PrimeNumberRowHeader : BaseMatrixCell // vertical first column in the matrix
    {
        public PrimeNumberRowHeader(int rowIndex)
        {
            RowIndex = rowIndex;
            ColIndex = 0;
        }

        public override void CalculateValue(List<long> primeNumbers)
        {
            Value = primeNumbers[RowIndex - 1];
        }
    }

    public class PrimeNumberColumnHeader : BaseMatrixCell // horizontal first row in the matrix
    {
        public PrimeNumberColumnHeader(int colIndex)
        {
            RowIndex = 0;
            ColIndex = colIndex;
        }

        public override void CalculateValue(List<long> primeNumbers)
        {
            Value = primeNumbers[ColIndex - 1];
        }
    }

    public class CalculatedCell : BaseMatrixCell // calculated cell, not the first row or column in the matrix
    {
        public CalculatedCell(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
        }

        public override void CalculateValue(List<long> primeNumbers)
        {
            Value = primeNumbers[RowIndex - 1] * primeNumbers[ColIndex - 1];
        }
    }
}

