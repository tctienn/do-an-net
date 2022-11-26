using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycuahangthuoc
{
    public partial class frm_main : Form
    {
        private string nameuser;
        public frm_main()
        {
            InitializeComponent();
        }
        public frm_main(string name) : this()
        {
            nameuser = name;
            
        }
        private void frm_main_Load(object sender, EventArgs e)
        {
            lb_name.Text = nameuser;
        }

        private void nhậpSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_themsp themsp = new frm_themsp();
            themsp.Show();

           
            //ẩn form
            this.Hide();
        }

        private void sấToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.WindowState = for
        }

        private void bt_nhanvien_Click(object sender, EventArgs e)
        {
            frm_nhanvien nhanvien = new frm_nhanvien();
            nhanvien.Show();
            this.Hide();
        }

        private void bt_huythuoc_Click(object sender, EventArgs e)
        {
            frm_huythuoc huythuoc = new frm_huythuoc();
            huythuoc.Show();
            this.Hide();
        }

        private void demo_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
        }

        private void bt_dssp_Click(object sender, EventArgs e)
        {
            frm_danhsachsp sp = new frm_danhsachsp();
            sp.Show();
            this.Hide();
        }

        private void tracuu_huy_Click(object sender, EventArgs e)
        {
            frm_tracuu_huy tracuu_huy = new frm_tracuu_huy();
            tracuu_huy.Show();
            this.Hide();
        }

        private void bt_hoadon_Click(object sender, EventArgs e)
        {
            frm_hoadon hoadon = new frm_hoadon();
            hoadon.ShowDialog();
            
        }

        private void bt_bieudo_Click(object sender, EventArgs e)
        {
            frm_bieudo bieudo = new frm_bieudo();
            bieudo.ShowDialog();

        }
    }
}
