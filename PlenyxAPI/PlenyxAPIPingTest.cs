using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingTest
    {
        public PlenyxAPIStatus status { get; set; }
        public PlenyxAPIError error { get; set; }

        public bool IsValid() => (status?.code ?? 400) == 200;
    }
}
