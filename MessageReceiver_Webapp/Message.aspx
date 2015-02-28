<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="MessageReceiver_Webapp.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>Message Receiver</h1>
     <asp:GridView ID="gdMessages" runat="server">
         <Columns>
             <asp:BoundField HeaderText="Date" ReadOnly="True" />
             <asp:BoundField HeaderText="Message" ReadOnly="True" />
         </Columns>
         <AlternatingRowStyle BackColor="Yellow" />
         <EmptyDataTemplate>
             No new messages.
         </EmptyDataTemplate>
     </asp:GridView>
     <br />
     <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
 </div>
    <asp:Timer ID="tmrRefresh" runat="server" Enabled="true" Interval="1000" OnTick="tmrRefresh_Tick"></asp:Timer>
    </form>
</body>
</html>
