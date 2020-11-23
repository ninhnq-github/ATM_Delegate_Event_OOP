using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Delegate_EventHandler
{
    public partial class Form1 : Form
    {
        ThaoTacChuyenTien chuyentien;
        ThaoTacRutTien ruttien;
        ATM atm;
        public Form1()
        {
            InitializeComponent();
            atm = new ATM();
            chuyentien = new ThaoTacChuyenTien(atm);
            ruttien = new ThaoTacRutTien(atm);
        }
        // Khi ấn nút chuyển tiền --> kích hoạt sự kiện chuyển tiền của đối tượng ATM
        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            atm.Chuyentien();
        }
        // Khi ấn nút Rút tiền --> kích hoạt sự kiện rút tiền của đối tượng ATM
        private void btnRutTien_Click(object sender, EventArgs e)
        {
            atm.Ruttien();
        }
    }
}
