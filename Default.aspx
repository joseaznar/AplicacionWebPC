<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejemplo de aplicación Web</title>
    <style type="text/css">
        #form1 {
            height: 568px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #FF9933">
    <div style="background-color: #FF9966; height: 527px;">
    
        <asp:Login ID="Login1" runat="server" style="z-index: 1; left: 314px; top: 95px; position: absolute; height: 147px; width: 342px" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop" OnAuthenticate="Login1_Authenticate1">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    
        <asp:Label ID="lblFH" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
