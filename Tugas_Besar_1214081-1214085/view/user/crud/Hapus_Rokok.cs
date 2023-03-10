using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Besar_1214081_1214085.controller;
using static Tugas_Besar_1214081_1214085.formLogin;

namespace Tugas_Besar_1214081_1214085.view
{
    public partial class formHapusRokok : Template
    {
        Koneksi koneksi = new Koneksi();
        string id;
        public formHapusRokok()
        {
            InitializeComponent();
        }
        private void DataRokok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = DataRokok.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult pesan = MessageBox.Show("Apakah anda yakin ingin menghapus data", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Metode mthd = new Metode();
                mthd.DeleteRokok(id);
                Tampil();
            }
        }
        public void Tampil()
        {
            //Query Database
            DataRokok.DataSource = koneksi.ShowData("SELECT rokok.id, m_rokok.nama, jumlah, rokok.harga, tanggal FROM user JOIN rokok ON rokok.id_user = user.id JOIN m_rokok ON m_rokok.id = rokok.id_merek WHERE id_user='" + LoginInfo.IDUser + "' ORDER BY id ASC");

            //Mengubah nama header
            DataRokok.Columns[0].HeaderText = "ID";
            DataRokok.Columns[1].HeaderText = "Merek";
            DataRokok.Columns[2].HeaderText = "Jumlah (Bungkus)";
            DataRokok.Columns[3].HeaderText = "Harga";
            DataRokok.Columns[4].HeaderText = "Tanggal";
        }
        private void formHapusRokok_Load(object sender, EventArgs e)
        {
            Tampil();
        }





        /*----------------------------------------------Header----------------------------------------------*/
        //Moving form with pannel
        bool moving;
        Point offset;
        Point original;
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            Header.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }
        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }
        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            Header.Capture = false;
        }
        




        /*----------------------------------------------Button----------------------------------------------*/
        //Minimize button
        private void btMinimize_MouseEnter(object sender, EventArgs e)
        {
            btMinimize.Size = new Size(36, 36);
            btMinimize.Location = new Point(630, 8);
        }
        private void btMinimize_MouseLeave(object sender, EventArgs e)
        {
            btMinimize.Size = new Size(46, 46);
            btMinimize.Location = new Point(625, 3);
        }
        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Close button
        private void btClose_MouseEnter(object sender, EventArgs e)
        {
            btClose.Size = new Size(36, 36);
            btClose.Location = new Point(700, 8);
        }
        private void btClose_MouseLeave(object sender, EventArgs e)
        {
            btClose.Size = new Size(46, 46);
            btClose.Location = new Point(695, 3);
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
