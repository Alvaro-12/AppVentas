using AppVentas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsDocumento
    {
        public List<tb_documento> CargaDocumento() 
        {
            List<tb_documento> tb_Documentos;
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                tb_Documentos = bd.tb_documento.ToList();
            }
            return null;
        }

        //****************************************************************//

        public void SaveDocumento(tb_documento documento)
        {
         try  
         {
                using (sistema_ventasEntities bd1 = new sistema_ventasEntities())
                {
                    tb_documento documento1 = new tb_documento();
                    documento1.iDDocumento = documento.iDDocumento;
                    documento1.nombreDocumento = documento.nombreDocumento;

                    bd1.tb_documento.Add(documento1);
                    bd1.SaveChanges();

                }
            
         }
         catch (Exception ex)
         {
           MessageBox.Show(ex.ToString());
         }

        }
        //*********************************************************************//
        public void DeletDocumento(int IdD)
        {
            try 
            {
                using (sistema_ventasEntities bb = new sistema_ventasEntities()) 
                {
                    int Eliminar = Convert.ToInt32(IdD);
                    tb_documento EliminarDocumento = bb.tb_documento.Where(x => x.iDDocumento == Eliminar).Select(x => x).FirstOrDefault();

                    bb.tb_documento.Remove(EliminarDocumento);
                    bb.SaveChanges();
                }
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //*********************************************************************//
        public void UpdateDocumento(tb_documento DOC)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int Update = Convert.ToInt32(DOC.iDDocumento);
                    tb_documento TDOC = bd.tb_documento.Where(x => x.iDDocumento == Update).Select(x => x).FirstOrDefault();

                    TDOC.nombreDocumento = DOC.nombreDocumento;

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
