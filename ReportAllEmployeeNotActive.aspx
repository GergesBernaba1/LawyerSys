<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="ReportAllEmployeeNotActive.aspx.cs" Inherits="ReportAllEmployeeNotActive" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1> عرض تقرير العملاء الغير نشط</h1>
                </div>
                 <div class="three fields ui raised segment form">
                     <div class="field">
                         <div class="ui two column grid">
                           <div class="column">
                               </div>
                             </div>
                     </div>
                     <div class="field">
                         <div class="ui two column grid">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="RepAllEmployeesNotActive"></Report>
                </CR:CrystalReportSource>
                             </div>
                         </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

