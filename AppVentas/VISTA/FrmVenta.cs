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
            using (sistema_ventasEntities bd = new sistema_ventasEntities()) {

                var consultacliente = bd.tb_cliente.ToList();

                comboBoxCliente.DataSource = consultacliente;
                comboBoxCliente.DisplayMember = "nombreCliente";
                comboBoxCliente.ValueMember = "iDCliente";

                var consultaDocumento = bd.tb_documento.ToList(); 
                comboBoxDocumento.DataSource = consultaDocumento;
                comboBoxDocumento.DisplayMember = "nombreDocumento";
                comboBoxDocumento.ValueMember = "iDDocumento";
            
            }


        }

        private void BtnAccesos_Click(object sender, EventArgs e)
        {
            FrmAccesoCruds frmAccesoCruds = new FrmAccesoCruds();
            frmAccesoCruds.ShowDialog();
        }
    }
}
