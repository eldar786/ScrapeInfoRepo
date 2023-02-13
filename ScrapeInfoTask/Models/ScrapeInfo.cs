using System;
using System.Collections.Generic;

#nullable disable

namespace ScrapeInfoTask.Models
{
    public partial class ScrapeInfo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string MarketCap { get; set; }
        public DateTime? YearFounded { get; set; }
        public int? NumOfEmp { get; set; }
        public string Headquarters { get; set; }
        public DateTime DateTime { get; set; }
        public int? PreviousClosePrice { get; set; }
        public int? OpenPrice { get; set; }
    }
}
