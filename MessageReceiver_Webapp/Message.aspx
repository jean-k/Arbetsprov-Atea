<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="MessageReceiver_Webapp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
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

</asp:Content>
