using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Processor.ParkProcessor.Commands;
using NLP.Processor.ParkProcessor.CommandHandlers;
using NLP.DTO;
using NLP.DTO.Places;
using NLP.Repository.ParkRepository;

namespace NLP477.Tests.NLPLibTest
{
    [TestClass]
    public class TestDownloadCommand
    {
        [TestMethod]
        public void TestDownloadPark()
        { 
            var mockParkDTO = new Mock<ParkDTO>();
            var mockCommand = new Mock<DownloadParksCommand>(mockParkDTO, "admin");
            var mockParkRepo = new Mock<ParkRepository>();
            var mockHandler = new Mock<DownloadParksCommandHandler>(mockParkRepo);
        }
    }
}
