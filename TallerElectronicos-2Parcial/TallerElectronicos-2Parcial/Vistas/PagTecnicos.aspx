<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagTecnicos.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.PagTecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tecnicos</title>
    <link rel="stylesheet" href="CSS/TecnicosEstilos.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Tecnicos</h1>
           <br />
            <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
           <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
           <br />

         
           Tecnico ID
           <asp:TextBox ID="TtecnicoID" runat="server"></asp:TextBox>
           <br />
           Nombre
           <asp:TextBox ID="TnombreTecnico" runat="server"></asp:TextBox>
           <br />
           Especialidad
           <asp:TextBox ID="TespecialidadTecnico" runat="server"></asp:TextBox>
           <br />
        <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
        <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
        <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />


        </div>
    </form>
</body>
</html>
