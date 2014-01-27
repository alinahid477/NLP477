using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using NLP.Infrastructure.Commands;
using NLP.Processor.ParkProcessor.Commands;
using NLP.Repository.ParkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.ParkProcessor.CommandHandlers
{
    public class DownloadParksCommandHandler : Handles<DownloadParksCommand>
    {
        private IParkRepository repository;
        private ExceptionManager exManager;

        public DownloadParksCommandHandler(IParkRepository repo, ExceptionManager expMngr)
        {
            this.repository = repo;
            this.exManager = expMngr;
        }

        public void Handle(DownloadParksCommand command)
        {
            exManager.Process(() => {
                string downloadedJSON = Utils.Utility.DownloadFromURL(command.ParkDTO.DownloadURL); 
            }, "ProcessorPolicy");
        }
    }
}
    