<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagReparaciones.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.PagReparaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reparaciones</title>
    <link rel="stylesheet" href="CSS/ReparacionesEstilos.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Reparaciones</h1>
           <br />
             <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
           <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
           <br />

           Reparacion ID
           <asp:TextBox ID="TcodigoReparacion" runat="server"></asp:TextBox>
           <br />
           Equipo ID
           <asp:TextBox ID="TequipoID" runat="server"></asp:TextBox>
           <br />
           Fecha Solicitud
           <asp:TextBox ID="TfechaSolicitud" runat="server"></asp:TextBox>
           <br />
           Estado
           <asp:TextBox ID="TestadoReparacion" runat="server"></asp:TextBox>
           <br />
           <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
           <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
           <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />

        </div>
    </form>
</body>
</html>
