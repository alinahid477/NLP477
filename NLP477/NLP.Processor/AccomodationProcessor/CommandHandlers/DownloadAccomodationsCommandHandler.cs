using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using NLP.Domain;
using NLP.Domain.Factories;
using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using NLP.Processor.AccomodationProcessor.Commands;
using NLP.Repository.AccomodationRepository;
using NLP.Repository.ParkRepository;


namespace NLP.Processor.AccomodationProcessor.CommandHandlers
{
    public class DownloadAccomodationsCommandHandler : Handles<DownloadAccomodationsCommand>
    {
        private IAccomodationRepository repository;
        private IPlaceFactory placeFactory;
        private ExceptionManager exManager;

        public DownloadAccomodationsCommandHandler(IAccomodationRepository repo, IPlaceFactory factory, ExceptionManager expMngr)
        {
            this.repository = repo;
            this.exManager = expMngr;
            this.placeFactory = factory;
        }

        public void Handle(DownloadAccomodationsCommand command)
        {
            exManager.Process(() => this.ProcessAction(command), "ProcessorPolicy");
        }

        private void ProcessAction(DownloadAccomodationsCommand command)
        {
            List<Accomodation> accomodations = placeFactory.DownloadFromExternalSource(command.AccomodationDTO);
            this.repository.Add(accomodations);
        }


    }
}
    