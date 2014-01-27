using NLP.DTO.Places;
using NLP.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.ParkProcessor.Commands
{
    public class DownloadParksCommand : AbstractCommand, ICommand
    {
        public ParkDTO ParkDTO { get; set; }
        public DownloadParksCommand(ParkDTO dto, string userId)
        {
            this.ParkDTO = dto;
            this.actor = userId;
        }
    }
}
