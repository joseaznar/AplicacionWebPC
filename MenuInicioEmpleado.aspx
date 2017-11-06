<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuInicioEmpleado.aspx.cs" Inherits="MenuInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 600px">
    <form id="form1" runat="server">
    <div style="background-color: #FFCC99; height: 513px;">
    
        <asp:Button ID="btnAltaPedido" runat="server" OnClick="Button2_Click" style="z-index: 1; left: 453px; top: 219px; position: absolute; height: 35px; width: 223px" Text="AltaPedido" />
    
        <asp:Button ID="btnListaPedidos" runat="server" OnClick="btnListaPedidos_Click" style="z-index: 1; left: 444px; top: 118px; position: absolute; height: 32px; width: 232px" Text="Lista Pedidos" />
    
    </div>
    </form>
</body>
</html>
