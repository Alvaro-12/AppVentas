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
            ultimocorrelativoventa();

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



        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmProductoss buscar = new FrmProductoss();
            buscar.Show();
        }

        void ultimocorrelativoventa()
        {
            var consultarultimaventa = new ClsDVenta();
            int lista = 0;
            foreach (var list in consultarultimaventa.UltimaVenta())
            {
                lista = list.iDVenta;
            }
            lista++;
            TxtUltimaVenta.Text = lista.ToString();
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }
        void calcular()
        {
            try
            {
                Double precio, cantidad, total;
                cantidad = Convert.ToDouble(TxtCantidad.Text);
                precio = Convert.ToDouble(TxtPrecio.Text);

                total = precio * cantidad;
                TxtTota.Text = total.ToString();
            }
            catch (Exception ex)
            {
                if (TxtCantidad.Text.Equals(""))
                {
                    TxtCantidad.Text = "1";
                    TxtCantidad.SelectAll();
                }
            }
        }

        void calculartotal()
        {
            Double suma = 0;
            for (int i = 0; i < DataVenta.Rows.Count; i++)
            {
                String datosaoperartotal = DataVenta.Rows[i].Cells[4].Value.ToString();
                Double DatosConvertidos = Convert.ToDouble(datosaoperartotal);
                suma += DatosConvertidos;
                TxtTotalFinal.Text = suma.ToString();

                TxtId.Clear();
                TxtNombrePro.Clear();
                TxtPrecio.Clear();
                TxtCantidad.Clear();
                TxtTota.Text = "";
            }

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            calcular();
            DataVenta.Rows.Add(TxtId.Text, TxtNombrePro.Text, TxtPrecio.Text, TxtCantidad.Text, TxtTota.Text);

            calculartotal();
            DataVenta.Refresh();
            DataVenta.ClearSelection();
            int ultimafila = DataVenta.Rows.Count - 1;
            DataVenta.FirstDisplayedScrollingRowIndex = ultimafila;
            DataVenta.Rows[ultimafila].Selected = true;
        }

        private void FrmVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                BtnAgregar.PerformClick();
                TxtBuscar.Focus();

            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == 13)
            
            if (TxtBuscar.Text.Equals(""))
                { 
                    e.Handled = true;
                    BtnBuscar.PerformClick();
            }
            else
            {
                e.Handled = true;
                ClsProductos prod = new ClsProductos();
                var busqueda = prod.BuscarProductos(Convert.ToInt32(TxtBuscar.Text));

                    if (busqueda.Count < 1)
                    {
                        MessageBox.Show("El codigo no existe");
                        TxtBuscar.Text = "";
                    } 
                foreach (var iterar in busqueda)
                {
                    TxtId.Text = iterar.idProducto.ToString();
                    TxtNombrePro.Text = iterar.nombreProducto;
                    TxtPrecio.Text = iterar.precioProducto.ToString();
                    TxtCantidad.Text = "1";
                    TxtCantidad.Focus();
                    TxtBuscar.Text = "";
                }
            }
        }

        private void BtnGuardarventa_Click(object sender, EventArgs e)
        {
            try
            {
                ClsDVenta ventas = new ClsDVenta();
                tb_venta venta = new tb_venta();
                venta.iDDocumento = Convert.ToInt32(comboBoxDocumento.SelectedValue.ToString());
                venta.iDCliente = Convert.ToInt32(comboBoxCliente.SelectedValue.ToString());
                venta.iDUsuario = 1;
                venta.totalVenta = Convert.ToInt32(TxtTotalFinal.Text);
                venta.fecha = Convert.ToDateTime(dateTimePicker1.Text);
                ventas.save(venta);
                



                ClsDDetalle detalle = new ClsDDetalle();
                tb_detalleVenta tbdetalle = new tb_detalleVenta();

                foreach (DataGridViewRow dtgv in DataVenta.Rows) 
                {
                    tbdetalle.iDVenta = Convert.ToInt32(TxtUltimaVenta.Text);
                    tbdetalle.iDProducto = Convert.ToInt32(dtgv.Cells[0].Value.ToString());
                    tbdetalle.cantidad = Convert.ToInt32(dtgv.Cells[3].Value.ToString());
                    tbdetalle.precio = Convert.ToInt32(dtgv.Cells[2].Value.ToString());
                    tbdetalle.total = Convert.ToInt32(dtgv.Cells[4].Value.ToString());
                    detalle.guardardetalleventa(tbdetalle);

                }
                ultimocorrelativoventa();
                DataVenta.Rows.Clear();
                TxtTotalFinal.Text = "";


                MessageBox.Show("Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataVenta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculartotal();
        }
    }
}
