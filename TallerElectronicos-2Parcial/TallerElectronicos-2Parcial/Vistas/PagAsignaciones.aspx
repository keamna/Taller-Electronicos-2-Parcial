<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagAsignaciones.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.PagAsignaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignaciones</title>
    <link rel="stylesheet" href="CSS/AsignacionesEstilos.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <h1>Asignaciones</h1>
           <br />
             <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
           <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
           <br />
         
           Asignacion ID:
           <asp:TextBox ID="TasignacionID" runat="server"></asp:TextBox>
           <br />
           Reparacion ID:
           <asp:TextBox ID="TreparacionID" runat="server"></asp:TextBox>
           <br />
            Tecnico ID:
           <asp:TextBox ID="TtecnicoID" runat="server"></asp:TextBox>
           <br />
            Fecha Asignacion:
            <asp:TextBox ID="TfechaAsignacion" runat="server"></asp:TextBox>
            <br />
           <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" style="height: 29px" />
           <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
           <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" Height="29px" />

        </div>
    </form>
</body>
</html>
