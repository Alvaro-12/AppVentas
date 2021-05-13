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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            CargaUsuario();
            Clear();
        }

        void Clear() 
        {
            TxtId.Clear();
            TxtEmail.Clear();
            TxtPass.Clear();
        }

        public void CargaUsuario() 
        {

            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities()) 
            {
                foreach (var iteracion in bd.tb_usuario.ToList()) 
                {
                    dataGridView1.Rows.Add(iteracion.iDUsuario, iteracion.email, iteracion.contrasena);
                }            
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            
        }

        
        public  void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String iDUser = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String email = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String contrasena = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            TxtId.Text = iDUser;
            TxtEmail.Text = email;
            TxtPass.Text = contrasena;

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {     
                ClsUsuarios usuarios = new ClsUsuarios();
                tb_usuario TB_Usuario = new tb_usuario();
                TB_Usuario.email = TxtEmail.Text;
                TB_Usuario.contrasena = TxtPass.Text;

                usuarios.SaveUser(TB_Usuario);

            Clear();
            CargaUsuario();
            

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClsUsuarios clsUsuarios = new ClsUsuarios();
            clsUsuarios.DeletUser(Convert.ToInt32(TxtId.Text));
            Clear();
            CargaUsuario();
            

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ClsUsuarios usuarios = new ClsUsuarios();
            tb_usuario TUsuario = new tb_usuario();

            TUsuario.iDUsuario = Convert.ToInt32(TxtId.Text);
            TUsuario.email = TxtEmail.Text;
            TUsuario.contrasena = TxtPass.Text;

            usuarios.UpdateUser(TUsuario);
            Clear();
            CargaUsuario();
           
        }
    }
}
