using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Shared.Services
{
    public class DateTimeService : IDateTimeServices
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
