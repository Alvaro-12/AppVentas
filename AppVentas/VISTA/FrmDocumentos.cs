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
    public partial class FrmDocumentos : Form
    {
        public FrmDocumentos()
        {
            InitializeComponent();
            Clear();
            cargaDoc();
        }
        void Clear() 
        {
            TxtiDDocumento.Clear();
            TxtNombreDocumento.Clear();
        }

        void cargaDoc()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                foreach (var iteracion in bd.tb_documento.ToList())
                {
                    dataGridView1.Rows.Add(iteracion.iDDocumento,iteracion.nombreDocumento);
                }
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String iDDocumento = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Documento = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            TxtiDDocumento.Text = iDDocumento;
            TxtNombreDocumento.Text = Documento;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClsDocumento documento = new ClsDocumento();
            tb_documento tbdoc = new tb_documento();
            //tbdoc.iDDocumento = Convert.ToInt32(TxtiDDocumento.Text);
            tbdoc.nombreDocumento = TxtNombreDocumento.Text;
            documento.SaveDocumento(tbdoc);
            Clear();
            cargaDoc();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ClsDocumento documento = new ClsDocumento();
            tb_documento doc = new tb_documento();

            doc.iDDocumento = Convert.ToInt32(TxtiDDocumento.Text);
            doc.nombreDocumento = TxtNombreDocumento.Text;
 

            documento.UpdateDocumento(doc);
            Clear();
            cargaDoc();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClsDocumento documento = new ClsDocumento();
            documento.DeletDocumento(Convert.ToInt32(TxtiDDocumento.Text));

            Clear();
            cargaDoc();

        }

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
           
        }
    }
}
