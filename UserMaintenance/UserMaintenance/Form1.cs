using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource.FullName;
            btnAdd.Text = Resource.Add;
            btnToF.Text = Resource.ToFile;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,
            };
            users.Add(u);
        }

        private void btnToF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); 
            sfd.AddExtension = true; 

            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                
                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.Write(": ");
                    sw.Write(u.FullName);
                    sw.WriteLine();
                }
            }
        }
    }
}
