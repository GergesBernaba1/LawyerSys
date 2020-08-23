<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add_MoveIssue.aspx.cs" Inherits="Add_MoveIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>بطاقة نقل قضية</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                 <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text=" رقم القضية"></asp:Label>
                                    <asp:DropDownList ID="drpIssueNumber" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="1" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpIssueNumber" InitialValue="أختار رقم القضية" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="التاريخ " CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDate" runat="server" class="ui input " placeholder="التاريخ" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="رقم محكمة الاستئناف"></asp:Label>
                                    <asp:TextBox ID="txtNumAgain" runat="server" placeholder="محكمة الاستئناف" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="5"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="رقم محكمة النقض"></asp:Label>
                                    <asp:TextBox ID="txtNumGanist" runat="server" placeholder="محكمة النقض" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="5"></asp:TextBox>
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="رقم محكمة التنفيذ"></asp:Label>
                                    <asp:TextBox ID="txtNumWork" runat="server" placeholder="محكمة التنفيذ" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="5"></asp:TextBox>
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
