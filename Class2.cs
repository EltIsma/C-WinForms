using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwplab3
{
    
        public class pass_car :car
        {

        /* public string Brand { get; set; }

         public string model_name { get; set; }


         public int Power { get; set; }


         public int max_speed { get; set; }
         public string type { get; set; }*/

        public int reg_numb { get; set; }
        public int count_airbag { get; set; }
        public string multi_name { get; set; }
        public pass_car(string b, string m, int p, int s, string t)
            {
                Brand = b;
                model_name = m;
                Power = p;
                max_speed = s;
                type = t;

            }
        public pass_car(int rn, int ca, string mn)
        {
            reg_numb = rn;
           count_airbag= ca;
            multi_name = mn;    

        }

        public pass_car()
            {
                type = "passenger_car";
            
            }


        }


    
}
