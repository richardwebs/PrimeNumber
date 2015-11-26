using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimeLib;
using StructureMap;

namespace UnitTests
{
    [TestClass]
    public class MatrixTests
    {
        private Mock<IContainer> _container;
        private IMatrix _matrix;
        private IPrimeNumber _primeNumber;

        [TestInitialize]
        public void Inititialize()
        {
            _container = new Mock<IContainer>();
            _container.Setup(x => x.GetInstance<IPrimeNumber>()).Returns(new PrimeNumber());
            _primeNumber = _container.Object.GetInstance<IPrimeNumber>();
            _container.Setup(x => x.GetInstance<IMatrix>()).Returns(new Matrix(_primeNumber));
            _matrix = _container.Object.GetInstance<IMatrix>();
        }

        [TestMethod]
        public void CalculateValues()
        {
            const int matrixSize = 3; // that means 4 rows and 4 columns

            _matrix.CreateEmptyMatrix(matrixSize); // create matrix with 4 rows, 4 columns, 16 values in total
            Assert.IsNotNull(_matrix.MatrixValues);

            Assert.AreEqual(_matrix.MatrixValues.GetUpperBound(0), matrixSize);
            Assert.AreEqual(_matrix.MatrixValues.GetUpperBound(1), matrixSize);
            Assert.AreEqual(_matrix.MatrixValues.Length, 16);

            _matrix.SetOriginValue(); // set the first cell

            _matrix.SetFirstRowValues(); // set the values for the first row to prime numbers

            _matrix.SetFirstColumnValues(); // set the values of the first column to prime numbers

            _matrix.SetCalculatedValues(); // calculate the values for the remaining cells

            Assert.AreEqual(_matrix.MatrixValues[0, 0], 0);
            Assert.AreEqual(_matrix.MatrixValues[0, 1], 2);
            Assert.AreEqual(_matrix.MatrixValues[0, 2], 3);
            Assert.AreEqual(_matrix.MatrixValues[0, 3], 5);

            Assert.AreEqual(_matrix.MatrixValues[1, 0], 2);
            Assert.AreEqual(_matrix.MatrixValues[1, 1], 4);
            Assert.AreEqual(_matrix.MatrixValues[1, 2], 6);
            Assert.AreEqual(_matrix.MatrixValues[1, 3], 10);

            Assert.AreEqual(_matrix.MatrixValues[2, 0], 3);
            Assert.AreEqual(_matrix.MatrixValues[2, 1], 6);
            Assert.AreEqual(_matrix.MatrixValues[2, 2], 9);
            Assert.AreEqual(_matrix.MatrixValues[2, 3], 15);

            Assert.AreEqual(_matrix.MatrixValues[3, 0], 5);
            Assert.AreEqual(_matrix.MatrixValues[3, 1], 10);
            Assert.AreEqual(_matrix.MatrixValues[3, 2], 15);
            Assert.AreEqual(_matrix.MatrixValues[3, 3], 25);
        }
    }
}

