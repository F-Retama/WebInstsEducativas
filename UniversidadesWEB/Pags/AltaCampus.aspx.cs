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
				//Llenado de los dropdownlists
				cadSql = $"select * from Institucion";
				lsInstitucion = context.Institucion.SqlQuery(cadSql).ToList();
				ddlInstitucion.Items.Add(new ListItem("Sin selección", "-1"));
				foreach (Institucion i in lsInstitucion)
					ddlInstitucion.Items.Add(new ListItem(i.nombreIns.ToString(), i.idIns.ToString()));

				cadSql = $"select * from Ciudad";
				lsCiudad = context.Ciudad.SqlQuery(cadSql).ToList();
				ddlCiudad.Items.Add(new ListItem("Sin selección", "-1"));
				foreach (Ciudad c in lsCiudad)
					ddlCiudad.Items.Add(new ListItem(c.nombreCiu.ToString(), c.idCiu.ToString()));

				cadSql = $"select * from Servicio";
				lsServicio = context.Servicio.SqlQuery(cadSql).ToList();
				ddlServicios.Items.Add(new ListItem("Sin selección", "-1"));
				foreach (Servicio s in lsServicio)
					ddlServicios.Items.Add(new ListItem(s.nombre.ToString(), s.idSer.ToString()));

				cadSql = $"select * from AreaAcademica";
				lsAreaAcademica = context.AreaAcademica.SqlQuery(cadSql).ToList();
				ddlCiudad.Items.Add(new ListItem("Sin selección", "-1"));
				foreach (AreaAcademica a in lsAreaAcademica)
					ddlCiudad.Items.Add(new ListItem(a.nombre.ToString(), a.idArea.ToString()));
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
