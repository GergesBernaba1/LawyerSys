<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="ReportDetailsEmployee.aspx.cs" Inherits="ReportDetailsEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1> عرض بيانات العميل</h1>
                </div>

                 <div class="three fields ui raised segment form">
                    <div class="field">
                        <div class="ui two column grid">
                           <div class="column">
                                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="اسم العميل"></asp:Label>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" class="ui fluid selection dropdown" Font-Size="Medium" CssClass="center" TabIndex="0" onchange="changeborderColorafterfill(this)" ValidationGroup="1"></asp:DropDownList>
                                    </div>
                        </div>
                    </div>
                   
                </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

