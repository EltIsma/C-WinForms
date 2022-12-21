using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwplab3
{
    public class tractor:car
    {

        public int reg_numb { get; set; }
        public int wheel_diametr { get; set; }
        public string working_equip { get; set; }
        
        public tractor(int rn, int wd, string we)
        {
            reg_numb = rn;
            wheel_diametr = wd;
            working_equip = we;

        }

        public tractor()
        {
            type = "tractor";

        }
    }
}
