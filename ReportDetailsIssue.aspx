<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="ReportDetailsIssue.aspx.cs" Inherits="ReportDetailsIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1> عرض تقرير بيانات القضية</h1>
                </div>

                 <div class="three fields ui raised segment form">
                    <div class="field">
                        <div class="ui two column grid">
                           <div class="column">
                                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="رقم القضية"></asp:Label>
                                    <asp:TextBox ID="txtNumber" runat="server" placeholder="الرقم" class="ui input "  ValidationGroup="1" onchange="changeborderColorafterfill(this)" CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ControlToValidate="txtNumber" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                            <div class="column">
                                <br />
                            <asp:Button ID="btnReport" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="15" OnClick="btnReport_Click" ValidationGroup="1" OnClientClick="customValidations('1')" Text="تقرير" />
                            </div>
                        </div>
                    </div>
                   
                </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

