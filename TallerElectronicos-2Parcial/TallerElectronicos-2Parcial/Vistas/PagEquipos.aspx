<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagEquipos.aspx.cs" Inherits="TallerElectronicos_2Parcial.Vistas.PagEquipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Equipos</title>
    <link rel="stylesheet" href="CSS/EquiposEstilos.css"/>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Equipos</h1>
           <br />
             <a href="PagInicio.aspx" class="inicio-link">Inicio</a>
           <asp:GridView ID="GridView1" runat="server" CssClass="aspGridView" Width="910px"></asp:GridView>
           <br />

           Equipo ID:
           <asp:TextBox ID="TcodigoEquipo" runat="server"></asp:TextBox>
           <br />
           Tipo de equipo:
           <asp:TextBox ID="TtipoEquipo" runat="server"></asp:TextBox>
           <br />
           Modelo:
           <asp:TextBox ID="TmodeloEquipo" runat="server"></asp:TextBox>
           <br />
           Codigo usuario
           <asp:TextBox ID="TCodigoUsuarioEquipo" runat="server"></asp:TextBox>
           <br />
           <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
           <asp:Button ID="Beliminar" runat="server" Text="Borrar" OnClick="Beliminar_Click" />
           <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />

        </div>
    </form>
</body>
</html>
