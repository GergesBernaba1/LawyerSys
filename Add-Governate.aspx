<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add-Governate.aspx.cs" Inherits="Add_Governate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>أضافة محافظة</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="اسم المحافظة"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="الاسم" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <br />
                                  <asp:Button ID="btnSave" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="11" ValidationGroup="1" OnClick="btnSave_Click" OnClientClick="customValidations('1')"  Text="حـفـظ" />
                            </div>
                                </div>
                        </div>
                        </div>
                     </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">المحافظات</h1>
                    <div class="field">
                        <asp:GridView ID="gridSelect" class="ui celled table center aligned"  AllowPaging="true" PageSize="5" runat="server" CellPadding="4" ForeColor="#333333"  BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" GridLines="None" OnPageIndexChanging="gridSelect_PageIndexChanging" OnSelectedIndexChanged="gridSelect_SelectedIndexChanged" >
                         <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="حذف" />
                            </Columns>
                               <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Size="Larger"  Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF"  ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        </div>
                    </div>

                </div>
                </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>


