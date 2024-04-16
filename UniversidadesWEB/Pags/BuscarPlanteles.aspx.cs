using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversidadesWEB.Pags
{
    public partial class BuscarPlanteles : System.Web.UI.Page
    {
        //Clase auxiliar
        public class CampInst
        {
            public string Campus { get; set; }
            public string Institucion { get; set; }
        }
        //Variables de clase
        UnisEntities context = new UnisEntities();
        Carrera carrera;
        Ciudad ciudad;
        List<Carrera> lsCarreras;
        List<Ciudad> lsCiudad;
        List<CampInst> lsCampInst;
        string cadSql;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se realizan los strings correspondientes para cada carrera
                cadSql = $"select distinct * from Carrera";
                lsCarreras = context.Carrera.SqlQuery(cadSql).ToList();
                //Se agrega una fila vacía para una mejor visualización de la página
                ddlCarrera.Items.Add(new ListItem("Sin selección", "-1"));
                //Se llena el dropdownlist con los nombres de las carreras
                foreach (Carrera c in lsCarreras)
                {
                    ddlCarrera.Items.Add(new ListItem(c.nombreCarr.ToString(), c.idCar.ToString()));
                }

                //Se realizan los strings correspondientes para cada ciudad
                cadSql = $"select distinct * from Ciudad";
                lsCiudad = context.Ciudad.SqlQuery(cadSql).ToList();
                //Se agrega una fila vacía para una mejor visualización de la página
                ddlCiudad.Items.Add(new ListItem("Sin selección", "-1"));
                //Se llena el dropdownlist con los nombres de las ciudades
                foreach (Ciudad c in lsCiudad)
                {
                    ddlCiudad.Items.Add(new ListItem(c.nombreCiu.ToString(), c.idCiu.ToString()));
                }
            }
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            carrera = context.Carrera.Find(Int32.Parse(ddlCarrera.SelectedValue));
            ciudad = context.Ciudad.Find(Int32.Parse(ddlCiudad.SelectedValue));
            if (ddlCarrera.SelectedIndex == 0 || ddlCiudad.SelectedIndex == 0)
            {
                gvResp.DataSource = null;
                lbMensaje.Text = "Selecciona opciones válidas";
            }
            else
            {
                cadSql = $"select nombreCam as Campus, nombreIns as Institucion " +
                    $"from campus m, CampusCarrera cc, InstitucionCarrera ic, Institucion i " +
                    $"where m.idCam = cc.idCam and cc.idCar = ic.idCar and cc.idIns = ic.idIns " +
                    $"and ic.idIns = i.idIns and ic.idCar = {carrera.idCar} and idCiu = {ciudad.idCiu} " +
                    $"order by nombreIns";
                lsCampInst = context.Database.SqlQuery<CampInst>(cadSql).ToList();
                gvResp.DataSource = lsCampInst;
                lbMensaje.Text = "";
                if (lsCampInst.Count == 0)
                {
                    lbMensaje.Text = "No hay resultados que cumplan la búsqueda.";
                }
            }
            gvResp.DataBind();
        }
    }
}