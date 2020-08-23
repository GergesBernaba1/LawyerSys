<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add_Task.aspx.cs" Inherits="Add_Task" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>بطاقة مهمة ادارية</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="تاريخ المهمة" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDate" runat="server" class="ui input " placeholder="التاريخ" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="اسم المهمة"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" class="ui input" placeholder="الاسم" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"  ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="نوع المهمة"></asp:Label>
                                    <asp:TextBox ID="txtType" runat="server" placeholder="النوع" class="ui input " ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="تاريخ التنبيه" CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDateAlert" runat="server" class="ui input " placeholder="التاريخ" CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateAlert" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateAlert" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txtNotes" runat="server" placeholder="ملاحظات" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="14"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <br />
                                <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="  " CssClass="valign-text-top"></asp:Label>
                                    <asp:CheckBox ID="checkStatus" runat="server" Text="مورشفة" />
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
