<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAR.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPageAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="Style/main.css" />
    <div class="container-fluid">
         <div class="ui blue inverted segment center aligned " style="width: 100%">
                    <h1>الصفحة الرئيسية</h1>
                </div>

    <div class="row">
        <div class="f-width">
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="col-xs-12">
                <div class="item bg-b money">
                    <%--<img src="image/imac (1).png" alt="" />--%>
                    <p>بطاقة عميل</p>
                    <a href="Add-Employee.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="item bg-rebec money">
                    <p>استشارة</p>
                    <a href="Add_Consultation.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
                </div>
            <div class="col-xs-12">
                <div class="item bg-blue money">
                    <p>بطاقة جلسة</p>
                    <a href="Add_Sitting.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
                </div>
        </div>
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="col-xs-12">
                <div class="item bg-rebec money">
                    <p>بطاقة قضية</p>
                    <a href="Add-Issue.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="item bg-blue money">
                    <p>بطاقة مهمة إدارية</p>
                    <a href="Add_Task.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
                 <div class="col-xs-12" runat="server" id="div" visible="false">
                <div class="item bg-lb money">
                    <p>التنبيهات</p>
                    <a href="Alert.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
                </div>
        </div>
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="col-xs-12">
                <div class="item bg-blue money">
                    <p>سند دفع</p>
                    <a href="Add_PayMoney.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="item bg-lb money">
                    <p>كشف حساب</p>
                    <a href="Select_PayMoney.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="col-xs-12">
                <div class="item bg-lb money">
                    <p>سند قبض</p>
                    <a href="Add_ReceiveMoney.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="item bg-b money">
                    <p>أرصدة العملاء</p>
                    <a href="BalanceEmployeeData.aspx">
                        <i class="glyphicon glyphicon-plus"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</asp:Content>
