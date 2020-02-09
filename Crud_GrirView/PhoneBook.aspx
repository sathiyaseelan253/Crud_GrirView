<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneBook.aspx.cs" Inherits="Crud_GrirView.PhoneBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
        <asp:GridView ID="myPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Id"  ShowHeaderWhenEmpty="true"
            onRowCommand="myPhoneBook_RowCommand" onRowEditing="myPhoneBook_RowEditing" OnRowCancelingEdit="myPhoneBook_RowCancelingEdit" OnRowUpdating="myPhoneBook_RowUpdating" OnRowDeleting="myPhoneBook_RowDeleting"
            
           
            
          
            CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
          
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

           <Columns>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLastNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Contact") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("Contact") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:ImageButton ImageUrl="~/Images/Edit button.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="30px" Height="30px" />
                        <asp:ImageButton ImageUrl="~/Images/Delete_btn.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="30px" Height="30px" />
                   </ItemTemplate>
                   <EditItemTemplate>
                         <asp:ImageButton ImageUrl="~/Images/Save_btn.png" runat="server" CommandName="Save" ToolTip="Save" Width="30px" Height="30px" />
                        <asp:ImageButton ImageUrl="~/Images/Cancel_Btn.jpg" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="30px" Height="30px" />
                   </EditItemTemplate>
                   <FooterTemplate>
                       <asp:ImageButton ImageUrl="~/Images/Add_btn.png" runat="server" CommandName="Add" ToolTip="Add" Width="30px" Height="30px" />
                   </FooterTemplate>
               </asp:TemplateField>
               </Columns>
           
        </asp:GridView>
             <br/>
            <asp:Label ID="lblSuccessMsg" Text="" ForeColor="Green" runat="server"/>
              <br/>
            <asp:Label ID="lblErrorMsgFailed" Text="" ForeColor="Red" runat="server"/>
            </div>
            </form>


</body>
</html>
