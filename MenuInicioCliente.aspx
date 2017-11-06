<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuInicioCliente.aspx.cs" Inherits="MenuInicioCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 559px; background-color: #FFCC99">
    <form id="form1" runat="server">
    <div style="height: 526px">
    
        <asp:Button ID="btnListaPedidos" runat="server" OnClick="btnListaPedidos_Click" style="z-index: 1; left: 453px; top: 122px; position: absolute; height: 37px; width: 213px" Text="Lista de pedidos" />
        <asp:Button ID="btnAltaPedido" runat="server" OnClick="btnAltaPedido_Click" style="z-index: 1; left: 454px; top: 213px; position: absolute; height: 33px; width: 213px" Text="Alta pedido" />
    
    </div>
    </form>
</body>
</html>
