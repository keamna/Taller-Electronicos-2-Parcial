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
    public partial class PagReparaciones : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reparaciones"))
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
            ClsReparaciones.equipoID = int.Parse(TequipoID.Text);
            ClsReparaciones.fechaSolicitud = TfechaSolicitud.Text;
            ClsReparaciones.estadoReparacion = TestadoReparacion.Text;


            if (ReparacionesLogica.AgregarReparacion(ClsReparaciones.equipoID, ClsReparaciones.fechaSolicitud, ClsReparaciones.estadoReparacion) > 0)
            {
                MostrarAlerta(this, "Reparacion ingresada");
                TequipoID.Text = "";
                TfechaSolicitud.Text = "";
                TestadoReparacion.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsReparaciones.reparacionID = int.Parse(TcodigoReparacion.Text);

            if (ReparacionesLogica.BorrarReparacion(ClsReparaciones.reparacionID) > 0)
            {
                MostrarAlerta(this, "Reparacion eliminada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsReparaciones.reparacionID = int.Parse(TcodigoReparacion.Text);
            ClsReparaciones.equipoID = int.Parse(TequipoID.Text);
            ClsReparaciones.fechaSolicitud = TfechaSolicitud.Text;
            ClsReparaciones.estadoReparacion = TestadoReparacion.Text;


            if (EquiposLogica.ModificarEquipo(ClsEquipos.equipoID, ClsEquipos.tipoEquipo, ClsEquipos.modeloEquipo, ClsEquipos.usuarioID) > 0)
            {
                //MostrarAlerta(this, "Equipo modificado");
                TcodigoReparacion.Text = "";
                TequipoID.Text = "";
                TfechaSolicitud.Text = "";
                TestadoReparacion.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}