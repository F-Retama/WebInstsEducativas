<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UniversidadesWEB.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <style>
    /* La página index sirve como un directorio (punto 1), y tiene hyperlinks de los puntos (2) (4) y (5) 
    <style es el estilo en HTML para que los elementos estén centrados, con letra moderna, y los links estilizados */
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
        /* Cuando los links tienen CssClass="link" tienen las siguientes características: */
        .link {
            color: #1565c0;
            text-decoration: none;
            padding: 10px 20px;
            border: 2px solid #1565c0;
            border-radius: 5px;
            transition: all 0.3s ease;
        }
        .link:hover {
            background-color: #1565c0;
            color: #fff;
        }
        .link + .link {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p>Este es el menú desde el cual se puede dirigir a cualquier página</p>
            <br />
            <asp:HyperLink ID="hlConsultas" runat="server" NavigateUrl="~/Pags/MenuConsultas.aspx" CssClass="link">Ir a la página de consultas</asp:HyperLink>
            <br /><br /><br /><br />
            <asp:HyperLink ID="hlCampus" runat="server" NavigateUrl="~/Pags/BuscarPlanteles.aspx" CssClass="link">Mostrar campus dada una carrera y una ciudad</asp:HyperLink>
            <br /><br /><br /><br />
          <asp:HyperLink ID="hlAlta" runat="server" NavigateUrl="~/Pags/AltaCampus.aspx" CssClass="link">Alta Campus</asp:HyperLink>
        </div>
    </form>
</body>
</html>
