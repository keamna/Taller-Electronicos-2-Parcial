<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagUsuarios.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
    <link rel="stylesheet" href="CSS/UsuariosEstilos.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Usuarios</h1>
            <br />
            <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
            
            <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
            <br />

            Usuario ID
            <asp:TextBox ID="TusuarioID" runat="server"></asp:TextBox>
            <br />
            Nombre
            <asp:TextBox ID="TnombreUsuario" runat="server"></asp:TextBox>
            <br />
            Correo Electronico
            <asp:TextBox ID="Tcorreo" runat="server"></asp:TextBox>
            <br />
            Telefono
            <asp:TextBox ID="Ttelefono" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
            <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
            <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />


        </div>
    </form>
</body>
</html>
