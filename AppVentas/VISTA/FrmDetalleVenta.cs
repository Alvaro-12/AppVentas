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
    public partial class FrmDetalleVenta : Form
    {
        public FrmDetalleVenta()
        {
            InitializeComponent();
            Clear();
            Carga();
        }

        void Clear() 
        {
            TxtIDDETALLEVENTA.Clear();
            TxtIdVenta.Clear();
            TxtIdProducto.Clear();
            TxtCantidad.Clear();
            TxtIdVenta.Clear();
            TxtPrecio.Clear();
            TxtTotal.Clear();
        }

        void Carga() 
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                foreach (var iteracion in bd.tb_detalleVenta.ToList())
                {
                    dataGridView1.Rows.Add(iteracion.iDDetalleVenta, iteracion.iDVenta, iteracion.iDProducto, iteracion.cantidad,iteracion.precio,iteracion.total);
                }
            }
        }
        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {

        }

       

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClsDetalleVenta detalleVenta = new ClsDetalleVenta();
            tb_detalleVenta venta = new tb_detalleVenta();

            venta.iDVenta =Convert.ToInt32( TxtIdVenta.Text);
            venta.iDProducto = Convert.ToInt32(TxtIdProducto.Text);
            venta.cantidad = Convert.ToInt32(TxtCantidad.Text);
            venta.precio = Convert.ToDecimal(TxtPrecio.Text);
            venta.total = Convert.ToDecimal(TxtTotal.Text);

            detalleVenta.SaveVenta(venta);
            Clear();
            Carga();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String IdDetalleVenta = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String IdVenta = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String IdProducto = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Cantidad = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            String Precio = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            String Total = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            TxtIDDETALLEVENTA.Text =IdDetalleVenta;
            TxtIdVenta.Text = IdVenta;
            TxtIdProducto.Text = IdProducto;
            TxtCantidad.Text = Cantidad;
            TxtPrecio.Text = Precio;
            TxtTotal.Text = Total;



        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ClsDetalleVenta Venta = new ClsDetalleVenta();
            tb_detalleVenta tb_Venta = new tb_detalleVenta();

            tb_Venta.iDDetalleVenta = Convert.ToInt32(TxtIDDETALLEVENTA.Text);
            tb_Venta.iDVenta = Convert.ToInt32(TxtIdVenta.Text);
            tb_Venta.iDProducto = Convert.ToInt32(TxtIdProducto.Text);
            tb_Venta.cantidad = Convert.ToInt32(TxtCantidad.Text);
            tb_Venta.precio =Convert.ToDecimal(TxtPrecio.Text);
            tb_Venta.total = Convert.ToDecimal(TxtTotal);

            Venta.UpVenta(tb_Venta);
            Clear();
            Carga();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClsDetalleVenta clsDetalleVenta = new ClsDetalleVenta();
            clsDetalleVenta.DeletVenta(Convert.ToInt32(TxtIDDETALLEVENTA.Text));
            Clear();
            Carga();
        }
    }
}
