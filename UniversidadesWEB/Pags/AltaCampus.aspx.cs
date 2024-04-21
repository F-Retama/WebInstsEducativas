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
		List<Carrera> lsCarreras;
		List<AreaAcademica> lsAreaAcademica;
		List<Servicio> lsServicio;
		CheckBox cb;
		InstitucionCarrera institucionCarrera;
		CampusCarrera campusCarrera;
		CampusServicio campusServicio;
		CampusArea campusArea;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lbMsg.Text = "";

				//Se obtiene el id del campus que se registrar�
				cadSql = $"select * from Campus where idCam = (select max(idCam) from Campus)";
				campus = context.Campus.SqlQuery(cadSql).ToList();
				idCampus = campus[0].idCam + random.Next(10);
				
				//Llenado de los dropdownlists
				cadSql = $"select * from Institucion";
				lsInstitucion = context.Institucion.SqlQuery(cadSql).ToList();
				ddlInstitucion.Items.Add(new ListItem("Sin selecci�n", "-1"));
				foreach (Institucion i in lsInstitucion)
					ddlInstitucion.Items.Add(new ListItem(i.nombreIns.ToString(), i.idIns.ToString()));

				cadSql = $"select * from Ciudad";
				lsCiudad = context.Ciudad.SqlQuery(cadSql).ToList();
				ddlCiudad.Items.Add(new ListItem("Sin selecci�n", "-1"));
				foreach (Ciudad c in lsCiudad)
					ddlCiudad.Items.Add(new ListItem(c.nombreCiu.ToString(), c.idCiu.ToString()));

				//Llenado del checkboxlist de carreras
				cadSql = $"select * from Carrera";
				lsCarreras = context.Carrera.SqlQuery(cadSql).ToList();
				foreach (Carrera car in lsCarreras)
					cblCarreras.Items.Add(new ListItem(car.nombreCarr.ToString(), car.idCar.ToString()));

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
			//se verifica que se tenga la informaci�n necesaria
			if (ddlInstitucion.SelectedIndex>0 && ddlCiudad.SelectedIndex>0) {
				//altas en CampusCarrera
				foreach (ListItem car in cblCarreras.Items)
				{
					//creaci�n del objeto de clase Campus
					campus[0] = new Campus();
					campus[0].idCam = idCampus;
					campus[0].idCiu = Convert.ToInt32(ddlCiudad.SelectedValue);
					campus[0].nombreCam = tbNombre.Text;
					campus[0].domicilio = tbDomicilio.Text;
					campus[0].telefono = tbTelefono.Text;

					//se revisa si la carrera est� seleccionada
					if (car.Selected)
					{
						//para cada carrera, se revisa que la instituci�n ya la imparta
						institucionCarrera = context.InstitucionCarrera.Find(Convert.ToInt32(ddlInstitucion.SelectedValue), Convert.ToInt32(car.Value));
						if (institucionCarrera is null)
						{
							lbMsg.Text += $"\n{ddlInstitucion.Text} no imparte {car.Text}, no se a�adi�";
						}
						else //alta en campus carrera
						{
							campusCarrera = new CampusCarrera();
							campusCarrera.idCam = idCampus;
							campusCarrera.idIns = Convert.ToInt32(ddlInstitucion.SelectedValue);
							campusCarrera.idCar = Convert.ToInt32(car.Value);
							campusCarrera.blank = null;
							lbMsg.Text += campusCarrera.ToString();
							//context.CampusCarrera.Add(campusCarrera);
						}
					}
				}
				//altas de los servicios
				foreach (GridViewRow ser in gvServicios.Rows)
				{
					//se revisa que el servicio se haya seleccionado
					cb = (CheckBox)ser.Cells[0].Controls[0];
					if (cb.Checked)
					{
						campusServicio = new CampusServicio();
						campusServicio.idCam = idCampus;
						campusServicio.idSer = Convert.ToInt32(ser.Cells[3]);
						cb = (CheckBox)ser.Cells[1].Controls[0];
						campusServicio.mismoLugar = Convert.ToInt16(cb.Checked);
						cb = (CheckBox)ser.Cells[2].Controls[0];
						campusServicio.costoExtra = Convert.ToInt16(cb.Checked);
						lbMsg.Text += campusServicio.ToString();
						//context.CampusServicio.Add(campusServicio);
					}
				}
				//altas de las �reas acad�micas
				foreach (GridViewRow area in gvAreas.Rows)
				{
					//se revisa que el �rea se haya seleccionado
					cb = (CheckBox)area.Cells[0].Controls[0];
					if (cb.Checked)
					{
						campusArea = new CampusArea();
						campusArea.idCam = idCampus;
						campusArea.idArea = Convert.ToInt32(area.Cells[4]);
						//campusArea.profsLic = Convert.ToInt32(((TextBox)area.Cells[1].).Text);
					}
				}
			}
		}
    }
}
