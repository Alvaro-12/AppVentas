using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsCliente
    {
        public List<tb_cliente> CargaCliente()
        {
            List<tb_cliente> Lista;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                Lista = bd.tb_cliente.ToList();
            }
            return null;
        }
        //*******************************************************************
        //***********************//
        public void SaveCliente(tb_cliente clienteSb)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    tb_cliente Cliente = new tb_cliente();

                    Cliente.nombreCliente = clienteSb.nombreCliente;
                    Cliente.direccionCliente = clienteSb.direccionCliente;
                    Cliente.duiCliente = clienteSb.duiCliente;
                    bd.tb_cliente.Add(Cliente);
                   
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //**********************//
        public void DeletCliente(int Idcliente)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Eliminar = Convert.ToInt32(Idcliente);
                    tb_cliente EliminarCliente = bd.tb_cliente.Where(x => x.iDCliente == Eliminar).Select(x => x).FirstOrDefault();

                    bd.tb_cliente.Remove(EliminarCliente);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //*********************//
        public void UpdateCliente(tb_cliente ClienteUp)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Update = Convert.ToInt32(ClienteUp.iDCliente);
                    tb_cliente tb_Cliente = bd.tb_cliente.Where(x => x.iDCliente == Update).Select(x => x).FirstOrDefault();

                    tb_Cliente.nombreCliente = ClienteUp.nombreCliente;
                    tb_Cliente.direccionCliente = ClienteUp.direccionCliente;
                    tb_Cliente.duiCliente = ClienteUp.duiCliente;

                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //*********************************************************************************
         
        public List<tb_cliente> cargarcombocliente() 
        {
            List<tb_cliente> Cliente = new List<tb_cliente>();
            using (sistema_ventasEntities bd = new sistema_ventasEntities()) 
            {
                Cliente = bd.tb_cliente.ToList();

            }
                return null;
        } 
        
    }
}
