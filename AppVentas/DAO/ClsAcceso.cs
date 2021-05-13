using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsAccseso
    {
        public int accseso(String usuario, String password)
        {
            int variabledeacceso = 0;
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                var consulta = from user in bd.tb_usuario
                               where user.email == usuario && user.contrasena == password
                               select user;

                if (consulta.Count() > 0)
                {
                    variabledeacceso = 1;

                }


            }

            return variabledeacceso;
        }

    }
}
