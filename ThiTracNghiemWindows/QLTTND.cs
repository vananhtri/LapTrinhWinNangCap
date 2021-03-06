﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using System.IO;
using LinqToSql;

namespace ThiTracNghiemWindows
{
    public partial class QLTTND : DevExpress.XtraEditors.XtraUserControl
    {
        XuLy xl = new XuLy();
        DuLieu dl = new DuLieu();
        public QLTTND()
        {
            InitializeComponent();
            txt_hoten.KeyPress += Txt_hoten_KeyPress;
            txt_sdt.KeyPress += Txt_sdt_KeyPress;
        }
        ErrorProvider er = new ErrorProvider();
        private void Txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                er.SetError(txt_sdt, "Không nhập chữ");
            }
            else
                er.Clear();
        }

        private void Txt_hoten_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                
        }

        void loadgv()
        {
            gv_sv.DataSource = xl.loadgv();


        }
        private void QLTTND_Load(object sender, EventArgs e)
        {
            loadgv();
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            btn_luu.Enabled = false;
            picNguoiDung.Enabled = false;
            txt_mattnd.Enabled = date_ngaysinh.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = lk_gioitinh.Enabled = txt_email.Enabled = txt_sdt.Enabled = false;
           
        }
        private void gv_dssv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btn_them.Enabled = true;
            txt_mattnd.Enabled = date_ngaysinh.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_mattnd.Enabled = lk_gioitinh.Enabled = txt_sdt.Enabled = txt_email.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = true;
            //Lấy tên cột theo tên trong CSDL không phải name đặt
            txt_mattnd.Text = gv_dssv.GetRowCellValue(gv_dssv.FocusedRowHandle, "TaiKhoan").ToString();
            txt_hoten.Text = gv_dssv.GetRowCellValue(gv_dssv.FocusedRowHandle, "HoTen").ToString();
            date_ngaysinh.Text = gv_dssv.GetFocusedRowCellValue("NgaySinh").ToString();
            lk_gioitinh.Text = gv_dssv.GetFocusedRowCellValue("GioiTinh").ToString();
            txt_diachi.Text = gv_dssv.GetFocusedRowCellValue("DiaChi").ToString();
            txt_sdt.Text = gv_dssv.GetFocusedRowCellValue("SDT").ToString();
            txt_email.Text = gv_dssv.GetFocusedRowCellValue("Email").ToString();
            //pic_hinh.Image = Image.FromFile("Anh/" + gv_dssv.GetFocusedRowCellValue("HINH").ToString());
            //Nut
            if (gv_dssv.GetFocusedRowCellValue("Hinh") != null)
            {
                string nameImage = gv_dssv.GetFocusedRowCellValue("Hinh").ToString();
                if (!string.IsNullOrWhiteSpace(nameImage))
                {
                    picNguoiDung.ImageLocation = "../../Images" + "/" + nameImage;
                }
                else
                {
                    picNguoiDung.ImageLocation = string.Empty;
                }

            }
            else
            {
                picNguoiDung.ImageLocation = string.Empty;
            }

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_mattnd.Focus();
            txt_sdt.Text = txt_email.Text = txt_mattnd.Text = txt_hoten.Text = txt_diachi.Text = string.Empty;
            date_ngaysinh.Text = null;
            lk_gioitinh.Text = null;
            picNguoiDung.ImageLocation = string.Empty;
            txt_mattnd.Enabled = date_ngaysinh.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_mattnd.Enabled = lk_gioitinh.Enabled = txt_sdt.Enabled = txt_email.Enabled = true;
            btn_xoa.Enabled = btn_sua.Enabled = btn_them.Enabled = false;
            btn_luu.Enabled = true;
            picNguoiDung.Enabled = true;
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int kq = xl.xoathongtinngdung(gv_dssv.GetRowCellValue(gv_dssv.FocusedRowHandle, "MaThongTinNguoiDung").ToString());
            if (kq == 0)
            {
                MessageBox.Show("Xóa thành công");
                loadgv();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            date_ngaysinh.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_mattnd.Enabled = lk_gioitinh.Enabled = txt_sdt.Enabled = txt_email.Enabled = true;
            btn_sua.Enabled = false;
            txt_mattnd.Enabled = false;
            txt_hoten.Focus();
            btn_luu.Enabled = true;
            picNguoiDung.Enabled = true;


        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_mattnd.Text == "" || txt_hoten.Text == "" || lk_gioitinh.Text == "" || txt_diachi.Text == "" || txt_email.Text == "" || txt_sdt.Text == "" || date_ngaysinh.Text == "")

            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_mattnd.Enabled == true)
            {
                int kttentk = dl.CheckTenTaiKhoan(txt_mattnd.Text);
                if(kttentk==0)
                {
                   
                    MessageBox.Show("Trùng tên tài khoản");
                    return;
                }
                string nameHinh = SaveImage();
                int kq = xl.themsinhvien(txt_mattnd.Text.ToString(), txt_hoten.Text.ToString(), date_ngaysinh.Text.ToString(), lk_gioitinh.Text.ToString(), txt_diachi.Text.ToString(), txt_sdt.Text.ToString(), txt_email.Text.ToString(), nameHinh);
                if (kq == 0)
                {
                    
                    MessageBox.Show("Thành công");
                    loadgv();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại");
                }
            }
            else
            {
                string nameHinh = SaveImage();
                int kq = xl.suathongtinnguoidung(gv_dssv.GetRowCellValue(gv_dssv.FocusedRowHandle, "MaThongTinNguoiDung").ToString(), txt_hoten.Text.ToString(), date_ngaysinh.Text.ToString(), lk_gioitinh.Text.ToString(), txt_diachi.Text.ToString(), txt_sdt.Text.ToString(), txt_email.Text.ToString(), nameHinh);
                if (kq == 0)
                {
                    MessageBox.Show("Sửa thành công");
                    picNguoiDung.Enabled = false;
                    loadgv();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private string SaveImage()
        {
            if (String.IsNullOrWhiteSpace(picNguoiDung.ImageLocation))
            {
                return string.Empty;
            }

            string saveDirectory = "../../Images";
            string fileName = Path.GetFileName(picNguoiDung.ImageLocation);
            string fileSavePath = Path.Combine(saveDirectory, fileName);
            if (!File.Exists(fileSavePath))
            {
                File.Copy(picNguoiDung.ImageLocation, fileSavePath, true);

            }
            return fileName;

        }
        private void picNguoiDung_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    picNguoiDung.ImageLocation = openFileDialog1.FileName;
                    //string fileName = Path.GetFileName(openFileDialog1.FileName);
                    //string fileSavePath = Path.Combine(saveDirectory, fileName);
                    //File.Copy(openFileDialog1.FileName, fileSavePath, true);

                    //string constr = @"Data Source=.\SQL2014;Initial Catalog=AjaxSamples;Integrated Security=true";
                    //using (SqlConnection conn = new SqlConnection(constr))
                    //{
                    //    string sql = "INSERT INTO Files VALUES(@Name, @Path)";
                    //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    //    {
                    //        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(fileName));
                    //        cmd.Parameters.AddWithValue("@Path", fileSavePath);
                    //        conn.Open();
                    //        cmd.ExecuteNonQuery();
                    //        conn.Close();
                    //    }
                    //}

                    //this.BindDataGridView();
                }
            }
        }
        

       
    }
}
