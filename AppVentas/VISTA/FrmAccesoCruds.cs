using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.VISTA
{
    public partial class FrmAccesoCruds : Form
    {
        public FrmAccesoCruds()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.ShowDialog();
        }

        private void LblCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
        }

        private void LblDocumentos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDocumentos frmDocumentos = new FrmDocumentos();
            frmDocumentos.ShowDialog();
        }

        private void LblDetalleVenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.ShowDialog();
        }
    }
}
