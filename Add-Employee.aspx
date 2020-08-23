<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add-Employee.aspx.cs" Inherits="Add_Employee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>أضافة بطاقة عميل</h1>
                </div>

                 <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> البيانات الاساسية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="الاسم"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="الاسم" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                               <%-- <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="الصفة"></asp:Label>
                                    <asp:DropDownList ID="drpDescrip" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="2" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpDescrip" InitialValue="اختار الصفة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>--%>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="العنوان"></asp:Label>
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="العنوان" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="نوع العميل"></asp:Label>
                                    <asp:DropDownList ID="drpType" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpType" InitialValue="نوع العميل" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="المهنة"></asp:Label>
                                    <asp:TextBox ID="txtCareer" runat="server" placeholder="المهنة" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCareer" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="تاريخ الميلاد " CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDate" runat="server" class="ui input " placeholder="تاريخ الميلاد " CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>    
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="الجنسية"></asp:Label>
                                    <asp:TextBox ID="txtNationality" runat="server" placeholder="الجنسية" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNationality" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="الرقم القومي"></asp:Label>
                                    <asp:TextBox ID="txtNationalNumber" runat="server" placeholder="الرقم القومي" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  CssClass="center" Font-Size="Medium" TabIndex="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNationality" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                </div>
                        </div>
                        </div>
                     </div>

                <div class="three fields ui raised segment form">
                     <h1 class="ui dividing header" style="font-family: myFirstFont"> بيانات اضافية</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label8" runat="server" Font-Size="Large" Text="رقم التليفون"></asp:Label>
                                    <asp:TextBox ID="txtPhone" runat="server" placeholder="التليفون" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="9"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label9" runat="server" Font-Size="Large" Text="الموبيل"></asp:Label>
                                    <asp:TextBox ID="txtMobil" runat="server" placeholder="الموبيل" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="الايميل"></asp:Label>
                                    <asp:TextBox ID="txtMail" runat="server" placeholder="الايميل" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="11"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label11" runat="server" Font-Size="Large" Text="وسيلة اتصال اخري"></asp:Label>
                                    <asp:TextBox ID="txtAnother" runat="server" placeholder="الوسيلة" class="ui input "  CssClass="center" Font-Size="Medium" TabIndex="12"></asp:TextBox>
                                </div>
                                </div>
                            <div class="row">
                               <div class="column">
                                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="الحالة"></asp:Label>
                                    <asp:DropDownList ID="drpStatus" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="13" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="drpStatus" InitialValue="اختار الحالة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
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
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" Style="width: 80px" OnClick="btnCancel_Click" Text="الغاء"  TabIndex="16" />
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
