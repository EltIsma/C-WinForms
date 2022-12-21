using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rwplab3
{
    public partial class Form1 : Form
    {
        BindingList<car> Cars;
        // IPAddress myIp = IPAddress.Parse("127.0.0.1");
        //int port = 3000;
        bool f =false;
        pass_car PC = new pass_car("BMW", "M4", 300, 400, "passenger_car");
        public Form1()
        {
            InitializeComponent();
            Cars = new BindingList<car>();
            bindingSource1.DataSource = Cars;
            dataGridView1.DataSource = bindingSource1;
            string myIp = "127.0.0.1";
            int port = 8080;
            cl = new Client(myIp, port);
            cl.ConnectToserver();
            Thread.Sleep(1000);
            cl.serverData();
            Cars.Add(PC);


            //server = new Server(myIp, port);
            //  server.startListening();




            //server.acceptClient();
            //getcar();
        }
        Client cl;

        void getcar()
        {
            if (f == true)
            {
                cl.ConnectToserver();
                Thread.Sleep(1000);
                cl.serverData();

            }
            string messagefromserver = cl.streamReader.ReadLine();
            if (messagefromserver == "send car")
            {
                pass_car rescar = new pass_car("as", "da", 11, 23, "passenger_car");
                string data;
                while ((data = cl.streamReader.ReadLine()) != "all data of car send")
                {
                    if (data.Contains("Brand"))
                    {
                        rescar.Brand = data.Substring(7);

                    }
                    if (data.Contains("model"))
                    {
                        rescar.model_name = data.Substring(7);

                    }
                    if (data.Contains("Power"))
                    {
                        rescar.Power = Convert.ToInt32(data.Substring(7));

                    }
                    if (data.Contains("speed"))
                    {
                        rescar.max_speed = Convert.ToInt32(data.Substring(7));

                    }
                    if (data.Contains("typee"))
                    {
                        rescar.type = data.Substring(7);

                    }


                }
                Cars.Add(rescar);
                f = true;
                // cl.disconect();
            }
        }
    

        List<string> brand1 = new List<string>() { "BMW", "Audi", "Toyota", "Infinity", "Mercedes", "Subaru", "Lada" };
        List<string> model1 = new List<string>() { "R23", "dfghjf", "LK", "A4", "Mercedes", "Subaru", "Lada" };
        //List<string> type1 = new List<string>() { "passenger_car", "truck","tractor"};

        private void Form1_Load(object sender, EventArgs e)
        {

            // getcar();
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
            /*  if (dataGridView1[0, 4].Value == "car")
              {

                  e.NewObject = new pass_car();
              }
              else { e.NewObject = new truck(); 
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   MessageBox.Show(Convert.ToString(Cars[0].GetType()));
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 f2 = new Form2(Cars[e.RowIndex]);
            f2.Show();

            /*if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "passenger_car") {
                List<pass_car> pc = new List<pass_car>();

                if (!Loader.pascar.ContainsKey(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value))) {

                   Thread DataLoad = new Thread(()=>Loader.Load(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value)));
                   DataLoad.Start();   
               }

                Loader.pascar.TryGetValue(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), out pc);
                Form2 f2 = new Form2(pc);
                f2.ShowDialog();
            }
            else if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "truck") {
                List<truck> tr = new List<truck>();
               if (!Loader.trucks.ContainsKey(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value)))
               {
                   Loader.Load(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value));
               }
                Loader.trucks.TryGetValue(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), out tr);
                Form2 ff2 = new Form2(tr);
                ff2.ShowDialog();
            }*/

            //Loader.Load(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value));
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "passenger_car")
            {
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;


            }
            else if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "truck")
            { dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Blue; }
            else if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "tractor")
            { dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Green; }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<car> carsave = new List<car>();
            foreach (car C in Cars)
            {
                carsave.Add(C);

            }
            XmlSerializer xmlf = new XmlSerializer(typeof(List<car>));
            SaveFileDialog savef = new SaveFileDialog();
            savef.OverwritePrompt = true;
            savef.InitialDirectory = "C:\\WindowsApplicationc#\\lab33";
            savef.Filter = "Files(*.xml)|*.xml";
            if (savef.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(savef.FileName, FileMode.OpenOrCreate))
                {
                    xmlf.Serialize(fs, carsave);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openf = new OpenFileDialog())
            {

                XmlSerializer xmlf = new XmlSerializer(typeof(BindingList<car>));
                openf.Filter = "Files(*.xml)|*.xml";
                openf.InitialDirectory = "C:\\WindowsApplicationc#\\lab33";

                if (openf.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openf.FileName, FileMode.Open))
                    {
                        var desrialized = xmlf.Deserialize(fs) as BindingList<car>;
                        if (desrialized != null)
                        {
                            Cars.Clear();
                            foreach (var d in desrialized) Cars.Add(d);
                        }
                    }
                }

            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                if (f == true)
                {
                    cl.ConnectToserver();
                    Thread.Sleep(1000);
                    cl.serverData();

                }
                string messagefromserver = cl.streamReader.ReadLine();
                if (messagefromserver == "send car")
                {
                    pass_car rescar = new pass_car("as", "da", 11, 23, "passenger_car");
                    string data;
                    while ((data = cl.streamReader.ReadLine()) != "all data of car send")
                    {
                        if (data.Contains("Brand"))
                        {
                            rescar.Brand = data.Substring(7);

                        }
                        if (data.Contains("model"))
                        {
                            rescar.model_name = data.Substring(7);

                        }
                        if (data.Contains("Power"))
                        {
                            rescar.Power = Convert.ToInt32(data.Substring(7));

                        }
                        if (data.Contains("speed"))
                        {
                            rescar.max_speed = Convert.ToInt32(data.Substring(7));

                        }
                        if (data.Contains("typee"))
                        {
                            rescar.type = data.Substring(7);

                        }


                    }
                    Cars.Add(rescar);
                    f = true;
                    // cl.disconect();
                }

            
        }
    }
}
