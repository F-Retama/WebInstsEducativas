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
		List<Campus> campus;
		int idCampus;
		Random random = new Random();
		List<Ciudad> lsCiudad;
		List<Institucion> lsInstitucion;
		List<AreaAcademica> lsAreaAcademica;
		List<Servicio> lsServicio;
		CampusCarrera campusCarrera;
		CampusServicio campusServicio;
		CampusArea campusArea;
		List<CampusCarrera> lsCampusCarrera;
		List<CampusServicio> lsCampusServicio;
		List<CampusArea> lsCampusArea;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//se inicializan listas que se usarán para el alta
				lsCampusCarrera = new List<CampusCarrera>();
				lsCampusServicio = new List<CampusServicio>();
				lsCampusArea = new List<CampusArea>();

				//Se obtiene el id del campus que se registrará
				cadSql = $"select * from Campus where idCam = (select max(idCam) from Campus)";
				campus = context.Campus.SqlQuery(cadSql).ToList();
				idCampus = campus[0].idCam + random.Next(10);
				
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

				//Llenado de gridviews
				cadSql = $"select * from Servicio";
				lsServicio = context.Servicio.SqlQuery(cadSql).ToList();
				gvServicios.DataSource = lsServicio;
				gvServicios.DataBind(); 
				cadSql = $"select * from AreaAcademica";
				lsAreaAcademica = context.AreaAcademica.SqlQuery(cadSql).ToList();
				gvAreas.DataSource = lsAreaAcademica;
				gvAreas.DataBind();
			}
		}

        protected void btAlta_Click(object sender, EventArgs e)
        {

        }
    }
}
