using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace rwplab3
{
    public class car : car_model
    {
      
        public string Brand { get; set; }
       
        public string model_name { get; set; }

        public int Power { get; set; }

        public int max_speed { get; set; }
        public string type { get; set; }
        
       

        // public string type { get; set; }

    }
}
