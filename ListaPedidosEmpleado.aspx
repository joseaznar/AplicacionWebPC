<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaPedidosEmpleado.aspx.cs" Inherits="ListaPedidosEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 97%;
            z-index: 1;
            left: 16px;
            top: 313px;
            position: absolute;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div style="background-color: #FF9933; height: 553px;">
    
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 363px; top: 182px; position: absolute" Text="Pedidos:"></asp:Label>
    
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 340px; top: 55px; position: absolute; height: 22px" Text="Información de los pedidos del empleado"></asp:Label>
        <asp:Table ID="tblUsuario" runat="server" style="z-index: 1; left: 347px; top: 103px; position: absolute; height: 28px; width: 296px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">RFC</asp:TableCell>
                <asp:TableCell runat="server">Nombre</asp:TableCell>
                <asp:TableCell runat="server">Categoria</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" style="z-index: 1; left: 17px; top: 527px; position: absolute">Página principal</asp:HyperLink>
    
        <asp:DropDownList ID="DDLPedidos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPedidos_SelectedIndexChanged" style="z-index: 1; left: 453px; top: 184px; position: absolute">
        </asp:DropDownList>
        <asp:Table ID="tblPedido" runat="server" style="z-index: 1; left: 189px; top: 235px; position: absolute; height: 28px; width: 665px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Pedido no.</asp:TableCell>
                <asp:TableCell runat="server">Fecha pedido</asp:TableCell>
                <asp:TableCell runat="server">Total a pagar</asp:TableCell>
                <asp:TableCell runat="server">Saldo del pedido</asp:TableCell>
                <asp:TableCell runat="server">Saldo en facturas</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <table class="auto-style1">
            <caption>
                Productos del pedidos y pagos del empleado</caption>
            <tr>
                <td>
                    <asp:GridView ID="grdArtículos" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="grdPagos" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    
    </div>
    </form>
</body>
</html>
