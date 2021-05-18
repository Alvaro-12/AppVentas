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
    public partial class FrmMenuVenta : Form
    {
        public FrmMenuVenta()
        {
            InitializeComponent();
        }
        //****
        public static FrmVenta venta = new FrmVenta();
        //****

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            venta.Show();
        }
    }
}
