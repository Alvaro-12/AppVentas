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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
            clear();
            Carga();
        }

        void clear()
        {
            TxtId.Clear();
            TxtNombre.Clear();
            TxtDireccion.Clear();
            TxtDUI.Clear();
        }
        public void Carga()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                foreach (var iteracion in bd.tb_cliente.ToList())
                {
                    dataGridView1.Rows.Add(iteracion.iDCliente, iteracion.nombreCliente, iteracion.direccionCliente,iteracion.duiCliente);
                }
            }
        }




        private void FrmCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistema_ventasDataSet2.tb_cliente' Puede moverla o quitarla según sea necesario.
            this.tb_clienteTableAdapter.Fill(this.sistema_ventasDataSet2.tb_cliente);

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClsCliente Cliente = new ClsCliente();
            tb_cliente TB_Cliente = new tb_cliente();
            
            TB_Cliente.nombreCliente = TxtNombre.Text;
            TB_Cliente.direccionCliente = TxtDireccion.Text;
            TB_Cliente.duiCliente = TxtDUI.Text;
           

            Cliente.SaveCliente(TB_Cliente);
            clear();
            Carga();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Direccion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String DUI = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            TxtId.Text = Id;
            TxtNombre.Text = Nombre;
            TxtDireccion.Text = Direccion;
            TxtDUI.Text = DUI;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ClsCliente cliente = new ClsCliente();
            tb_cliente tb_Cliente = new tb_cliente();

            tb_Cliente.iDCliente = Convert.ToInt32(TxtId.Text);
            tb_Cliente.nombreCliente = TxtNombre.Text;
            tb_Cliente.direccionCliente = TxtDireccion.Text;
            tb_Cliente.duiCliente = TxtDUI.Text;

            cliente.UpdateCliente(tb_Cliente);
            clear();
            Carga();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClsCliente clsCliente = new ClsCliente();
            clsCliente.DeletCliente(Convert.ToInt32(TxtId.Text));
            clear();
            Carga();
        }
    }
}
