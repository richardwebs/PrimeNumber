using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimeLib;
using StructureMap;

namespace UnitTests
{
    [TestClass]
    public class CsvWriterTests
    {
        private Mock<IContainer> _container;
        private ICsvWriter _csvWriter;

        [TestInitialize]
        public void Initialize()
        {
            _container = new Mock<IContainer>();
            _container.Setup(x => x.GetInstance<ICsvWriter>()).Returns(new CsvWriter());
            _csvWriter = _container.Object.GetInstance<ICsvWriter>();
        }

        [TestMethod]
        public void WriteCsvFile()
        {
            var array = new long[,] { { 10, 20, 30 }, { 40, 50, 60 } };
            _csvWriter.WriteCsvFile("test.csv", array);
        }
    }
}

