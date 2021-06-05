using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDVenta
    {
        public List<tb_venta> UltimaVenta() 
        {
            List<tb_venta> consultarultimaventa = new List<tb_venta>();
            using (sistema_ventasEntities bd = new sistema_ventasEntities()) 
            {
                consultarultimaventa = bd.tb_venta.ToList();


            }
                return consultarultimaventa;
        }

        public void save(tb_venta ventas) 
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                tb_venta Venta = new tb_venta();

                Venta.iDDocumento = ventas.iDDocumento;
                Venta.iDCliente = ventas.iDCliente;
                Venta.iDUsuario = ventas.iDUsuario;
                Venta.iDVenta = ventas.iDVenta;
                Venta.fecha = ventas.fecha;

                bd.tb_venta.Add(Venta);
                bd.SaveChanges();

            }
        
        }

    }
}
