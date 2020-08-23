<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add_LegalDocument.aspx.cs" Inherits="Add_LegalDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>وثيقة عدلية</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="العميل"></asp:Label>
                                    <asp:DropDownList ID="drpEmployee" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpEmployee" InitialValue="اختار العميل" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="رقم الوكالة"></asp:Label>
                                    <asp:TextBox ID="txtNumber" runat="server" class="ui input" placeholder="رقم الوكالة" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumber"  ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="نوع الوثيقة"></asp:Label>
                                    <asp:DropDownList ID="drpType" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpType" InitialValue="اختار نوع الوثيقة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="تفاصيل" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDetails" runat="server" class="ui input " placeholder="تفاصيل" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDetails" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="رقم الوثيقة" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDocumentNumber" runat="server" class="ui input " placeholder="رقم الوثيقة" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDocumentNumber" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txtNotes" runat="server" placeholder="ملاحظات" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                </div>
                        </div>
                        </div>
                      <br />
                    <div class="field" dir="ltr">
                        <div class="ui buttons">
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" OnClick="btnCancel_Click" Style="width: 80px" Text="الغاء"  TabIndex="16" />
                            <div class="or"></div>

                            <asp:Button ID="btnSave" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="15" ValidationGroup="1" OnClick="btnSave_Click" OnClientClick="customValidations('1')" Text="حـفـظ" />
                        </div>
                    </div>
                     </div>
                <br />
                </div>
                </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
