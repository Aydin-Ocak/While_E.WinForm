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
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }
        int currentID;

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

        private void KullaniciOlustur_Load(object sender, EventArgs e)
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

            dtgrdVwUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RefreshUser();
        }
        void RefreshUser()
        {
            List<Users> UserList = new List<Users>();
            UserList = WebServiceHelpers.GetUsers();

            dtgrdVwUser.DataSource = UserList;
        }
        void SelectedUser(string name)
        {
            List<Users> SelectedUser = new List<Users>();
            SelectedUser = WebServiceHelpers.GetSelectedUser(name);

            dtgrdVwUser.DataSource = SelectedUser;
        }


        private void Add_User()
        {
           string name = txtIsim.Text;
           string role = cmbRol.Text;

            WebServiceHelpers.Add_User(name, role);
        }
        private void Del_User()
        {
            WebServiceHelpers.Del_User(currentID);
        }
        private void Update_User()
        {
            string name = txtIsim.Text;
            string role = cmbRol.Text;

            WebServiceHelpers.Update_User(currentID, name, role);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Add_User();
            RefreshUser();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Del_User();
            RefreshUser();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Update_User();
            RefreshUser();
        }

        private void dtgrdVwUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIsim.Text = dtgrdVwUser.CurrentRow.Cells[1].Value.ToString();
            cmbRol.Text = dtgrdVwUser.CurrentRow.Cells[2].Value.ToString();
            currentID = (int)dtgrdVwUser.CurrentRow.Cells[0].Value;
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedUser(cmbUser.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbUser.SelectedItem = null;
            txtIsim.Text = "";
            cmbRol.SelectedItem = null;
            RefreshUser();
            
        }
    }
}
