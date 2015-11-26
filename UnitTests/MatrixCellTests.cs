using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeLib;

namespace UnitTests
{
    [TestClass]
    public class MatrixCellTests
    {
        [TestMethod]
        public void CalculateValue()
        {
            var primeNumbers = new List<long> { 2, 3, 5 }; // note the zero at the front!
            IBaseMatrixCell cell = new BaseMatrixCell();

            // origin (top left of matrix)
            cell.CalculateValue(primeNumbers);
            var calculatedValue = cell.Value;
            Assert.AreEqual(calculatedValue, 0);
            Assert.AreEqual(cell.ColIndex, 0);
            Assert.AreEqual(cell.RowIndex, 0);

            // first column, second row
            var rowIndex = 1;
            var colIndex = 0;
            cell = new PrimeNumberRowHeader(rowIndex);
            cell.CalculateValue(primeNumbers);
            calculatedValue = cell.Value;
            Assert.AreEqual(calculatedValue, 2);
            Assert.AreEqual(cell.ColIndex, colIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex);

            // first row, second column
            rowIndex = 0;
            colIndex = 1;
            cell = new PrimeNumberColumnHeader(colIndex);
            cell.CalculateValue(primeNumbers);
            calculatedValue = cell.Value;
            Assert.AreEqual(calculatedValue, 2);
            Assert.AreEqual(cell.ColIndex, colIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex);

            // first row, third column
            rowIndex = 0;
            colIndex = 2;
            cell = new PrimeNumberColumnHeader(colIndex);
            cell.CalculateValue(primeNumbers);
            calculatedValue = cell.Value;
            Assert.AreEqual(calculatedValue, 3);
            Assert.AreEqual(cell.ColIndex, colIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex);

            // second row, third column
            rowIndex = 1;
            colIndex = 2;
            cell = new CalculatedCell(rowIndex, colIndex);
            cell.CalculateValue(primeNumbers);
            calculatedValue = cell.Value;
            Assert.AreEqual(calculatedValue, 6);
            Assert.AreEqual(cell.ColIndex, colIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex);
        }
    }
}

