using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace quanlycuahangthuoc
{
    public partial class frm_bieudo : Form
    {
        conectdb conn = new conectdb();
        public frm_bieudo()
        {
            InitializeComponent();
            cb_nam.DataSource = conn.load_nam_hoadon();
            cb_nam.DisplayMember = "nam";
        }

        private void frm_bieudo_Load(object sender, EventArgs e)
        {
            //demo
            
            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[0].HeaderCell.Value = "Năm 2012";
            //dataGridView1.Rows[0].Cells[0].Value = 4;
            //dataGridView1.Rows[0].Cells[1].Value = 8;
            //dataGridView1.Rows[0].Cells[2].Value = 3;
            //dataGridView1.Rows[0].Cells[3].Value = 4;
            //dataGridView1.Rows[0].Cells[4].Value = 9;
            //dataGridView1.Rows[0].Cells[5].Value = 5;

            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[1].HeaderCell.Value = "Năm 2013";
            //dataGridView1.Rows[1].Cells[0].Value = 8;
            //dataGridView1.Rows[1].Cells[1].Value = 12;
            //dataGridView1.Rows[1].Cells[2].Value = 3;
            //dataGridView1.Rows[1].Cells[3].Value = 9;
            //dataGridView1.Rows[1].Cells[4].Value = 7;
            //dataGridView1.Rows[1].Cells[5].Value = 43;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)// phần demo
        {
            

            ////Tìm và đặt giá trị MAX cho trục Y
            //int max = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            //for (int i = 1; i < 6; i++)
            //    if (max < Convert.ToInt32(dataGridView1.CurrentRow.Cells[i].Value))
            //        max = Convert.ToInt32(dataGridView1.CurrentRow.Cells[i].Value);
            //if (chart1.ChartAreas[0].AxisY.Maximum < max) chart1.ChartAreas[0].AxisY.Maximum = max;

            //chart1.Series.Clear();
            //for (int n = 0; n < dataGridView1.Rows.Count; n++) //Duyệt từ dòng đầu tiên đến dòng cuối cùng của dataGridView1
            //{
            //    if (dataGridView1.Rows[n].Selected) //Nếu dòng thứ n được chọn thì thêm series cho dòng đó
            //    {
            //        Series s = new Series();
            //        for (int i = 0; i < 6; i++)
            //        {
            //            DataPoint p = new DataPoint();
            //            p.XValue = i;
            //            p.SetValueY(Convert.ToDouble(dataGridView1.Rows[n].Cells[i].Value));
            //            p.AxisLabel = "Tháng " + (i + 1).ToString();
            //            s.Points.Add(p);
            //        }
            //        chart1.Series.Add(s);
            //    }
            //}

        }

        private void bt_hien_Click(object sender, EventArgs e)
        {
            string giatri = "";
            if(cb_nam.Text != "")
            {
                giatri = " where year(ngaytao) = "+ cb_nam.Text;
               dgv_hoadon.DataSource = conn.tim_hoadon(giatri);

       /////////////////// biểu đồ
                //lấy tổng lớn nhất trong năm
                double max_tong =0;
                foreach (DataRow value in conn.load_tong(giatri).Rows)  // chỉ ra 1 kết quả duy nhất ko phải lo (xem lại phương pháp lấy 1 dòng dữ liệu trong database)
                {
                    double.TryParse(value["tong"].ToString(), out max_tong);
                }
                double tong_thang = 0;

                c_tongtien.Titles.Add("biểu đồ doanh thu từ hóa đơn bán hàng theo năm");


                c_tongtien.ChartAreas[0].AxisY.Maximum = (max_tong +1000); // chiều cao tối đa trục y
                c_tongtien.Series.Clear();

                Series s = new Series("tổng doanh thu theo tháng");
               
                for (int i = 1; i <= 12; i++)
                {
                    // lệnh truy vấn sql theo tháng
                    giatri = " where MONTH(ngaytao) = " + i + " and year(ngaytao) = " + Convert.ToInt32(cb_nam.Text);
                    //lấy tổng tiền cả tháng đó
                    foreach (DataRow value in conn.load_tong(giatri).Rows)  // chỉ ra 1 kết quả duy nhất ko phải lo (xem lại phương pháp lấy 1 dòng dữ liệu trong database)
                    {
                        double.TryParse(value["tong"].ToString(), out tong_thang);
                    }


                    DataPoint p = new DataPoint();
                    p.XValue = i;  // số lượng cột , vị trí cột
                    p.SetValueY(tong_thang); /// chiều cao phần tử so với y
                    p.AxisLabel = "Tháng " + (i ).ToString(); // tên cột theo xvalue
                    s.Points.Add(p);

                   
                }
                c_tongtien.Series.Add(s);

                //c_tongtien.Series[0].ChartType = SeriesChartType.Pie;  // chuyển sang biểu đồ hình tròn
            }
        }

        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
