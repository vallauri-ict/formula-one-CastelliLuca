<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FormulaOne - WebForm</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <!--userName <asp:TextBox ID="txtUserName" runat="server"/> <br/>
            Password <input type="text" ID="txtPassword"/> <br/>
            --------------------------------------------------------------->

            <asp:Label ID="lblMessaggio" runat="server" Text=" ">Scegli la tabella che vuoi visualizzare</asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="lstTabelle" runat="server" OnSelectedIndexChanged="changeIndex" Width="201px" AutoPostBack="true"></asp:DropDownList>
            <asp:DataGrid ID="dg" runat="server"></asp:DataGrid>
        </div>
    </form>
</body>
</html>
