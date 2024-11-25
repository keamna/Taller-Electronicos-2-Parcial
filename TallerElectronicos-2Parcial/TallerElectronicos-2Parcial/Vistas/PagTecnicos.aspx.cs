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
    public partial class PagTecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
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
            ClsTecnicos.nombreTecnico = TnombreTecnico.Text;
            ClsTecnicos.especialidadTecnico = TespecialidadTecnico.Text; 


            if (TecnicosLogica.AgregarTecnicos(ClsTecnicos.nombreTecnico, ClsTecnicos.especialidadTecnico) > 0)
            {
                MostrarAlerta(this, "Tecnico ingresado");
                TnombreTecnico.Text = "";
                TespecialidadTecnico.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }
        
        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsTecnicos.tecnicoID = int.Parse(TtecnicoID.Text);

            if (TecnicosLogica.BorrarTecnico(ClsTecnicos.tecnicoID) > 0)
            {
                //MostrarAlerta(this, "Tecnico eliminado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsTecnicos.tecnicoID = int.Parse(TtecnicoID.Text);
            ClsTecnicos.nombreTecnico = TnombreTecnico.Text;
            ClsTecnicos.especialidadTecnico = TespecialidadTecnico.Text;


            if (TecnicosLogica.ModificarTecnico(ClsTecnicos.tecnicoID, ClsTecnicos.nombreTecnico, ClsTecnicos.especialidadTecnico) > 0)
            {
                //MostrarAlerta(this, "Equipo modificado");
                TtecnicoID.Text = "";
                TnombreTecnico.Text = "";
                TespecialidadTecnico.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error");
            }
        }
    }
}