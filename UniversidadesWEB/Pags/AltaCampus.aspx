<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCampus.aspx.cs" Inherits="UniversidadesWEB.Pags.AltaCampus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Alta Campus</title>
<style>
body {
font-family: Arial, sans-serif;
background-color: #f0f5f9; 
margin: 0;
padding: 0;
display: flex;
justify-content: center;
align-items: center;
min-height: 100vh; 
}
.container {
text-align: center;
background-color: #cfd8dc; 
padding: 20px;
border-radius: 10px;
box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
max-width: 600px; 
width: 90%; 
}
.button {
background-color: #1565c0;
color: #fff;
border: none;
padding: 10px 20px;
border-radius: 5px;
cursor: pointer;
transition: background-color 0.3s ease;
margin-top: 10px;
}
.button:hover {
background-color: #0d47a1;
}
.label {
color: #1565c0;
font-weight: bold;
}
.link {
color: #1565c0;
text-decoration: none;
margin-top: 20px;
display: block;
}

input[type="text"],
select {
width: calc(100% - 20px);
padding: 8px;
margin: 6px 0;
border-radius: 5px;
border: 1px solid #ccc;
box-sizing: border-box;
}
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="container">
<p> Llena cada campo para dar de alta un campus<br /></p>
<br />
Institucion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True">
</asp:DropDownList>
&nbsp;
<br />
Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbNombre" runat="server" Width="235px"></asp:TextBox>
<br />
Domicilio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbDomicilio" runat="server" Width="212px"></asp:TextBox>
<br />
Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbTelefono" runat="server" Width="227px"></asp:TextBox>
<br />
Ciudad: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True">
</asp:DropDownList>
<br />
<br />
Carreras que se imparten:
<br />
<br />
<asp:CheckBoxList ID="cblCarreras" runat="server" CssClass="auto-style1" style="z-index: 1">
</asp:CheckBoxList>
<br />
Agregar servicios adicionales&nbsp;
<br />
<br />
<asp:DropDownList ID="ddlServicios" runat="server" AutoPostBack="True">
</asp:DropDownList>
<br />
<br />
<asp:CheckBox ID="cbCostoExtra" runat="server" Text="Tiene costo extra" />
<br />
&nbsp;&nbsp;&nbsp;
<asp:CheckBox ID="cbDentroCampus" runat="server" Text="Esta dentro del campus" />
<br />
<asp:Button ID="btAgregarServicio" runat="server" OnClick="btAgregarServicio_Click" Text="Agregar Servicio" CssClass="button" />
<br />
<br />
Servicios registrados <asp:GridView ID="gvServicios" runat="server">
<Columns>
<asp:ButtonField Text="Eliminar" />
</Columns>
</asp:GridView>
<br />
<br />
    Areas academicas&nbsp;&nbsp;&nbsp;
<br />
<asp:DropDownList ID="ddlAreas" runat="server" AutoPostBack="True">
</asp:DropDownList>
<br />
&nbsp;&nbsp;&nbsp; No. de profesores con:<br />
&nbsp;&nbsp;&nbsp; Licenciatura
<asp:TextBox ID="TextBox1" runat="server" Width="136px"></asp:TextBox>
<br />
Maestria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox2" runat="server" Width="138px"></asp:TextBox>
<br />
&nbsp;&nbsp;&nbsp; Doctorado&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox3" runat="server" Width="135px"></asp:TextBox>
<br />
<asp:Button ID="btRegistrarArea" runat="server" OnClick="btRegistrarArea_Click" Text="Registrar Area" CssClass="button" />
<br />
<br />
<br />
    Areas registradas<asp:GridView ID="GridView2" runat="server">
<Columns>
<asp:BoundField />
<asp:ButtonField Text="Eliminar" />
</Columns>
</asp:GridView>
<br />
<br />
<asp:Button ID="btAlta" runat="server" Text="Dar Plantel de Alta" CssClass="button" OnClick="btAlta_Click" />
<br />
<asp:HyperLink ID="hl1" runat="server" NavigateUrl="../Index.aspx" CssClass="link">Volver al inicio</asp:HyperLink>
<br />
</div>
</form>
</body>
</html>
