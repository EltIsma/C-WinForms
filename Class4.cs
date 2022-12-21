using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace rwplab3
{
    public  class Loader
    {
        public static int t;
        static int val_acc = 0;
        static int z = 1;
        public static Dictionary<string, List<pass_car>> pascar = new Dictionary<string, List<pass_car>>();
        public static Dictionary<string, List<truck>> trucks = new Dictionary<string, List<truck>>();
        public static Dictionary<string, List<tractor>> tractors = new Dictionary<string, List<tractor>>();
        public static List<string> multimedia = new List<string>() { "SWAT", "ACV", "Teyes", "Eplutus" };
        public static List<string> equip = new List<string>() { "HGH45", "POOI99", "LK08", "ZXAS" };
        public static void Load(string brandN, string type)
        {
            t = 0;
             val_acc = new Random().Next(10, 20);
            if (pascar.ContainsKey(brandN)) {  z = 10; }
            if (trucks.ContainsKey(brandN)) { z = 10; }
            if (tractors.ContainsKey(brandN)) { z = 10; }
            if (type == "passenger_car")
            {
                List<pass_car> pascarlist = new List<pass_car>();
                for (int i = 0; i < val_acc; i++)
                {
                   pascarlist.Add(new pass_car(new Random().Next(555, 600),  new Random().Next(1, 5), multimedia[new Random().Next(0, multimedia.Count)]));
                    Thread.Sleep(300/ z);
                    t++;
                }
                
                if(!pascar.ContainsKey(brandN))
                pascar.Add(brandN, pascarlist); 
                
            }
            else if (type == "truck")
            {
                List<truck> trucklist = new List<truck>();
                for (int i = 0; i < val_acc; i++)
                {
                    trucklist.Add(new truck(new Random().Next(555, 600), new Random().Next(4, 8), new Random().Next(10, 20)));
                    Thread.Sleep(300 / z);
                    t++;
                }
                
                if (!trucks.ContainsKey(brandN))
                    trucks.Add(brandN, trucklist); 
            }
            else
            {
                List<tractor> tractorlist = new List<tractor>();
                for (int i = 0; i < val_acc; i++)
                {
                    tractorlist.Add(new tractor(new Random().Next(555, 600), new Random().Next(4, 8), equip[new Random().Next(0, equip.Count)]));
                    Thread.Sleep(300 / z);
                    t++;
                }

                if (!tractors.ContainsKey(brandN))
                    tractors.Add(brandN, tractorlist);
            }
        }
       
        public static int getProgress() {
            if (val_acc != 0) return (int)Math.Round(((double)t / val_acc) * 100);
            else return 0;
        }

        
    }
}
