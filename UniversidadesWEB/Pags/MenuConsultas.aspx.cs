using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversidadesWEB.Pags
{
    public partial class MenuConsultas : System.Web.UI.Page
    {
        //Clases auxiliares
        //Consulta 1
        public class CiuInstCamp{
            public string Ciudad { get; set; }
            public string Institucion { get; set; }
            public string Campus { get; set; }
        }
        //Consulta 3
        public class CampInst
        {
            public string Campus { get; set; }
            public string Institucion { get; set; }
        }

        //Declaración de variables
        UnisEntities context = new UnisEntities();
        string cadSql;
        List<CiuInstCamp> lsCiuInstCamp;
        List<Institucion> lsInstitucion;
        List<CampInst> lsCampInst;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void mostrar <T> (List<T> lista, string mensaje)
        {
            lbMensaje.Text = mensaje;
            gvConsultas.DataSource = lista;
            gvConsultas.DataBind();
        }

        protected void btConsulta1_Click(object sender, EventArgs e)
        {
            cadSql = "select distinct nombreCiu as Ciudad, nombreIns as Institucion, nombreCam as Campus " +
                "from ciudad cd, institucion i, campus c, campuscarrera cc " +
                "where cd.idciu = c.idciu and c.idcam = cc.idcam and cc.idins = i.idins " +
                "order by nombreCiu";
            lsCiuInstCamp = context.Database.SqlQuery<CiuInstCamp>(cadSql).ToList();
            mostrar(lsCiuInstCamp, "Para cada ciudad, se listan las instituciones y los campus " +
                                    "que se localizan en la misma");
        }

        protected void btConsulta2_Click(object sender, EventArgs e)
        {
            cadSql = "select * from Institucion where idins in " +
                "((select i.idIns from Institucion i, InstitucionCarrera ic, carrera c " +
                "where nombreCarr like 'Ing. en Computación' " +
                "and i.idIns = ic.idIns and ic.idCar = c.idCar) " +
                "INTERSECT " +
                "(select i.idIns from Institucion i, InstitucionCarrera ic, carrera c " +
                "where nombreCarr like 'Ing. en Telemática' " +
                "and i.idIns = ic.idIns and ic.idCar = c.idCar) " +
                "INTERSECT " +
                "(select i.idIns from Institucion i, InstitucionCarrera ic, carrera c " +
                "where nombreCarr like 'Lic. en Matemáticas' " +
                "and i.idIns = ic.idIns and ic.idCar = c.idCar))";
            lsInstitucion = context.Institucion.SqlQuery(cadSql).ToList();
            mostrar(lsInstitucion, "Nombre de las intituciones, sin importar el campus, " +
                                    "donde se imparten las carreras de Ing. en computación, " +
                                    "Ing. en telemática y Lic. en Matemáticas (o sea, todas ellas).");
        }

        protected void btConsulta3_Click(object sender, EventArgs e)
        {
            cadSql = "select distinct nombreCam as Campus, nombreIns as Institucion " +
                "from campus c, campusCarrera cc, institucion i " +
                "where c.idcam = cc.idcam and cc.idins = i.idins and c.idcam in " +
                "(select c.idcam from Campus c, CampusServicio cs " +
                "where c.idcam = cs.idcam and cs.mismolugar = 1 " +
                "group by c.idcam having count(idSer) > 2)";
            lsCampInst = context.Database.SqlQuery<CampInst>(cadSql).ToList();
            mostrar(lsCampInst, "los campus, y su institución, que tienen más de dos servicios " +
                                "adicionales en el mismo sitio del campus");
        }

        protected void btConsulta4_Click(object sender, EventArgs e)
        {
            cadSql = "select * from Institucion where idIns in " +
                "(select idIns from InstitucionCarrera group by idIns " +
                "having count(idCar) = (select count(*) from Carrera)); ";
            lsInstitucion = context.Institucion.SqlQuery(cadSql).ToList();
            mostrar(lsInstitucion, "Instituciones que ofrecen todas las carreras registradas en " +
                                    "la base de datos, sin importar en que campus se imparten");
        }
    }
}