using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace rwplab3
{
    public partial class Form2 : Form
    {
        public car Car;
        public Form2(car car)
        {
            Car = car;
            InitializeComponent();
            if (Car.type == "passenger_car")
            {
                
                dataGridView1.Columns.Add("reg_numb", "Регистрационный номер");
                dataGridView1.Columns.Add("count_airbag", "Количество подушек безопасности");
                dataGridView1.Columns.Add("multi_name", " мультимедиа");
               
            }
            else if (Car.type == "truck") {
                
                dataGridView1.Columns.Add("reg_numb", "Регистрационный номер");
                dataGridView1.Columns.Add("count_wheels", "Количество колёс");
                dataGridView1.Columns.Add("size_b", " Объём кузова");
               
                }
            else if (Car.type == "tractor")
            {

                dataGridView1.Columns.Add("reg_numb", "Регистрационный номер");
                dataGridView1.Columns.Add("wheel_diametr", "Диаметр колёс");
                dataGridView1.Columns.Add("working_equip", "Рабочее оборудоание");

            }
            start();
            
          
        }

        void DataLoad() {
            Loader.Load(Car.Brand,Car.type);
        
        }
        void start() {
            Thread LoadData = new Thread(DataLoad);
            LoadData.Start();
            timer1.Start();
        }
        /* public Form2(List<pass_car> passes)
         {
             InitializeComponent();
             dataGridView1.Columns.Add("reg_numb", "Регистрационный номер");
             dataGridView1.Columns.Add("count_airbag", "Количество подушек безопасности");
             dataGridView1.Columns.Add("multi_name", " мультимедиа");
             for (int i = 0; i < passes.Count; i++)
             {
                 dataGridView1.Rows.Add(passes[i].reg_numb, passes[i].count_airbag, passes[i].multi_name);

             }
             //Thread lth = new Thread();
             timer1.Start();

         }
         public Form2(List<truck> trucks)
         {
             InitializeComponent();
             dataGridView1.Columns.Add("reg_numb", "Регистрационный номер");
             dataGridView1.Columns.Add("count_wheels", "Количество колёс");
             dataGridView1.Columns.Add("size_b", " Объём кузова");
             for (int i = 0; i < trucks.Count; i++)
             {
                 dataGridView1.Rows.Add(trucks[i].reg_numb, trucks[i].count_wheels, trucks[i].size_b);
             }
             timer1.Start();
         }*/




        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 100)
            {
                progressBar1.Value = Loader.getProgress();
            }
             if (progressBar1.Value == 100)
            {
                timer1.Stop();
                if (Car.type == "passenger_car")
                {
                    for (int i = 0; i < Loader.pascar[Car.Brand].Count; i++)
                    {
                        dataGridView1.Rows.Add(Loader.pascar[Car.Brand][i].reg_numb, Loader.pascar[Car.Brand][i].count_airbag, Loader.pascar[Car.Brand][i].multi_name);

                    }

                }
                if (Car.type == "truck")
                {
                    for (int i = 0; i < Loader.trucks[Car.Brand].Count; i++)
                    {
                        dataGridView1.Rows.Add(Loader.trucks[Car.Brand][i].reg_numb, Loader.trucks[Car.Brand][i].count_wheels, Loader.trucks[Car.Brand][i].size_b);

                    }

                }
                if (Car.type == "tractor")
                {
                    for (int i = 0; i < Loader.tractors[Car.Brand].Count; i++)
                    {
                        dataGridView1.Rows.Add(Loader.tractors[Car.Brand][i].reg_numb, Loader.tractors[Car.Brand][i].wheel_diametr, Loader.tractors[Car.Brand][i].working_equip);

                    }

                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private Rectangle dragBoxFromMouseDown;
        private object valueFromMouseDown;
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {                 
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            var hittestInfo = dataGridView1.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                valueFromMouseDown = dataGridView1.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
                if (valueFromMouseDown != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                string cellvalue = e.Data.GetData(typeof(string)) as string;
                var hittest = dataGridView1.HitTest(clientPoint.X, clientPoint.Y);
                if (hittest.ColumnIndex != -1
                    && hittest.RowIndex != -1)
                    dataGridView1[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;

            }
        }
    }
}