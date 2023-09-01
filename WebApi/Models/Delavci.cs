using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Delavci
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime Datum_roj { get; set; }
        public string EMSO { get; set; }
        public string Delovno_mesto { get; set; }
    }
}
