<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add-PlaceLawer.aspx.cs" Inherits="Add_PlaceLawer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>أضافة بطاقة محكمة</h1>
                </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="اسم المحكمة"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="الاسم" class="ui input " Font-Size="Medium" CssClass="center" TabIndex="1" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="العنوان"></asp:Label>
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="العنوان" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="التليفون"></asp:Label>
                                    <asp:TextBox ID="txtMobil" runat="server" placeholder="الموبيل" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="3" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobil" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>                               
                                     </div>
                                <div class="column">
                                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="المحافظة" CssClass="valign-text-top"></asp:Label>
                                    <asp:DropDownList ID="drpGovernate" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpGovernate" InitialValue="اسم المحافظة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                 <div class="column">
                                    <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="ملاحظات" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtStatment" runat="server" class="ui input " Font-Size="Medium" TextMode="MultiLine" Height="100px" TabIndex="5"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                    <br />
                    <div class="field" dir="ltr">
                        <div class="ui buttons">
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" OnClick="btnCancel_Click" Style="width: 80px" Text="الغاء"  TabIndex="12" />
                            <div class="or"></div>

                            <asp:Button ID="btnSave" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="11" OnClick="btnSave_Click" ValidationGroup="1" OnClientClick="customValidations('1')" Text="حـفـظ" />
                        </div>
                    </div>
                </div>

                <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>