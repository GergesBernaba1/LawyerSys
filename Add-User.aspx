<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add-User.aspx.cs" Inherits="Add_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>أضافة مستخدم</h1>
                </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                            <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="الاسم" CssClass="valign-text-top"></asp:Label>
                                            <asp:TextBox ID="TxtName" class="ui input " runat="server" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                            <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="اسم المستخدم" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtUserName" class="ui input " runat="server" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUserName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                
                                    <div class="column">
                                            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="كلمة المرور" CssClass="valign-text-top"></asp:Label>
                                        <asp:TextBox ID="txtPassword" TextMode="Password" class="ui input " runat="server" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPassword" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    <div class="column">
                                            <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="الموبيل" CssClass="valign-text-top"></asp:Label>
                                         <asp:TextBox ID="txtMobil" class="ui input " runat="server" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMobil" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="column">
                                         <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="الايميل" CssClass="valign-text-top"></asp:Label>
                                         <asp:TextBox ID="txtMail" class="ui input " runat="server" TextMode="Email"></asp:TextBox>
                                        </div>
                                    <div class="column">
                                         <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="العنوان" CssClass="valign-text-top"></asp:Label>
                                         <asp:TextBox ID="txtAddress" class="ui input " runat="server"></asp:TextBox>
                                        </div>
                               
                            </div>
                        </div>
                    </div>
                </div>
               <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات</h1>
                    <div class="field">
                                         <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="اختيار الكل" CssClass="valign-text-top"></asp:Label>
                       <asp:CheckBox ID="chkActive" CssClass="btn-chk" AutoPostBack="true" OnCheckedChanged="chkActive_CheckedChanged" runat="server" />
                        <div id="Div1" dir="rtl" runat="server" style="height: 300px; width: 100%; left: 5%; right: 5%; margin: 2em auto; overflow-x: scroll">
                            <asp:GridView ID="gridSelect" class="ui celled table center aligned"  runat="server" CellPadding="4" ForeColor="#333333" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" GridLines="None" >
                                <Columns>
                                    <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:CheckBox ID="btnCheckAll" runat="server"  />
                                 <%--<input id="btnCheckAll" type="checkbox" name="AllCheck" />--%>
                             </ItemTemplate>
                         </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Size="Larger" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                        <div class="ui two column grid" dir="ltr">
                            <div class="row">
                         <div class="column">
                            <asp:Button ID="btnAdd" runat="server" CssClass="ui blue button"  Style="width: 80px" TabIndex="15" ValidationGroup="1" OnClientClick="customValidations('1')"  OnClick="btnAdd_Click"  Text="حفظ" />
                                </div>
                                </div>
                            </div>
                    </div>
                   </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
