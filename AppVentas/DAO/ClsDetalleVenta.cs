using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsDetalleVenta
    {
        //Refresca nuestro datagridview//
        public List<tb_detalleVenta> Carga()
        {
            List<tb_detalleVenta> Lista;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                Lista = bd.tb_detalleVenta.ToList();
            }
            return null;
        }


        //GuardarDetalleVenta//
        public void SaveVenta(tb_detalleVenta detalleVenta) 
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    tb_detalleVenta Venta = new tb_detalleVenta();

                    Venta.iDVenta = detalleVenta.iDVenta;
                    Venta.iDProducto = detalleVenta.iDProducto;
                    Venta.cantidad = detalleVenta.cantidad;
                    Venta.precio = detalleVenta.precio;
                    Venta.total = detalleVenta.total;

                    bd.tb_detalleVenta.Add(Venta);

                    bd.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void UpVenta(tb_detalleVenta UpVenta1) 
        {
            try 
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Update = Convert.ToInt32(UpVenta1.iDDetalleVenta);
                    tb_detalleVenta tb = bd.tb_detalleVenta.Where(x => x.iDDetalleVenta == Update).Select(x => x).FirstOrDefault();

                    tb.iDVenta = UpVenta1.iDVenta;
                    tb.iDProducto = UpVenta1.iDProducto;
                    tb.cantidad = UpVenta1.cantidad;
                    tb.precio = UpVenta1.precio;
                    tb.total = UpVenta1.total;

                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeletVenta(int IDVenta) 
        {
            try 
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Eliminar = Convert.ToInt32(IDVenta);
                    tb_detalleVenta EliminarVenta = bd.tb_detalleVenta.Where(x => x.iDDetalleVenta == Eliminar).Select(x => x).FirstOrDefault();

                    bd.tb_detalleVenta.Remove(EliminarVenta);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
