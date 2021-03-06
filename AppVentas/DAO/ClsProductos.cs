using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsProductos
    {
       public List<tb_producto> Carga(string filtro)
        {
            List<tb_producto> Lista = new List<tb_producto>(); 

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                Lista = bd.tb_producto.ToList();
                Lista = (from listadoproductos in bd.tb_producto
                         where listadoproductos.nombreProducto.Contains(filtro)
                         select listadoproductos).ToList();
            }
            return Lista;
        }

        public List<tb_producto> BuscarProductos(int Codigo)
        {
            List<tb_producto> Lista = new List<tb_producto>(); 

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                Lista = bd.tb_producto.ToList();
                Lista = (from listadoproductos in bd.tb_producto
                         where listadoproductos.idProducto == Codigo
                         select listadoproductos).ToList();
            }
            return Lista;
        }




        //*************************************************************************************//
        public void SaveProducto(tb_producto productoS)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    tb_producto tb_Producto = new tb_producto();

                    tb_Producto.nombreProducto = productoS.nombreProducto;
                    tb_Producto.precioProducto = productoS.precioProducto;
                    tb_Producto.estadoProducto = productoS.estadoProducto;
                    bd.tb_producto.Add(tb_Producto);

                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //**********************//
        public void DeletProducto(int IdProducto)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Eliminar = Convert.ToInt32(IdProducto);
                    tb_producto ElimiarD = bd.tb_producto.Where(x => x.idProducto == Eliminar).Select(x => x).FirstOrDefault();

                    bd.tb_producto.Remove(ElimiarD);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //*********************//
        public void UpdateProducto(tb_producto ProductoUp)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Update = Convert.ToInt32(ProductoUp.idProducto);
                    tb_producto PRODUCTO = bd.tb_producto.Where(x => x.idProducto == Update).Select(x => x).FirstOrDefault();

                    PRODUCTO.idProducto  = ProductoUp.idProducto;
                    PRODUCTO.nombreProducto = ProductoUp.nombreProducto;
                    PRODUCTO.precioProducto = ProductoUp.precioProducto;
                    PRODUCTO.estadoProducto = ProductoUp.estadoProducto;

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
