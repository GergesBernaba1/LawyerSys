﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="Select_LegalDocument.aspx.cs" Inherits="Select_LegalDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" dir="rtl">
                <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>عرض الوثائق العدلية</h1>
                </div>

                <div class="three fields ui raised segment form">
                    <h1 class="ui dividing header" style="font-family: myFirstFont">بحث</h1>
                    <div class="field">
                        <div class="ui two column grid">
                            <div class="row">
                                 <div class="column">
                                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text=" العميل"></asp:Label>
                                    <asp:DropDownList ID="drpEmployee" runat="server" ValidationGroup="1" onchange="changeborderColorafterfill(this)"  class="ui fluid selection dropdown" Font-Size="Medium" AutoPostBack="true" OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged" CssClass="center" TabIndex="1"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="اختار العميل" ControlToValidate="drpEmployee" ValidationGroup="1" ErrorMessage=""></asp:RequiredFieldValidator>
                                 </div>
                                <div class="column">
                                      <br />
                            <asp:Button ID="btnReport" runat="server" CssClass="ui blue button" Style="width: 80px" TabIndex="2" OnClick="btnReport_Click" ValidationGroup="1" OnClientClick="customValidations('1')" Text="تقرير" />
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
                                    <asp:CommandField ShowSelectButton="True" SelectText="تعديل" />
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
