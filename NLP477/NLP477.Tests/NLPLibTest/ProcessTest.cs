using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NLPLib.IO;
using NLPLib.Processors;
using NLPLib.Processors.Interfaces;

using Moq;
using NLPLib.JsonProcessor;

namespace NLP477.Tests.NLPLibTest
{
    [TestClass]
    public class ProcessTest
    {
        [TestMethod]
        public void ProcessParkTest()
        {
            var mockDataWriter = new Mock<ConsoleDataWriter>();
            var mockInputReader = new Mock<ReadFromFile>();
            ProcessParks processParksObj = new ProcessParks(mockDataWriter.Object, mockInputReader);
            processParksObj.JSON = "";

            Assert.IsTrue(this.ProcessPark(processParksObj));
            
        }

        public bool ProcessPark(IProcessor processor)
        {
            return processor.Process();
        }
    }
}
