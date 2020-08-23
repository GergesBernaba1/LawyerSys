<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Select_SittingOld.aspx.cs" Inherits="Select_SittingOld" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>عرض الجلسات المورشفة</h1>
                </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بحث</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                 <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text=" رقم القضية"></asp:Label>
                                    <asp:DropDownList ID="drpIssueNumber" runat="server" class="ui fluid selection dropdown" Font-Size="Medium" AutoPostBack="true" OnSelectedIndexChanged="drpIssueNumber_SelectedIndexChanged" CssClass="center" TabIndex="1"></asp:DropDownList>
                                    </div>
                                </div>
                            <div class="row">
                                <div class="column">
                                    <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="الفترة من  " CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDateFrom" runat="server" class="ui input " placeholder="التاريخ " AutoPostBack="true" OnTextChanged="txtDateFrom_TextChanged" CssClass="center" Font-Size="Medium" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom" />
                                </div>
                                <div class="column">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="الفترة الي  " CssClass="valign-text-top"></asp:Label>
                                    <asp:TextBox ID="txtDateTo" runat="server" class="ui input " placeholder="التاريخ " CssClass="center" Font-Size="Medium" AutoPostBack="true" OnTextChanged="txtDateTo_TextChanged" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

               <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">البيانات</h1>
                    <div class="field">
                        <div id="Div1" dir="rtl" runat="server" style="height: 400px; width: 100%; left: 5%; right: 5%; margin: 2em auto; overflow-x: scroll">
                            <asp:GridView ID="gridSelect" class="ui celled table center aligned" AllowPaging="true" PageSize="5" runat="server" CellPadding="4" ForeColor="#333333" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" GridLines="None" OnPageIndexChanging="gridSelect_PageIndexChanging" OnSelectedIndexChanged="gridSelect_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="تفاصيل" />
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Size="Larger" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
