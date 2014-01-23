using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NLPLib.IO.Interfaces;
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
            var mockDataWriter = new Mock<IWriteData>();
            
            ProcessParks processParksObj = new ProcessParks(mockDataWriter.Object);
            processParksObj.JSON = "";

            Assert.IsTrue(this.ProcessPark(processParksObj));
            
        }

        public bool ProcessPark(IProcessor processor)
        {
            return processor.Process();
        }
    }
}
