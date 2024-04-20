﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPlanteles.aspx.cs" Inherits="UniversidadesWEB.Pags.BuscarPlanteles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buscar Planteles</title>
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
        .label {
            color: #1565c0;
            font-weight: bold;
        }
        .dropdown {
            margin: 10px;
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
        .button:hover {
            background-color: #0d47a1;
        }
        .gridview {
            margin-top: 20px;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
        }
        .message {
            color: #388e3c;
            font-style: italic;
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
            <p>Elige una carrera y una ciudad para mostrar las instituciones y campus que cumplen ambos criterios.</p>
            <div class="dropdown">
                <span class="label">Carrera:</span>
                <asp:DropDownList ID="ddlCarrera" runat="server"></asp:DropDownList>
                 <br /><br />
                 <span class="label">Ciudad:</span>
                <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList>
                <br /><br />
                 <asp:Button ID="btBuscar" runat="server" OnClick="btBuscar_Click" Text="Buscar" CssClass="button" />
            </div>
           
            <asp:GridView ID="gvResp" runat="server" CssClass="gridview"></asp:GridView>
             <br /><br />
            <asp:Label ID="lbMensaje" runat="server" CssClass="message"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Index.aspx" CssClass="link">Volver al inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>

