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

using Ninject;
using NLP.Processor.Loggers;
using NLP.Infrastructure.Commands;
using Ninject.Web.Common;
using System.Configuration;
namespace NLP477.Tests.NLPLibTest
{
    [TestClass]
    public class TestDownloadCommand
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private IKernel kernel;
        [TestInitialize]
        public void TestDownloadCommandInitialize()
        {
            
            this.kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            this.kernel.Load(new NLP.Processor.Binder());
            
        }

        [TestMethod]
        public void TestDownloadPark()
        {
            ParkDTO dto = new ParkDTO();
            
            DownloadParksCommand command = new DownloadParksCommand(dto, "admin");
            var mockLogger = new Mock<CommandLogger>();
            
            CommandBus bus = new CommandBus(kernel, null);
            bus.Send(command);
            /*var mockParkRepo = new Mock<ParkRepository>();
            var mockHandler = new Mock<DownloadParksCommandHandler>(mockParkRepo);
            mockHandler.Object.Handle(mockCommand);*/

        }

        [TestMethod]
        public void TestConfigurationManager()
        {
            //Error when I declare ConfigurationManager
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["NLPDataContext"].ConnectionString);
        }
    }
}
