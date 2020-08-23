<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Update_Consultation.aspx.cs" Inherits="Update_Consultation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>بيانات الاستشارة</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="التاريخ" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDate" runat="server" class="ui input " placeholder="التاريخ" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="العميل"></asp:Label>
                                    <asp:DropDownList ID="drpEmployee" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpEmployee" InitialValue="اختار العميل" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="المسئول"></asp:Label>
                                    <asp:DropDownList ID="drpUser" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpUser" InitialValue="أختار المسئول" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="النوع" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtType" runat="server" class="ui input " placeholder="النوع" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtType" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="التصنيف العام"></asp:Label>
                                    <asp:TextBox ID="txtTasnif" runat="server" placeholder="التصنيف العام" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                    <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="المرحلة الحالية"></asp:Label>
                                    <asp:TextBox ID="txtStage" runat="server" placeholder="المرحلة الحالية" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="الموضوع"></asp:Label>
                                    <asp:TextBox ID="txtSubject" runat="server"  class="ui input " TextMode="MultiLine" Height="125px"  Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                    <div class="column">
                                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Height="125px" class="ui input " Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                </div>
                        </div>
                        </div>
                     </div>
                        <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> الوصف</h1>
                    <div class="field">
                        <div class="ui one column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="175px" class="ui input "  Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                            </div>
                            <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> الرد</h1>
                    <div class="field">
                        <div class="ui one column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Height="175px" class="ui input "  Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                             <br />
                    <div class="field" dir="ltr">
                        <div class="ui buttons">
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" OnClick="btnCancel_Click" Style="width: 80px" Text="الغاء"  TabIndex="16" />
                            <div class="or"></div>
                            <asp:Button ID="btnDel" runat="server" CssClass="ui red button" Style="width: 80px" OnClick="btnDel_Click" TabIndex="17"  Text="حذف" />
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
