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
    public partial class PagDetalleReparacion : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparacion"))
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
            ClsDetalleReparacion.reparacionID= int.Parse(TreparacionID.Text);
            ClsDetalleReparacion.descripcionReparacion = TdescripcionReparacion.Text;
            ClsDetalleReparacion.fechaInicio = TfechaInicio.Text;
            ClsDetalleReparacion.fechaFin = TfechaFin.Text;

            if (DetalleReparacionLogica.AgregarDetalleReparacion(ClsDetalleReparacion.reparacionID, ClsDetalleReparacion.descripcionReparacion, ClsDetalleReparacion.fechaInicio, ClsDetalleReparacion.fechaFin) > 0)
            {
                MostrarAlerta(this, "Detalle ingresado");
                //TreparacionID.Text = "";
                TdescripcionReparacion.Text = "";
                TfechaInicio.Text = "";
                TfechaFin.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {

            ClsDetalleReparacion.detalleID = int.Parse(TdetalleID.Text);
            ClsDetalleReparacion.reparacionID = int.Parse(TreparacionID.Text);
            ClsDetalleReparacion.descripcionReparacion = TdescripcionReparacion.Text;
            ClsDetalleReparacion.fechaInicio = TfechaInicio.Text;
            ClsDetalleReparacion.fechaFin = TfechaFin.Text;

            if (DetalleReparacionLogica.ModificarDetalleReparacion(ClsDetalleReparacion.detalleID, ClsDetalleReparacion.reparacionID, ClsDetalleReparacion.descripcionReparacion, ClsDetalleReparacion.fechaInicio, ClsDetalleReparacion.fechaFin) > 0)
            {
                MostrarAlerta(this, "Detalle modificado");

                TdetalleID.Text = "";
                TreparacionID.Text = "";
                TdescripcionReparacion.Text = "";
                TfechaInicio.Text = "";
                TfechaFin.Text = "";

                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsDetalleReparacion.detalleID = int.Parse(TdetalleID.Text);
            if (DetalleReparacionLogica.BorrarDetalleReparacion(ClsDetalleReparacion.detalleID) > 0)
            {
                MostrarAlerta(this, "Detalle borrado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}