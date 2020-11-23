
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Delegate_EventHandler
{
    public class ATMEvent : EventArgs
    {
        private readonly string thongbao;
        public string ThongBao 
        {
            get { return thongbao; }
        }

        public ATMEvent(string thongbao)
        {
            this.thongbao = thongbao;
        }
    }
    public class ATM
    {
        // Hai cái delegate nhằm để trỏ đến hàm xử lí xử lí sự kiện
        public delegate void RuttienEventHanlend(object ob, ATMEvent e);
        public delegate void ChuyentienEventHanlend(object ob, ATMEvent e);
        // pulisher event 
        public event RuttienEventHanlend ruttien;
        public event ChuyentienEventHanlend chuyentien;

        public void Ruttien()
        {
            if (ruttien!=null) // Kiểm tra nếu sự kiện rút tiền đã được gán hàm xử lí hay chưa?
            {
                // Gọi hàm thông qua delegate 
                // -- Lời gọi này thực chất sẽ gọi hàm: 
                // void ruttien(object ob, ATMEvent e) ở trong class ThaoTacRutTien bên dưới
                ruttien(this, new ATMEvent("Vua rut tien xong"));
            }
        }
        public void Chuyentien()
        {
            if (chuyentien!=null) // Kiểm tra nếu sự kiện chuyển tiền đã được gán hàm xử lí hay chưa?
            {
                // Gọi hàm thông qua delegate 
                // -- Lời gọi này thực chất sẽ gọi hàm: 
                // void chuyentien(object ob, ATMEvent e) ở trong class ThaoTacChuyenTien bên dưới
                chuyentien(this, new ATMEvent("Vua chuyen tien xong"));
            }
        }
    }

    public class ThaoTacChuyenTien
    {
        private readonly ATM atm; 
        public ThaoTacChuyenTien(ATM atm)
        {
            this.atm = atm;
            atm.chuyentien += chuyentien;
            // Gán hàm chuyentien bên dưới cho sự kiện chuyentien của object atm
            // ở đây dùng multi cast của delegate
        }
        void chuyentien(object ob, ATMEvent e)
        {
            MessageBox.Show(e.ThongBao); // Hiện thông báo 
        }
    }

    public class ThaoTacRutTien
    {
        private readonly ATM atm;
        public ThaoTacRutTien(ATM atm)
        {
            this.atm = atm;
            atm.ruttien += ruttien;  
            // Gán hàm ruttien bên dưới cho sự kiện ruttien của object atm
            // ở đây dùng multi cast của delegate
        }
        void ruttien(object ob, ATMEvent e)
        {
            MessageBox.Show(e.ThongBao); // Hiện thông báo 
        }
    }
}
