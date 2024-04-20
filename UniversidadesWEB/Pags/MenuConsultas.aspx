<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuConsultas.aspx.cs" Inherits="UniversidadesWEB.Pags.MenuConsultas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seleccionar Consultas</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f5f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            text-align: center;
            background-color: #e3f2fd;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .button {
            background-color: #1565c0;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .button:not(:last-child) {
            margin-right: 20px;
        }
        .button:hover {
            background-color: #0d47a1;
        }
        .label {
            color: #1565c0;
            font-weight: bold;
        }
        .message {
            color: #388e3c;
            font-style: italic;
        }
        .gridview {
            margin-top: 20px;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
        }
        .link {
            color: #1565c0;
            text-decoration: none;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="btConsulta1" runat="server" OnClick="btConsulta1_Click" Text="Consulta 1" CssClass="button" />
            <asp:Button ID="btConsulta2" runat="server" OnClick="btConsulta2_Click" Text="Consulta 2" CssClass="button" />
            <asp:Button ID="btConsulta3" runat="server" OnClick="btConsulta3_Click" Text="Consulta 3" CssClass="button" />
            <asp:Button ID="btConsulta4" runat="server" OnClick="btConsulta4_Click" Text="Consulta 4" CssClass="button" />
            <br /><br />
            <asp:Label ID="lbMensaje" runat="server" Text="Elija una consulta para mostrar" CssClass="message"></asp:Label>
            <br />
            <asp:GridView ID="gvConsultas" runat="server" CssClass="gridview"></asp:GridView>
            <br />
            <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="../Index.aspx" CssClass="link">Volver al inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
