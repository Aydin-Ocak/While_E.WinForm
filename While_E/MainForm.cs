using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using While_E.Models;
using System.Data.SqlClient;

namespace While_E
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Color colorOrange = Color.FromArgb(238, 108, 77);
        Color colorPanel2 = Color.FromArgb(152, 193, 217);
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = colorOrange;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = colorPanel2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(panel2.Visible == false)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }

        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = colorOrange;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = colorPanel2;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = colorOrange;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = colorPanel2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskGenerate frm = new TaskGenerate();
            frm.Show();
            this.Hide();
        }

        private void btnGorevListe_Click(object sender, EventArgs e)
        {
            TaskForm frm = new TaskForm();
            frm.Show();
            this.Hide();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            UserList frm = new UserList();
            frm.Show();
            this.Hide();
        }

        private void btnKullaniciListe_Click(object sender, EventArgs e)
        {
            UserList frm = new UserList();
            frm.Show();
            this.Hide();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChardRefresh();
        }

        private void ChardRefresh()
        {
            List<Users> seciliUser = new List<Users>();
            seciliUser = WebServiceHelpers.GetUserName(cmbUser.Text);
            int secili_User = seciliUser[0].userID;

            List<Models.Task> tasks = new List<Models.Task>();
            tasks = WebServiceHelpers.GetSelectedTask(secili_User);

            List<Models.Task> compTasks = new List<Models.Task>();
            compTasks = WebServiceHelpers.GetCompTask(secili_User);

            int tasks_int = tasks.Count;
            int compTasks_int = compTasks.Count;
            int kalan = tasks_int - compTasks_int;

            chart1.Series["Users"].Points.Clear();

            //int tamamlanan = 1;
            //int kalan = 3 - tamamlanan;

            chart1.Series["Users"].Points.AddXY("tamamlanan", compTasks_int);
            chart1.Series["Users"].Points.AddXY("kalan", kalan);

            chart1.Series["Users"].Points[0].LabelForeColor = Color.Transparent;
            chart1.Series["Users"].Points[1].LabelForeColor = Color.Transparent;
            
            chart1.Series["Users"].Points[1].Color = Color.FromArgb(255, 0, 34);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();
            users = WebServiceHelpers.GetUsers();
            
            foreach(var i in users)
            {
                cmbUser.Items.Add(i.userName);
            }
            
            cmbUser.SelectedIndex = 0;
            ChardRefresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
