using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace UniversidadesWEB.Pags
{
    public partial class AltaCampus : System.Web.UI.Page
    {
        //Variables de clase
        UnisEntities context = new UnisEntities();
        string cadSql;
        List<Servicio> lsServicios;
        List<AreaAcademica> lsAreas;

        protected void llenarDDL<T>(DropDownList ddl, List<T> lista)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btAgregarServicio_Click(object sender, EventArgs e)
        {

        }

        protected void btRegistrarArea_Click(object sender, EventArgs e)
        {

        }
    }
}