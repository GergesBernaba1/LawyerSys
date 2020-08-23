<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Add-Issue.aspx.cs" Inherits="Add_Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" dir="rtl">
        <div class="ui blue inverted segment center aligned " style="width: 100%">
            <h1>أضافة بطاقة قضية</h1>
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
                                    <asp:DropDownList ID="drpGovenate" runat="server" class="ui fluid selection dropdown" AutoPostBack="true" OnSelectedIndexChanged="drpGovenate_SelectedIndexChanged" Font-Size="Medium" CssClass="center" TabIndex="1" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpGovenate" InitialValue="أختار المحافظة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label15" runat="server" Font-Size="Large" Text="المحكمة"></asp:Label>
                                    <asp:DropDownList ID="drpMahkama" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="drpMahkama" InitialValue="أختار المحكمة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="رقم القضية"></asp:Label>
                                    <asp:TextBox ID="txtNumber" runat="server" placeholder="الرقم" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label16" runat="server" Font-Size="Large" Text="اسم القاضي"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="الاسم" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
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
                                    <asp:DropDownList ID="drpEmployee" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpEmployee" InitialValue="اختار العميل" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="اسم الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtNameLawer" runat="server" placeholder="اسم الوكيل" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNameLawer" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="المسئول"></asp:Label>
                                    <asp:DropDownList ID="drpUser" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="4" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpUser" InitialValue="أختار المسئول" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label8" runat="server" Font-Size="Large" Text="نوع الدعوة"></asp:Label>
                                    <asp:TextBox ID="txtTypeInvite" runat="server" placeholder="نوع الدعوة" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="9"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label9" runat="server" Font-Size="Large" Text="موضوع الدعوة"></asp:Label>
                                    <asp:TextBox ID="txtInviteText" runat="server" placeholder="موضوع الدعوة" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="تاريخ الدعوة " CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtInviteDate" runat="server" class="ui input " placeholder="تاريخ الدعوة " CssClass="center" onchange="changeborderColorafterfill(this)" ValidationGroup="1" Font-Size="Medium" TabIndex="6"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInviteDate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInviteDate" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="txtGaintName" runat="server" placeholder="اسم الخصم" class="ui input " AutoPostBack="true" ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGaintName" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label11" runat="server" Font-Size="Large" Text="العنوان"></asp:Label>
                                    <asp:TextBox ID="txtGaintAddress" runat="server" placeholder="العنوان" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="اسم الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtGaintLawer" runat="server" placeholder="اسم الوكيل" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label18" runat="server" Font-Size="Large" Text="عنوان الوكيل"></asp:Label>
                                    <asp:TextBox ID="txtGaintLawerAddress" runat="server" placeholder="العنوان" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="three fields ui raised segment form">
            <h1 class="ui dividing header" style="font-family: myFirstFont">توثيق ملفات</h1>
            <div class="field">
                <div class="ui two column grid">
                    <div class="row" dir="ltr">
                        <div class="column">
                            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="رفع صور" Width="50%"></asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                            <div class="ui buttons">
                                <asp:Button ID="btnUploadImage" runat="server" CssClass="ui blue button" Text="Upload Image" OnClick="btnUploadImage_Click" />
                            </div>
                        </div>
                        <div class="column">
                            <asp:Label ID="Label19" runat="server" Font-Size="Large" Text="Pdf رفع ملفات" Width="50%"></asp:Label>
                            <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="true" />
                            <div class="ui buttons">
                                <asp:Button ID="btnUploadFile" runat="server" CssClass="ui blue button" Text="Upload File" OnClick="btnUploadFile_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بيانات أخري</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="حالة القضية"></asp:Label>
                                    <asp:DropDownList ID="drpStatus" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="13" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="drpStatus" InitialValue="اختار الحالة" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="قيمة العقد"></asp:Label>
                                    <asp:TextBox ID="txtAmount" runat="server" placeholder="قيمة العقد" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label17" runat="server" Font-Size="Large" Text="ملاحظات"></asp:Label>
                                    <asp:TextBox ID="txtNotes" runat="server" placeholder="ملاحظات" class="ui input " CssClass="center" Font-Size="Medium" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="field" dir="ltr">
                        <div class="ui buttons">
                            <asp:Button ID="btnCancel" runat="server" CssClass="ui button" OnClick="btnCancel_Click" Style="width: 80px" Text="الغاء" TabIndex="16" />
                            <div class="or"></div>

                            <asp:Button ID="btnSave" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="15" OnClick="btnSave_Click" ValidationGroup="1" OnClientClick="customValidations('1')" Text="حـفـظ" />
                        </div>
                    </div>
                </div>

                <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
