﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public enum CommandStatus
    {
        Created,
        Handled,
        RejectedNoHandler

    }
}
