using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Hospital
    {
        public int hospitalid { get; set; }
        public int userid { get; set; }
        public string hospitalname { get; set; }
        public string address { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public int isprimary { get; set; }
    }
}
