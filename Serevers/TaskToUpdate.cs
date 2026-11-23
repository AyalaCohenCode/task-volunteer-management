using Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public record TaskToUpdate(string? Type, string? TaskDescription, string? DateAndTime, string? Address, string? status);

    
}
