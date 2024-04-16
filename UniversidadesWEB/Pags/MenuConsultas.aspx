<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuConsultas.aspx.cs" Inherits="UniversidadesWEB.Pags.MenuConsultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seleccionar Consultas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btConsulta1" runat="server" OnClick="btConsulta1_Click" Text="Consulta 1" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btConsulta2" runat="server" OnClick="btConsulta2_Click" Text="Consulta 2" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btConsulta3" runat="server" OnClick="btConsulta3_Click" Text="Consulta 3" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btConsulta4" runat="server" OnClick="btConsulta4_Click" Text="Consulta 4" />
            <br />
            <br />
            <asp:Label ID="lbMensaje" runat="server" Text="Elija una consulta para mostrar"></asp:Label>
            <br />
            <asp:GridView ID="gvConsultas" runat="server">
            </asp:GridView>
            <br />
            <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="../Index.aspx">Volver al inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
