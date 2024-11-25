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
using System.Net.Sockets;

namespace TallerElectronicos_2Parcial.Vistas
{
    public partial class Usuarios : System.Web.UI.Page
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
            ClsUsuarios.nombreUsuario = TnombreUsuario.Text;
            ClsUsuarios.correoElectronico = Tcorreo.Text;
            ClsUsuarios.telefono = Ttelefono.Text;

            if (UsuariosLogica.AgregarUsuarios(ClsUsuarios.nombreUsuario, ClsUsuarios.correoElectronico, ClsUsuarios.telefono) > 0)
            {
                MostrarAlerta(this, "Usuario ingresado");
                TnombreUsuario.Text = "";
                Tcorreo.Text = "";
                Ttelefono.Text = "";
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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

       
        protected void Bmodificar_Click(object sender, EventArgs e)
        {

            ClsUsuarios.usuarioID = int.Parse(TusuarioID.Text);
            ClsUsuarios.nombreUsuario = TnombreUsuario.Text;
            ClsUsuarios.correoElectronico = Tcorreo.Text;
            ClsUsuarios.telefono = Ttelefono.Text;

            if (UsuariosLogica.ModificarUsuario(ClsUsuarios.usuarioID,ClsUsuarios.nombreUsuario, ClsUsuarios.correoElectronico, ClsUsuarios.telefono) > 0)
            {
                MostrarAlerta(this, "Usuario modificado");

                TusuarioID.Text = "";
                TnombreUsuario.Text = "";
                Tcorreo.Text = "";
                Ttelefono.Text = "";
                
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.usuarioID = int.Parse(TusuarioID.Text);
            if (UsuariosLogica.BorrarUsuarios(ClsUsuarios.usuarioID) > 0)
            {
                //MostrarAlerta(this, "Usuario borrado");
                LlenarGrid();
            }
            else 
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}