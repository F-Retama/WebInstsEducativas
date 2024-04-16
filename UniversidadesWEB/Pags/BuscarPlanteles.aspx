<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPlanteles.aspx.cs" Inherits="UniversidadesWEB.Pags.BuscarPlanteles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;Elige una carrera y una ciudad para mostrar las instituciones y campus que cumplen ambos criterios.<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Carrera:
            <asp:DropDownList ID="ddlCarrera" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ciudad:
            <asp:DropDownList ID="ddlCiudad" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btBuscar" runat="server" OnClick="btBuscar_Click" Text="Buscar" />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvResp" runat="server">
            </asp:GridView>
            <asp:Label ID="lbMensaje" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Index.aspx">Volver al inicio</asp:HyperLink>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
