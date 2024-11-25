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
    public partial class PagEquipos : System.Web.UI.Page
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

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            ClsEquipos.tipoEquipo = TtipoEquipo.Text;
            ClsEquipos.modeloEquipo = TmodeloEquipo.Text;
            ClsEquipos.usuarioID = int.Parse(TCodigoUsuarioEquipo.Text);
            

            if (EquiposLogica.AgregarEquipos(ClsEquipos.tipoEquipo, ClsEquipos.modeloEquipo, ClsEquipos.usuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo ingresado");
                TtipoEquipo.Text = "";
                TmodeloEquipo.Text = "";
                TCodigoUsuarioEquipo.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsEquipos.equipoID = int.Parse(TcodigoEquipo.Text);

            if (EquiposLogica.BorrarEquipo(ClsEquipos.equipoID) > 0)
            {
                MostrarAlerta(this, "Equipo eliminado");
                LlenarGrid();
            }
            else 
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsEquipos.equipoID= int.Parse(TcodigoEquipo.Text);
            ClsEquipos.tipoEquipo = TtipoEquipo.Text;
            ClsEquipos.modeloEquipo = TmodeloEquipo.Text;
            ClsEquipos.usuarioID = int.Parse(TCodigoUsuarioEquipo.Text);


            if (EquiposLogica.ModificarEquipo(ClsEquipos.equipoID, ClsEquipos.tipoEquipo, ClsEquipos.modeloEquipo, ClsEquipos.usuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo modificado");
                TcodigoEquipo.Text = "";
                TtipoEquipo.Text = "";
                TmodeloEquipo.Text = "";
                TCodigoUsuarioEquipo.Text = "";
                LlenarGrid();
            }
            else 
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}