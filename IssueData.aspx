<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="IssueData.aspx.cs" Inherits="IssueData" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" dir="rtl">
        <div class="ui blue inverted segment center aligned " style="width: 100%">
            <h1>تفاصيل القضية</h1>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="المحافظة"></asp:Label>
                                    <asp:DropDownList ID="drpGovenate" runat="server" class="ui input" Enabled="false" Font-Size="Medium" CssClass="center" TabIndex="1" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label15" runat="server" Font-Size="Large" Text="المحكمة"></asp:Label>
                                    <asp:DropDownList ID="drpMahkama" runat="server" class="ui input" Enabled="false" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="رقم القضية"></asp:Label>
                                    <asp:TextBox ID="txtNumber" runat="server" placeholder="الرقم" class="ui input " Enabled="false"  AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label16" runat="server" Font-Size="Large" Text="اسم القاضي"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="الاسم" class="ui input "  Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بيانات القضية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="العميل"></asp:Label>
                                    <asp:DropDownList ID="drpEmployee" runat="server" class="ui input " Enabled="false" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="اسم الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtNameLawer" runat="server" placeholder="اسم الوكيل" class="ui input " Enabled="false" AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="المسئول"></asp:Label>
                                    <asp:DropDownList ID="drpUser" runat="server" class="ui input " Font-Size="Medium" Enabled="false" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label8" runat="server" Font-Size="Large" Text="نوع الدعوة"></asp:Label>
                                    <asp:TextBox ID="txtTypeInvite" runat="server" placeholder="نوع الدعوة" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="9"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label9" runat="server" Font-Size="Large" Text="موضوع الدعوة"></asp:Label>
                                    <asp:TextBox ID="txtInviteText" runat="server" placeholder="موضوع الدعوة" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="تاريخ الدعوة "  CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtInviteDate" runat="server" class="ui input " placeholder="تاريخ الدعوة " Enabled="false" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بيانات الخصم</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="اسم الخصم"></asp:Label>
                                    <asp:TextBox ID="txtGaintName" runat="server" placeholder="اسم الخصم" class="ui input " Enabled="false" AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label11" runat="server" Font-Size="Large" Text="العنوان"></asp:Label>
                                    <asp:TextBox ID="txtGaintAddress" runat="server" placeholder="العنوان" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="اسم الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtGaintLawer" runat="server" placeholder="اسم الوكيل" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label18" runat="server" Font-Size="Large" Text="عنوان الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtGaintLawerAddress" runat="server" placeholder="العنوان" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بيانات أخري</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="حالة القضية"></asp:Label>
                                    <asp:DropDownList ID="drpStatus" runat="server" class="ui input" Font-Size="Medium" Enabled="false" CssClass="center" TabIndex="13" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="قيمة العقد"></asp:Label>
                                    <asp:TextBox ID="txtAmount" runat="server" placeholder="قيمة العقد" class="ui input " Enabled="false" CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label17" runat="server" Font-Size="Large" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txtNotes" runat="server" placeholder="ملاحظات" class="ui input " CssClass="center" Enabled="false" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                            <br />
                    <div class="field">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="الملفات"></asp:Label>
                         <div id="Div1" dir="rtl" runat="server" style="height: 400px; width: 100%; left: 5%; right: 5%; margin: 2em auto; overflow-x: scroll">
                            <asp:GridView ID="gridSelect" class="ui celled table center aligned" AllowPaging="true" PageSize="5" runat="server" CellPadding="4" ForeColor="#333333" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" GridLines="None" OnPageIndexChanging="gridSelect_PageIndexChanging" OnSelectedIndexChanged="gridSelect_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="تحميل الملف" />
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
                        </div>
                    <div class="field">
                        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="3">
                            <AlternatingItemTemplate>
                                <td id="Td1" runat="server" style="background-color:#FFF8DC;">
                                    <asp:Image ID="Image1" runat="server" Height="185px" ImageUrl='<%# Eval("Path") %>' Width="300px" />
                                </td>
                            </AlternatingItemTemplate>
                            <EditItemTemplate>
                                <td id="Td2" runat="server" style="background-color:#008A8C;color: #FFFFFF;">Path:
                                    <asp:TextBox ID="PathTextBox" runat="server" Text='<%# Bind("Path") %>' />
                                    <br />
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                                    <br />
                                </td>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table id="Table1" runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr>
                                        <td>No data was returned.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td id="Td3" runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <InsertItemTemplate>
                                <td id="Td4" runat="server" style="">Path:
                                    <asp:TextBox ID="PathTextBox" runat="server" Text='<%# Bind("Path") %>' />
                                    <br />
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                                    <br />
                                </td>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <td id="Td5" runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <asp:Image ID="Image1" runat="server" Height="185px" ImageUrl='<%# Eval("Path") %>' Width="300px" />
                                </td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table id="Table2" runat="server">
                                    <tr id="Tr1" runat="server">
                                        <td id="Td6" runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server">
                                        <td id="Td7" runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td id="Td8" runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">Path:
                                    <asp:Label ID="PathLabel" runat="server" Text='<%# Eval("Path") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Lawer_ConnectionString %>" SelectCommand="SELECT [Path] FROM [Ta_IssueFiles] WHERE ([Type]=0) and ([Code] = @Code)">
                            <SelectParameters>
                                <asp:SessionParameter Name="Code" SessionField="Code" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        </div>
                    <br />
                    <div class="field" dir="ltr">
                        <div class="ui buttons">
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" OnClick="btnCancel_Click" Style="width: 80px" Text="الغاء" TabIndex="16" />
                            <div class="or"></div>

                            <asp:Button ID="btnSave" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="15" OnClick="btnSave_Click" ValidationGroup="1" OnClientClick="customValidations('1')" Text="تعديل" />
                        </div>
                    </div>
                </div>

                <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
