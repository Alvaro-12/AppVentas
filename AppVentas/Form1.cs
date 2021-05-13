using AppVentas.DAO;
using AppVentas.VISTA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            ClsAccseso acc = new ClsAccseso();

            int valor = acc.accseso(TxtGmail.Text,TxtPass.Text);

            if (valor == 1)
            {
                FrmVenta frmVenta = new FrmVenta();
                frmVenta.Show();
            }
            else {
                MessageBox.Show("Error");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
