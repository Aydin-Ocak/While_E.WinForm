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

namespace While_E
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        int currentID;
        bool currentComp;

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Refresh_Task()
        {
            List<Models.Task> TaskList = new List<Models.Task>();
            TaskList = WebServiceHelpers.GetTask();
            dtgrdVwTasks.DataSource = TaskList;

            cmbUser.SelectedItem = null;
        }
        private void Selected_Task_refresh()
        {
            List<Users> NameToID = new List<Users>();
            NameToID = WebServiceHelpers.GetUserName(cmbUser.Text);
            int ID = (int)NameToID[0].userID;
            Selected_Task(ID);
        }
        void Selected_Task(int ID)
        {
            List<Models.Task> SelectedTask = new List<Models.Task>();
            SelectedTask = WebServiceHelpers.GetSelectedTask(ID);
            dtgrdVwTasks.DataSource = SelectedTask;
        }

        private void GorevForm_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();
            users = WebServiceHelpers.GetUsers();



            for (int i = 0; i < users.Count; i++)
            {
                string userName = users[i].userName;
                int userID = users[i].userID;

                currentID = userID;
                cmbUser.Items.Add(userName);
            }

            dtgrdVwTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Refresh_Task();
        }
        public void Del_Task()
        {
            WebServiceHelpers.Del_Task(currentID);
        }
        public void Update_Task()
        {
            if(currentComp == true)
            {
                WebServiceHelpers.Update_Task(currentID, false);
            }
            else
            {
                WebServiceHelpers.Update_Task(currentID, true);
            }
            

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
           Refresh_Task();
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            Update_Task();
            if(cmbUser.Text == "")
            {
                Refresh_Task();
            }
            else
            {
                Selected_Task_refresh();
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Del_Task();
            Refresh_Task();
        }

        private void dtgrdVwKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentID = (int)dtgrdVwTasks.CurrentRow.Cells[0].Value;
            currentComp = (bool)dtgrdVwTasks.CurrentRow.Cells[3].Value;
            if(currentComp == true)
            {
                btnBitir.Text = "Devam";
            }
            else
            {
                btnBitir.Text = "Bitir";
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbUser.Text != "")
            {
                Selected_Task_refresh();
            }
            
        }
    }
}
