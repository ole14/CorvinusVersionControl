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
using UserMaintenance.Properties;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lbFullName.Text = Resource1.FullName;
            btAdd.Text = Resource1.Add;
            btSTF.Text = Resource1.SaveToFile;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textFullName.Text
            };
            users.Add(u);
            textFullName.Clear();
        }

        private void btSTF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.InitialDirectory = @"E:\tananyag\5. félév\Informatikai rendszerek fejlesztése\CorvinusVersionControl\UserMaintenance\bin\Debug\";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(sfd.FileName);
                        writer.WriteLine("ID;Teljes Név");

                for (int i = 0; i < users.ToList().Count; i++)
                {
                        writer.WriteLine(users[i].ID.ToString() + ";" + users[i].FullName.ToString());
                }
                writer.Dispose();
                writer.Close();
            }
            
        }
    }
}
