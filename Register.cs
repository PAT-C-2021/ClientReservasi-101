using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_101
{
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Register()
        {
            InitializeComponent();
            TampilData();
            tbID.Visible = false;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
            //InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string kategori = comboBoxKategori.Text;
            string a = service.Register(username, password, kategori);

            if(tbUsername.Text == "" || tbPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua Data wajib diisi.");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                TampilData();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string kategori = comboBoxKategori.Text;
            int id = Convert.ToInt32(tbID.Text);
            string a = service.UpdateRegister(username, password, kategori, id);

            if (tbUsername.Text == "" || tbPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua Data wajib diisi.");
            }
            else
            {
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void TampilData()
        {
            var list = service.DataRegist();
            dtRegister.DataSource = list;
        }
        public void Clear()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            comboBoxKategori.SelectedItem = null;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }


        private void dtRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[0].Value);
            tbUsername.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[1].Value);
            tbPassword.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[2].Value);
            comboBoxKategori.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[3].Value);

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
        }
    }
}
