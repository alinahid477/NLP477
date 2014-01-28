using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Newtonsoft.Json;
using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using NLP.Processor.ParkProcessor.Commands;
using NLP.Repository.ParkRepository;
using System;
using System.Collections.Generic;
using System.IO;
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
            exManager.Process(() => this.ProcessAction(command), "ProcessorPolicy");
        }

        private void ProcessAction(DownloadParksCommand command)
        {
            string downloadedtext = null;
            if (command.ParkDTO.DownloadURL.Contains("http"))
                downloadedtext = Utils.Utility.DownloadFromURL(command.ParkDTO.DownloadURL);
            else
                downloadedtext = Utils.Utility.DownloadFromFile(command.ParkDTO.DownloadURL);

            List<ParkDTO> list = JsonConvert.DeserializeObject<List<ParkDTO>>(downloadedtext);
            List<Park> parkList = new List<Park>();
            foreach (ParkDTO dto in list)
            {
                Park x = new Park();
                x.CreateFromDTO(dto.ParkName, dto.ParkCODE, dto.ParkDesciption);
                parkList.Add(x);
            }
            this.repository.AddBulk(parkList);

        }

    }
}
    