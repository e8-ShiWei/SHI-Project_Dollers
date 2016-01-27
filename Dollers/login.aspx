<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Dollers.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-碎心湖-师大匿名版</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/login.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row logo_box">
                <div class="col-sm-4 col-xs-10 col-sm-offset-4 col-xs-offset-1">
                    <div class="logo">
                        <div class="logo_text">
                            河北师范大学 匿名聊天室 / Dollers
                        </div>
                    </div>
                </div>
            </div>
            <div class="row login_input">
                <div class="col-sm-4 col-xs-10 col-sm-offset-4 col-xs-offset-1">
                    USERNAME:
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row login_button">
                <div class="col-sm-2 col-xs-4 col-sm-offset-5 col-xs-offset-4">
                    <asp:Button ID="loginBtn" runat="server" Text="ENTER"
                        CssClass="btn btn-primary btn-lg btn-block btn-xs" OnClick="loginBtn_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
