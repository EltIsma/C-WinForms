using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwplab3
{
    public class truck:car
    {

        /*public string Brand { get; set; }

        public string model_name { get; set; }


        public int Power { get; set; }

       
        public int max_speed { get; set; }
        public string type { get; set; }*/
        public int reg_numb { get; set; }
        public int count_wheels { get; set; }
       public int size_b { get; set; }
        public truck(int rn, int cw, int sb)
        {
            reg_numb = rn;
            count_wheels = cw;
           size_b= sb;  

        }
        public truck(string b, string m, int p, int s,string t)
        {
            Brand = b;
            model_name= m; 
            Power = p;
            max_speed = s;
            type = t;
           
        }
        public truck() {
            type = "truck";
          
        }
       

    }
}
