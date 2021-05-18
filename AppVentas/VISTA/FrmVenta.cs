using AppVentas.DAO;
using AppVentas.MODEL;
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
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            ClsCliente cliente = new ClsCliente();
                comboBoxCliente.DataSource = cliente.CargaCliente();
                comboBoxCliente.DisplayMember = "nombreCliente";
                comboBoxCliente.ValueMember = "iDCliente";

            ClsDocumento clsDocumento = new ClsDocumento();
                comboBoxDocumento.DataSource = clsDocumento.CargaDocumento();
                comboBoxDocumento.DisplayMember = "nombreDocumento";
                comboBoxDocumento.ValueMember = "iDDocumento";
            
           


        }

        private void BtnAccesos_Click(object sender, EventArgs e)
        {
            FrmAccesoCruds frmAccesoCruds = new FrmAccesoCruds();
            frmAccesoCruds.ShowDialog();
        }

        private void comboBoxDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmProductoss buscar = new FrmProductoss();
            buscar.Show();
        }
    }
}
