using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.AccomodationProcessor.Commands
{
    public class DownloadAccomodationsCommand : AbstractCommand, ICommand
    {
        public AccomodationDTO AccomodationDTO { get; set; }
        public DownloadAccomodationsCommand(AccomodationDTO dto, string userId)
        {
            this.AccomodationDTO = dto;
            this.actor = userId;
        }
    }
}
