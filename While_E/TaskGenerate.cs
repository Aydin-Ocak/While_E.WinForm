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
    public partial class TaskGenerate : Form
    {
        public TaskGenerate()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int currentID;
        private void button7_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }
        private void Add_Task()
        {
            try
            {
                if(txtIsim.Text == "" || rTxtAciklama.Text == "")
                {
                    MessageBox.Show("İlgili alanları doldurunuz");
                }
                else
                {
                    string name = txtIsim.Text;
                    string desc = rTxtAciklama.Text;
                    WebServiceHelpers.Add_Task(name, desc, false, currentID);

                    txtIsim.Clear();
                    rTxtAciklama.Clear();
                    cmbUser.SelectedItem = null;

                    MessageBox.Show("Görev Eklendi");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("İlgili alanları doldurunuz");
            }
        }

        private void BtnGorevOlustur_Click(object sender, EventArgs e)
        {
            Add_Task();
        }

        private void GorevOlustur_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();
            users = WebServiceHelpers.GetUsers();

            

            for(int i =0; i<users.Count; i++)
            {
                string userName = users[i].userName;
                int userID = users[i].userID;

                currentID = userID;
                cmbUser.Items.Add(userName);
            }
            
        }
    }
}
