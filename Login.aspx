<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html lang="en">

<head>
	<link rel="icon" href="favicon.png" type="image/x-icon" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<title>System</title>
	<link rel="stylesheet" type="text/css" href="css/functional.css">
    <link href="Semantic-UI/semantic.css" rel="stylesheet" />
    <script src="Semantic-UI/semantic.js"></script>
    <link href="Semantic-UI/semantic.min.css" rel="stylesheet" />
    <script src="Semantic-UI/semantic.min.js"></script>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>

</head>

<body style="overflow-y: scroll;background-image:url(Doctor.png);background-repeat:no-repeat;background-size:cover">
<div id="Loading" style="display:none;position: fixed;width: 100%;height: 100%;background-color: whitesmoke;z-index: 10000;"><i id="spinner" class="notched circle loading icon" style="position: fixed;left: 50%;top: 50%;z-index: 1000000;"></i></div>

	<div class="ui container">

		
	<br>
	<br>
	<br>
	<div id="message" style="width: 100%" class="ui hidden message"></div>

<div class="sixteen wide column ui stackable grid">
	<div id="view" class="five wide centered column">
		<h1 style="color:blue"> تسجيل الدخول</h1>
		<form id="Form1" class="ui form" runat="server">
			<div class="field">
				<label>اسم المستخدم</label>
				<asp:TextBox runat="server" TabIndex="1" placeholder="Username" ID="txtName"></asp:TextBox>
			</div>
			<div class="field">
				<label>كلمة المرور</label>
				<asp:TextBox runat="server"  TextMode="password" TabIndex="2" placeholder="Password" ID="txtPassword"></asp:TextBox>
			</div>
			<div class="field">
				<asp:Button ID="btnLogin" runat="server" OnClick="btnSave_Click" CssClass="ui blue button" Style="width: 100%" Text="Login" />
			</div>
		</form>

	</div>
</div>
<div class="sixteen wide column ui grid">
	<div class="eight wide column" id="foot">

	</div>
</div>
</div>

<input type="hidden" id="hidden" value="0">
</body>

</html>