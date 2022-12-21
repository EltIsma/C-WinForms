using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwplab3
{
    public interface car_model
    {
        string Brand { get; set; }
        string model_name { get; set; }

        int Power { get; set; }
        int max_speed { get; set; }

         string type { get; set; }
    }
}
