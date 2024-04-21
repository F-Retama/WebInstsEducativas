using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

/* La página Alta Campus sirve para dar de alta toda la información asociada con un nuevo campus (punto 5).  
    Esto involucra muchas tablas, por lo cual tiene muchos atributos. */
namespace UniversidadesWEB.Pags
{
	public partial class AltaCampus : System.Web.UI.Page
	{
 		/* Declaración de variables */
		UnisEntities context = new UnisEntities();
		string cadSql;
		int nuevoIdCam;
		Random random = new Random();
		Campus campus;
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
			lbMsg.Text = "";
			//se verifica que se tenga la información necesaria
			if (ddlInstitucion.SelectedIndex > 0 && ddlCiudad.SelectedIndex > 0)
			{
				//creación y alta del objeto de la entidad Campus
				//primero se genera el id del campus que se registrará
				cadSql = $"select * from Campus where idCam = (select max(idCam) from Campus)";
				campus = context.Campus.SqlQuery(cadSql).ToList()[0];
				nuevoIdCam = campus.idCam + random.Next(1, 10);
				campus = new Campus();
				campus.idCam = nuevoIdCam;
				campus.idCiu = Convert.ToInt32(ddlCiudad.SelectedValue);
				campus.nombreCam = tbNombre.Text;
				campus.domicilio = tbDomicilio.Text;
				campus.telefono = tbTelefono.Text;
				context.Campus.Add(campus);
				context.SaveChanges();

				//altas en CampusCarrera
				foreach (ListItem car in cblCarreras.Items)
				{
					//se revisa si la carrera está seleccionada
					if (car.Selected)
					{
						//para cada carrera, se revisa que la institución ya la imparta
						institucionCarrera = context.InstitucionCarrera.Find(Convert.ToInt32(ddlInstitucion.SelectedValue), Convert.ToInt32(car.Value));
						if (institucionCarrera is null)
						{
							lbMsg.Text += $"{ddlInstitucion.Items[ddlInstitucion.SelectedIndex].Text} no imparte {car.Text}, no se añadió.\n";
						}
						else
						{
							//se crea una instancia del vínculo m-n
							campusCarrera = new CampusCarrera();
							campusCarrera.idCam = nuevoIdCam;
							campusCarrera.idIns = Convert.ToInt32(ddlInstitucion.SelectedValue);
							campusCarrera.idCar = Convert.ToInt32(car.Value);
							campusCarrera.blank = null;
							context.CampusCarrera.Add(campusCarrera);
						}
					}
				}
				//altas de los servicios
				foreach (GridViewRow ser in gvServicios.Rows)
				{
					//se revisa que el servicio se haya seleccionado
					cb = (CheckBox)ser.Cells[0].FindControl("CheckBox1");
					if (cb.Checked)
					{
						//se crea una instancia del vínculo m-n
						campusServicio = new CampusServicio();
						campusServicio.idCam = nuevoIdCam;
						campusServicio.idSer = Convert.ToInt32(ser.Cells[3].Text);
						cb = (CheckBox)ser.Cells[1].FindControl("CheckBox2");
						campusServicio.mismoLugar = Convert.ToInt16(cb.Checked);
						cb = (CheckBox)ser.Cells[2].FindControl("CheckBox3");
						campusServicio.costoExtra = Convert.ToInt16(cb.Checked);
						context.CampusServicio.Add(campusServicio);
					}
				}
				//altas de las Áreas académicas
				foreach (GridViewRow area in gvAreas.Rows)
				{
					//se revisa que el área se haya seleccionado
					cb = (CheckBox)area.Cells[0].FindControl("CheckBox1");
					if (cb.Checked)
					{
						try
						{
							//se crea una instancia del vínculo m-n
							campusArea = new CampusArea();
							campusArea.idCam = nuevoIdCam;
							campusArea.idArea = Convert.ToInt32(area.Cells[4].Text);
							campusArea.profsLic = Convert.ToInt32(((TextBox)area.Cells[1].FindControl("tbLics")).Text);
							campusArea.profsMa = Convert.ToInt32(((TextBox)area.Cells[1].FindControl("tbMtros")).Text);
							campusArea.profsDoc = Convert.ToInt32(((TextBox)area.Cells[1].FindControl("tbDocs")).Text);
							context.CampusArea.Add(campusArea);
						}
						//control para entradas no numéricas en los textboxes
						catch (Exception)
						{
							lbMsg.Text += $"Datos del área {area.Cells[5].Text} no válidos, no se añadió.\n";
						}
					}
				}
				context.SaveChanges();
			}
			else
				lbMsg.Text += "Se debe elegir una institucipon y un área.\n";
		}
    }
}
