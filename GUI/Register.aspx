﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="Style/main.css" />
    <link rel="stylesheet" href="Style/toast.css" />
    <link rel="stylesheet" href="Style/modal.css" />
    <title>Đăng Ký</title>
</head>
<body>
    <div id="toast"></div>
    <div class="modal hide">
        <span class="overlay"></span>
        <div class="modal-box">

            <div class="content-modal">
                <i class="fa-regular fa-circle-check"></i>
                <h2>Đăng Ký Thành Công</h2>
                <h3>Bạn đã đăng ký tài khoản thành công, bây giờ bạn có thể đăng nhập ngay!</h3>
            </div>

            <div class="buttonsmodal">
                <div class="btn-modal">
                    <a href="Login.aspx">Đăng Nhập Ngay!</a>
                </div>
                <button class="btn-modal close-btn">Đóng</button>
            </div>
        </div>
    </div>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container login-page">
                    <div class="login">
                        <div class="login__form">
                            <div class="login-form__title">
                                <p>Đăng Ký</p>
                            </div>

                            <div class="login-form__field">
                                <i class="fa-solid fa-envelope"></i>
                                <asp:TextBox ID="txtEmail" runat="server" type="text" placeholder="Địa chỉ Email"></asp:TextBox>
                            </div>

                            <div class="login-form__field">
                                <i class="fa-solid fa-user"></i>
                                <asp:TextBox ID="txtDisplayName" runat="server" type="text" placeholder="Tên Hiển Thị"></asp:TextBox>
                            </div>

                            <div class="login-form__field">
                                <i class="fa-solid fa-user"></i>
                                <asp:TextBox ID="txtUserName" runat="server" type="text" placeholder="Tên Đăng Nhập"></asp:TextBox>
                            </div>

                            <div class="login-form__field">
                                <i class="fa-sharp fa-solid fa-key"></i>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" type="text" placeholder="Mật Khẩu"></asp:TextBox>
                            </div>

                            <div class="login-form__field">
                                <i class="fa-sharp fa-solid fa-key"></i>
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" type="text" placeholder="Xác Nhận Mật Khẩu"></asp:TextBox>
                            </div>

                            <div class="login-form__field error-field">
                                <asp:Label ID="lblError" runat="server" Text="" class="text-error"></asp:Label>
                            </div>

                            <div class="login--field">
                                <asp:Button ID="btnRegister" runat="server" Text="Đăng Ký" class="btn" OnClick="btnRegister_Click" />
                            </div>

                            <div class="login-form__field sub-field">
                                <asp:Label ID="Label1" runat="server" Text="Đã có tài khoản?"></asp:Label>
                                <a href="dang-nhap">Đăng Nhập</a>
                            </div>

                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="Animation/Check/js.js"></script>
    <script src="JS/modal.js"></script>
    <script src="JS/toast.js"></script>
</body>
</html>
