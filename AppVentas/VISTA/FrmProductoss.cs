using AppVentas.DAO;
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
    public partial class FrmProductoss : Form
    {
        public FrmProductoss()
        {
            InitializeComponent();
            cargardatos();
        }


        void cargardatos() 
        {
            ClsProductos clsProductos = new ClsProductos();
            DataProductos.Rows.Clear();

            foreach (var listardatos in clsProductos.Carga(textBox1.Text)) 
            {
            DataProductos.Rows.Add(listardatos.idProducto,listardatos.nombreProducto,listardatos.precioProducto);

            }

        }
        
        
        private void FrmProductoss_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = DataProductos.CurrentRow.Cells[0].Value.ToString();
            String Nombre = DataProductos.CurrentRow.Cells[1].Value.ToString();
            String Precio = DataProductos.CurrentRow.Cells[2].Value.ToString();

            //FrmVenta frmVenta = new FrmVenta();
            //frmVenta.TxtId.Text = id;
            //frmVenta.TxtNombrePro.Text = Nombre;
            //frmVenta.TxtPrecio.Text = Precio;

            FrmMenuVenta.venta.TxtId.Text = id;
            FrmMenuVenta.venta.TxtNombrePro.Text = Nombre;
            FrmMenuVenta.venta.TxtPrecio.Text = Precio;

        }
    }
}
