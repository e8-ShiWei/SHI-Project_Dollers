<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Dollers.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-碎心湖-师大匿名版</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/list.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row user_box">
            <div class="col-sm-6 col-xs-12 col-sm-offset-3">
                <div class="profile">
                    <asp:Image ID="profile" runat="server" /><asp:Label ID="username" runat="server"
                        Text="username"></asp:Label></div>
                <div class="exit">
                    <asp:Button ID="exitBtn" runat="server" Text="退出" CssClass="btn btn-danger btn-xs btn-lg btn-block"
                        OnClick="exitBtn_Click" />
                </div>
            </div>
        </div>
        <div class="list_box col-sm-6 col-xs-12 col-sm-offset-3">
            <div class="top_info">
                <div class="row">
                    <div class="col-sm-6 col-xs-6">
                        目前共有
                        <asp:Label ID="count" runat="server" Text="count"></asp:Label>
                        人在线！
                    </div>
                    <div class="col-sm-3 col-xs-4 col-sm-offset-3 col-xs-offset-2 button">
                        <a href="register.aspx" class="btn btn-success btn-xs btn-lg btn-block">创建房间</a>
                    </div>
                </div>
            </div>
            <asp:Repeater ID="room_Repeater" runat="server">
                <ItemTemplate>
                    <div>
                        <div class="room_item">
                            <div class="row">
                                <div class="col-sm-5 col-xs-5">
                                    <span class="glyphicon glyphicon-home"></span>
                                    <%#(string)Container.DataItem%>
                                </div>
                                <div class="col-sm-4 col-xs-3">
                                    <%#getCountAndMaxCount((string)Container.DataItem)%>
                                </div>
                                <div class="col-sm-3 col-xs-4 button">
                                    <a href="room.aspx?room=<%#(string)Container.DataItem%>" class='btn btn-info btn-xs btn-lg btn-block <%#roomIsFull((string)Container.DataItem)?"disabled":""%>'>
                                        进入房间</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
