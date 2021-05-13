using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsUsuarios
    {
        public List<tb_usuario> CargaUsuario()
        {
            List<tb_usuario> Lista;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                Lista = bd.tb_usuario.ToList();
            }
            return null;
        }




        //***************************************************//
        //GUARDADO//
        public void SaveUser(tb_usuario user) 
        {
                try
                {
                   using (sistema_ventasEntities bd = new sistema_ventasEntities())
                   {
                    tb_usuario usuario = new tb_usuario();

                    usuario.email = user.email;
                    usuario.contrasena = user.contrasena;

                    //igual a un inser//
                    bd.tb_usuario.Add(usuario);
                    ////
                    bd.SaveChanges();
                   }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }
        //******************************************************************//
        //DELET//
        public void DeletUser(int IDuser) 
        {
            try 
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Eliminar = Convert.ToInt32(IDuser);
                    tb_usuario EliminarUsuario = bd.tb_usuario.Where(x => x.iDUsuario == Eliminar).Select(x => x).FirstOrDefault();
                    
                    bd.tb_usuario.Remove(EliminarUsuario);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //******************************************************************//
        //UPDATE//
        public void UpdateUser(tb_usuario user)
        {

            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Update = Convert.ToInt32(user.iDUsuario);
                    tb_usuario tb_Usuario = bd.tb_usuario.Where(x => x.iDUsuario == Update).Select(x => x).FirstOrDefault();

                    tb_Usuario.email = user.email;
                    tb_Usuario.contrasena = user.contrasena;

                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //************************************************************************

    }
}
