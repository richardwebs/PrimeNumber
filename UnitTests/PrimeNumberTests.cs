using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimeLib;
using StructureMap;

namespace UnitTests
{
    [TestClass]
    public class PrimeNumberTests
    {
        private Mock<IContainer> _container;
        private IPrimeNumber _primeNumber;

        [TestInitialize]
        public void Initialize()
        {
            _container = new Mock<IContainer>();
            _container.Setup(x => x.GetInstance<IPrimeNumber>()).Returns(new PrimeNumber());
            _primeNumber = _container.Object.GetInstance<IPrimeNumber>();
        }

        [TestMethod]
        public void IsPrimeNumberExtension()
        {
            var answer = _primeNumber.IsPrimeNumber(2);
            Assert.IsTrue(answer);
            answer = _primeNumber.IsPrimeNumber(3);
            Assert.IsTrue(answer);
            answer = _primeNumber.IsPrimeNumber(4);
            Assert.IsFalse(answer);
            answer = _primeNumber.IsPrimeNumber(5);
            Assert.IsTrue(answer);
            answer = _primeNumber.IsPrimeNumber(10000);
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void GetNextPrimeNumber()
        {
            long inputLong = 2;
            var outputLong = _primeNumber.GetNextPrimeNumber(inputLong);
            Assert.AreEqual(outputLong, 3);

            inputLong = 7;
            outputLong = _primeNumber.GetNextPrimeNumber(inputLong);
            Assert.AreEqual(outputLong, 11);
        }

        [TestMethod]
        public void GetFirstNPrimeNumbers()
        {
            const int count = 10;
            var primeNumbers = _primeNumber.GetFirstNPrimeNumbers(count);
            Assert.IsNotNull(primeNumbers);
            Assert.AreEqual(primeNumbers.Count, count);
        }
    }
}
