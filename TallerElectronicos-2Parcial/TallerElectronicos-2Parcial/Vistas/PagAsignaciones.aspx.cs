using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TallerElectronicos_2Parcial.CapaLogica;
using TallerElectronicos_2Parcial.CapaModelo;

namespace TallerElectronicos_2Parcial.Vistas
{
    public partial class PagAsignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {

            ClsAsignaciones.reparacionID = int.Parse(TreparacionID.Text);
            ClsAsignaciones.tecnicoID =int.Parse(TtecnicoID.Text);
            ClsAsignaciones.fechaAsignacion = TfechaAsignacion.Text;

            if (AsignacionesLogica.AgregarAsignacion(ClsAsignaciones.asignacionID, ClsAsignaciones.tecnicoID, ClsAsignaciones.fechaAsignacion) > 0)
            {
                MostrarAlerta(this, "Asignacion ingresada");
                TreparacionID.Text = "";
                TtecnicoID.Text = "";
                TfechaAsignacion.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }

        }

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsAsignaciones.asignacionID = int.Parse(TasignacionID.Text);

            if (AsignacionesLogica.BorrarAsignacion(ClsAsignaciones.asignacionID) > 0)
            {
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsAsignaciones.asignacionID = int.Parse(TasignacionID.Text);
            ClsAsignaciones.reparacionID = int.Parse(TreparacionID.Text);
            ClsAsignaciones.tecnicoID = int.Parse(TtecnicoID.Text);
            ClsAsignaciones.fechaAsignacion = TfechaAsignacion.Text;


            if (AsignacionesLogica.ModificarAsignacion(ClsAsignaciones.asignacionID, ClsAsignaciones.reparacionID, ClsAsignaciones.tecnicoID, ClsAsignaciones.fechaAsignacion) > 0)
            {
                //MostrarAlerta(this, "Asignacion ingresada");
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}