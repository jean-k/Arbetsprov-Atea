<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="MessageReceiver_Webapp.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arbetsprov</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:auto;margin-right:auto;text-align:center;">
     <h1>Välkommen till meddelande-sidan!</h1>
        <hr />
           <asp:ScriptManager ID="scriptManager" EnablePartialRendering="true" runat="server">
        </asp:ScriptManager>
        
         <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
                 
                  <asp:Timer ID="tmrPartialUpdate" runat="server" Interval="2000" OnTick="tmrPartialUpdate_Tick">
        </asp:Timer>
                    <div style="margin-left:auto;margin-right:auto;text-align:center;width:500px;">
            <h2>Senaste inkomna meddelande:</h2><br />
            <div>
                <table>
                    <tr>
                        <td style="text-align:right">
                            <span>Meddelande:&nbsp;</span>
                        </td>
                        <td style="text-align:left">
                              <label runat="server" id="lbl_message"></label>
                        </td>
                    </tr>
                      <tr>
                        <td style="text-align:right">
                             <span>Skapad:&nbsp;</span>
                        </td>
                        <td style="text-align:left">
                            <label runat="server" id="lbl_date"></label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    
             <hr />
        <h2>Meddelandearkivet</h2>   
        <div style="margin-left:auto; margin-right:auto; width:600px;">         
     <asp:GridView ID="gdMessages" Width="600" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="MessageID" DataSourceID="messageSourceConnection" EmptyDataText="Inga meddelanden" GridLines="Horizontal">
         <Columns>
             <asp:BoundField HeaderText="MessageID" ReadOnly="True" DataField="MessageID" InsertVisible="False" SortExpression="MessageID" Visible="False" />
             <asp:BoundField DataField="Date" ItemStyle-Width="200" HeaderText="Datum" SortExpression="Date" />
             <asp:BoundField HeaderText="Meddelande" DataField="Message" SortExpression="Message" />
         </Columns>
         <AlternatingRowStyle BackColor="Lightskyblue" />
         <EmptyDataTemplate>
             Det finns inga meddelanden
         </EmptyDataTemplate>
     </asp:GridView>
                
             </div>
     <br />
                  </ContentTemplate></asp:UpdatePanel>
 </div>
       
        <asp:SqlDataSource ID="messageSourceConnection" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [MessageTable]"></asp:SqlDataSource>
              
       
 
    </form>
</body>
</html>
