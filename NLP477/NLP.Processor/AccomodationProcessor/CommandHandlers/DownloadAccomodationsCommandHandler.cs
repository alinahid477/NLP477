using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using NLP.Domain.Logic;
using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using NLP.Processor.AccomodationProcessor.Commands;
using NLP.Repository.AccomodationRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.AccomodationProcessor.CommandHandlers
{
    public class DownloadAccomodationsCommandHandler : Handles<DownloadAccomodationsCommand>
    {
        private IAccomodationRepository repository;
        private ExceptionManager exManager;

        public DownloadAccomodationsCommandHandler(IAccomodationRepository repo, ExceptionManager expMngr)
        {
            this.repository = repo;
            this.exManager = expMngr;
        }

        public void Handle(DownloadAccomodationsCommand command)
        {
            exManager.Process(() => this.ProcessAction(command), "ProcessorPolicy");
        }

        private void ProcessAction(DownloadAccomodationsCommand command)
        {
            AccomodationLogic logic = new AccomodationLogic();
            logic.DownloadFromExternalSource(command.AccomodationDTO);
            this.repository.AddBulk(logic);
        }

    }
}
    