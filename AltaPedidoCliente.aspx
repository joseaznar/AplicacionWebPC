<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaPedidoCliente.aspx.cs" Inherits="AltaPedidoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 490px">
    <form id="form1" runat="server">
    <div style="background-color: #FFCC99; height: 482px;">
    
         <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 153px; top: 64px; position: absolute"></asp:TextBox>
         <asp:Label ID="monto" runat="server" style="z-index: 1; left: 90px; top: 64px; position: absolute; height: 23px; width: 44px" Text="Monto:"></asp:Label>
         <asp:Button ID="btnPedido" runat="server" style="z-index: 1; left: 300px; top: 63px; position: absolute; right: 863px" Text="Crear Pedido" />
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" style="z-index: 1; left: 158px; top: 131px; position: absolute">
         </asp:DropDownList>
         <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 89px; top: 131px; position: absolute; height: 21px; width: 45px" Text="Articulos:"></asp:Label>
         <asp:Table ID="Table1" runat="server" style="z-index: 1; left: 58px; top: 172px; position: absolute; height: 64px; width: 1119px">
              <asp:TableRow runat="server">
                   <asp:TableCell ID="folio" runat="server">Folio</asp:TableCell>
                   <asp:TableCell ID="fechaped" runat="server">Fecha pedido</asp:TableCell>
                   <asp:TableCell ID="fechafin" runat="server">Fecha Fin</asp:TableCell>
                   <asp:TableCell ID="monto" runat="server">Monto</asp:TableCell>
                   <asp:TableCell ID="saldocli" runat="server">Saldo cliente</asp:TableCell>
                   <asp:TableCell ID="saldofacs" runat="server">Saldo facturas</asp:TableCell>
              </asp:TableRow>
              <asp:TableRow runat="server">
                   <asp:TableCell runat="server"></asp:TableCell>
                   <asp:TableCell runat="server"></asp:TableCell>
                   <asp:TableCell runat="server"></asp:TableCell>
                   <asp:TableCell runat="server"></asp:TableCell>
                   <asp:TableCell runat="server"></asp:TableCell>
                   <asp:TableCell runat="server"></asp:TableCell>
              </asp:TableRow>
         </asp:Table>
         <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 275px; top: 130px; position: absolute; height: 19px; width: 63px" Text="Cantidad: "></asp:Label>
         <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 344px; top: 129px; position: absolute"></asp:TextBox>
         <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 53px; top: 248px; position: absolute; height: 215px; width: 1107px">
         </asp:GridView>
         <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 491px; top: 127px; position: absolute" Text="Agregar al pedido" />
    
    </div>
    </form>
</body>
</html>
