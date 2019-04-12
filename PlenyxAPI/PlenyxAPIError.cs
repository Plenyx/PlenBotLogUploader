using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIError
    {
        public int? code { get; set; }
        public string msg { get; set; } = "";
    }
}
