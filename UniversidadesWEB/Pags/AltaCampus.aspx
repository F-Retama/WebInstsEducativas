<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCampus.aspx.cs" Inherits="UniversidadesWEB.Pags.AltaCampus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Alta Campus</title>
<style>
     /* Clase para declarar atributos de la página Alta Campus y darle un estilo común con las demas páginas 
    <style> es el estilo en CSS para que los elementos estén centrados, con letra moderna, y los atributos estilizados */

    /* Características para que el contenedor este centrado y tenga una letra uniforme */
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
    /* Características para que el centro de la página sea azul y todo este centrado */
    .container {
        text-align: center;
        background-color: #cfd8dc; 
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        max-width: 600px; 
        width: 90%; 
    }
    /* Cuando un botón tiene CssClass="button", se dan las siguientes características: */
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
    /* Cuando un link tiene CssClass="link", se dan las siguientes características: */
    .link {
        color: #1565c0;
        text-decoration: none;
        margin-top: 20px;
        display: block;
    }
    /* Para darle estilo a los elementos input de texto y select */
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
Institución:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True">
</asp:DropDownList>
&nbsp;
<br />
Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbNombre" runat="server" Width="235px"></asp:TextBox>
<br />
Domicilio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbDomicilio" runat="server" Width="212px"></asp:TextBox>
<br />
Teléfono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbTelefono" runat="server" Width="227px"></asp:TextBox>
<br />
Ciudad: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True">
</asp:DropDownList>
<br />
    <br />
<br />
Carreras que se imparten:
<br />
<br />
<asp:CheckBoxList ID="cblCarreras" runat="server" CssClass="auto-style1" style="z-index: 1">
</asp:CheckBoxList>
<br />
    <br />
Agregar servicios adicionales&nbsp;
<br />
    <asp:GridView ID="gvServicios" runat="server">
<Columns>
    <asp:TemplateField HeaderText="Añadir">
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </EditItemTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="En campus">
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </EditItemTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Costo extra">
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBox3" runat="server" />
        </EditItemTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="CheckBox3" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<br />
<br />
    Áreas académicas&nbsp;&nbsp;&nbsp; <br />
    <asp:GridView ID="gvAreas" runat="server">
<Columns>
    <asp:TemplateField HeaderText="Añadir">
        <EditItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </EditItemTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Num. Lics.">
        <ItemTemplate>
            <asp:TextBox ID="tbLics" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Num. Mtros.">
        <ItemTemplate>
            <asp:TextBox ID="tbMtros" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Num. Docs.">
        <ItemTemplate>
            <asp:TextBox ID="tbDocs" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<br />
    <asp:Label ID="lbMsg" runat="server"></asp:Label>
<br />
<asp:Button ID="btAlta" runat="server" Text="Dar Plantel de Alta" CssClass="button" OnClick="btAlta_Click" />
<br />
<asp:HyperLink ID="hl1" runat="server" NavigateUrl="../Index.aspx" CssClass="link">Volver al inicio</asp:HyperLink>
<br />
</div>
</form>
</body>
</html>
