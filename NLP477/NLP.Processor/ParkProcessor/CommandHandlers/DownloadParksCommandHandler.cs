
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using NLP.Processor.ParkProcessor.Commands;
using NLP.Repository.ParkRepository;
using NLP.Domain.Factories;

namespace NLP.Processor.ParkProcessor.CommandHandlers
{
    public class DownloadParksCommandHandler : Handles<DownloadParksCommand>
    {
        private IParkRepository repository;
        private ExceptionManager exManager;
        private IPlaceFactory placeFactory;

        public DownloadParksCommandHandler(IParkRepository repo, IPlaceFactory factory, ExceptionManager expMngr)
        {
            this.repository = repo;
            this.exManager = expMngr;
            this.placeFactory = factory;
        }

        public void Handle(DownloadParksCommand command)
        {
            exManager.Process(() => this.ProcessAction(command), "ProcessorPolicy");
        }

        private void ProcessAction(DownloadParksCommand command)
        {
            List<Park> parks = this.placeFactory.DownloadFromExternalSource(command.ParkDTO);
            this.repository.Add(parks);
        }

    }
}
    