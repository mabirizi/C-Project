﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectOne.Register" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <!-- Required meta tags-->
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content="au theme template"/>
    <meta name="author" content="Hau Nguyen"/>
    <meta name="keywords" content="au theme template"/>

    <!-- Title Page-->
    <title>Register</title>

    <!-- Fontfaces CSS-->
    <link href="assets/css/font-face.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all"/>

    <!-- Bootstrap CSS-->
    <link href="assets/vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all"/>

    <!-- Vendor CSS-->
    <link href="assets/vendor/animsition/animsition.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/wow/animate.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/slick/slick.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/select2/select2.min.css" rel="stylesheet" media="all"/>
    <link href="assets/vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all"/>

    <!-- Main CSS-->
    <link href="assets/css/theme.css" rel="stylesheet" media="all"/>
</head>
<body class="animsition">
    <form id="form1" runat="server">
         <div class="page-wrapper">
        <div class="page-content--bge5">
            <div class="container">
                <div class="login-wrap">
                    <div class="login-content">
                        <div class="login-logo">
                            <a href="#">
                                <img src="assets/images/icon/logo.png" alt="CoolAdmin"/>
                            </a>
                        </div>
                        <div class="login-form">
                            <%--<form action="" method="post" runat="server">--%>
                            <div class="row">
                                <div class="form-group  col-md-6">
                                    <label>FirstName</label>
                                    <asp:TextBox ID="txtFirstName" class="au-input au-input--full" placeholder="Firstname" runat="server"></asp:TextBox>
                                </div>
                             <div class="form-group col-md-6">
                                    <label>LastName</label>
                                    <asp:TextBox ID="txtLastName" class="au-input au-input--full" placeholder="Lastname" runat="server"></asp:TextBox>
                                </div>
                            </div>
                                
                                <div class="form-group">
                                    <label>Email Address</label>
                                    <asp:TextBox ID="txtEmail" class="au-input au-input--full" type="email" placeholder="john@doe.com" runat="server"></asp:TextBox>
                                </div>
                             <div class="form-group">
                                    <label>Telephone Number</label>
                                    <asp:TextBox ID="txtTelephoneNumber" class="au-input au-input--full" placeholder="0779014758" runat="server"></asp:TextBox>
                                </div>
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtPassword" class="au-input au-input--full" type="password" runat="server"></asp:TextBox>

                                </div>
                            <div class="form-group col-md-6">
                                    <label>Confirm Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" class="au-input au-input--full" type="password" runat="server"></asp:TextBox>

                                </div>
                            </div>
                                
                                <div class="login-checkbox">
                                    <label>
                                        
                                        <asp:CheckBox ID="CheckBox1" name="aggree" runat="server" />Agree the terms and policy
                                    </label>
                                </div>


                              


                                        
                                <asp:Button ID="AdminLoginRegister" class="au-btn au-btn--block au-btn--green m-b-20"  runat="server" Text="register" OnClick="AdminLoginRegister_Click"   />
                                <%--<button >register</button>--%>
                                <%--<div class="social-login-content">
                                    <div class="social-button">
                                        <button class="au-btn au-btn--block au-btn--blue m-b-20">register with facebook</button>
                                        <button class="au-btn au-btn--block au-btn--blue2">register with twitter</button>
                                    </div>
                                </div>--%>
                            <%--</form>--%>
                            <div class="register-link">
                                <p>
                                    Already have account?
                                    <a href="Login.aspx">Log In</a>
                                </p>
                            </div>
                            <div class="form-group">
                                            <p> <asp:Label ID="Label1" runat="server" ></asp:Label></p>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
        
    </form>

    <!-- Jquery JS-->
    <script src="assets/vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="assets/vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="assets/vendor/bootstrap-4.1/bootstrap.min.js"></script>
    <!-- Vendor JS       -->
    <script src="assets/vendor/slick/slick.min.js">
    </script>
    <script src="assets/vendor/wow/wow.min.js"></script>
    <script src="assets/vendor/animsition/animsition.min.js"></script>
    <script src="assets/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="assets/vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="assets/vendor/counter-up/jquery.counterup.min.js">
    </script>
    <script src="assets/vendor/circle-progress/circle-progress.min.js"></script>
    <script src="assets/vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="assets/vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="assets/vendor/select2/select2.min.js">
    </script>

    <!-- Main JS-->
    <script src="assets/js/main.js"></script>
</body>
</html>
