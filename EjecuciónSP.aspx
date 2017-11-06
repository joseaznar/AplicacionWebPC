<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjecuciónSP.aspx.cs" Inherits="EjecuciónSP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejecución de SP</title>
    <style type="text/css">
        #form1 {
            height: 563px;
        }
    </style>
</head>
<body style="height: 266px">
    <form id="form1" runat="server" style="background-color: #FFCC66">
    <div style="height: 502px; background-color: #FFCC99;">
    
        <asp:Button ID="BtnEjecutaProc" runat="server" OnClick="BtnEjecutaProc_Click" style="z-index: 1; left: 114px; top: 65px; position: absolute" Text="Ejecución procedimiento" />
        <asp:Button ID="BtnEjecutaFunc" runat="server" OnClick="BtnEjecutaFunc_Click" style="z-index: 1; left: 455px; top: 64px; position: absolute; width: 179px" Text="Ejecución función" />
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 237px; top: 161px; position: absolute; width: 166px" Text="Resultado"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" style="z-index: 1; left: 615px; top: 210px; position: absolute">Inicio</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
