<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagDetalleReparacion.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.PagDetalleReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Detalle Reparaciones</title>
    <link rel="stylesheet" href="CSS/DetalleReparacionesEstilos.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Detalle Reparacion</h1>
           <br />
             <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
           <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
           <br />

           Detalle ID:
           <asp:TextBox ID="TdetalleID" runat="server"></asp:TextBox>
           <br />
            Reparacion ID:
            <asp:TextBox ID="TreparacionID" runat="server"></asp:TextBox>
           <br />
           Descripcion:
           <asp:TextBox ID="TdescripcionReparacion" runat="server"></asp:TextBox>
           <br />
           Fecha inicio:
           <asp:TextBox ID="TfechaInicio" runat="server"></asp:TextBox>
           <br />
           Fecha fin: 
           <asp:TextBox ID="TfechaFin" runat="server"></asp:TextBox>
           <br />
           <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
           <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
           <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />

        </div>
    </form>
</body>
</html>
