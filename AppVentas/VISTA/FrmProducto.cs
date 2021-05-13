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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
            clear();
            Carga();
        }
        void clear()
        {
            TxtIdProducto.Clear();
            TxtNombreProducto.Clear();
            TxtPrecio.Clear();
            TxtEstado.Clear();
        }
        public void Carga()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                foreach (var iteracion in bd.tb_producto.ToList())
                {
                    dataGridView1.Rows.Add(iteracion.idProducto, iteracion.nombreProducto, iteracion.precioProducto, iteracion.estadoProducto);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String IdProducto = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String NombreProducto = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Estado = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            TxtIdProducto.Text = IdProducto;
            TxtNombreProducto.Text = NombreProducto;
            TxtPrecio.Text = Precio;
            TxtEstado.Text = Estado;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClsProductos Producto = new ClsProductos();
            tb_producto TBPro = new tb_producto();

             TBPro.nombreProducto = TxtNombreProducto.Text;
             TBPro.precioProducto = TxtPrecio.Text;
             TBPro.estadoProducto = TxtEstado.Text;


            Producto.SaveProducto(TBPro);
            clear();
            Carga();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ClsProductos Producto = new ClsProductos();
            tb_producto tb = new tb_producto();

            tb.idProducto = Convert.ToInt32(TxtIdProducto.Text);
            tb.nombreProducto = TxtNombreProducto.Text;
            tb.precioProducto = TxtPrecio.Text;
            tb.estadoProducto = TxtEstado.Text;

            Producto.UpdateProducto(tb);
            clear();
            Carga();
        }
    }

}
