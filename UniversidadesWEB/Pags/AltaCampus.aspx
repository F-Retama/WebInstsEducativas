<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCampus.aspx.cs" Inherits="UniversidadesWEB.Pags.AltaCampus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 1812px; width: 1783px; margin-left: 40px">
            Llena cada campo para dar de alta un campus<br />
            <br />
            Institución:
            <asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            Nombre: <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
            <br />
            Domicilio:
            <asp:TextBox ID="tbDomicilio" runat="server" Width="212px"></asp:TextBox>
            <br />
            Teléfono:
            <asp:TextBox ID="tbTelefono" runat="server" Width="227px"></asp:TextBox>
            <br />
            Ciudad:
            <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            Carreras que se imparten:<asp:CheckBoxList ID="cblCarreras" runat="server" AutoPostBack="True">
            </asp:CheckBoxList>
            <br />
            <br />
            Agregar servicios adicionales&nbsp;
            <br />
            <asp:DropDownList ID="ddlServicios" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="cbCostoExtra" runat="server" Text="Tiene costo extra" />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="cbDentroCampus" runat="server" Text="Está dentro del campus" />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btAgregarServicio" runat="server" Text="Agregar Servicio" Width="219px" />
            <br />
            <br />
            Servicios registrados <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:ButtonField Text="Eliminar" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            Áreas académicas&nbsp;&nbsp;&nbsp;
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp; No. de profesores con:<br />
&nbsp;&nbsp;&nbsp; Licenciatura
            <asp:TextBox ID="TextBox1" runat="server" Width="136px"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; Maestría&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="138px"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; Doctorado&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="135px"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Registrar Área" Width="216px" />
            <br />
            <br />
            Áreas registradas<asp:GridView ID="GridView2" runat="server">
                <Columns>
                    <asp:BoundField />
                    <asp:ButtonField Text="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
