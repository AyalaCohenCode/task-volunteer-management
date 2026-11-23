using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public record TaskToShow(int id,string type, string TaskDescription, string DateAndTime, string Address,string status);

}
