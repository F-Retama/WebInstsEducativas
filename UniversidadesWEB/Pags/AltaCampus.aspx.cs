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
		UnisEntities context = new UnisEntities();
		string cadSql;
		List<Ciudad> lsCiudad;
		List<Institucion> lsInstitucion;
		List<AreaAcademica> lsAreaAcademica;
		List<Servicio> lsServicio;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				cadSql = $"select * from Institucion";
				lsInstitucion = context.Institucion.SqlQuery(cadSql).ToList();
				ddlInstitucion.Items.Add("");
				foreach (Institucion i in lsInstitucion)
					ddlInstitucion.Items.Add(i.nombreIns.ToString());

				cadSql = $"select * from Ciudad";
				lsCiudad = context.Ciudad.SqlQuery(cadSql).ToList();
				ddlCiudad.Items.Add("");
				foreach (Ciudad c in lsCiudad)
					ddlCiudad.Items.Add(c.nombreCiu.ToString());

				cadSql = $"select * from Servicio";
				lsServicio = context.Servicio.SqlQuery(cadSql).ToList();
				ddlServicios.Items.Add("");
				foreach (Servicio s in lsServicio)
					ddlServicios.Items.Add(s.nombre.ToString());

				cadSql = $"select * from AreaAcademica";
				lsAreaAcademica = context.AreaAcademica.SqlQuery(cadSql).ToList();
				ddlCiudad.Items.Add("");
				foreach (AreaAcademica a in lsAreaAcademica)
					ddlCiudad.Items.Add(a.nombre.ToString());
			}
		}

		protected void btAgregarServicio_Click(object sender, EventArgs e)
		{

		}

		protected void btRegistrarArea_Click(object sender, EventArgs e)
		{

		}

        protected void btAlta_Click(object sender, EventArgs e)
        {

        }
    }
}
