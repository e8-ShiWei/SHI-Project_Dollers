<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Dollers.register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-碎心湖-师大匿名版</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/register.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-xs-12 col-sm-offset-3 register_box">
                <div class="form-group">
                    <label for="room_name" class="col-sm-2 control-label">
                        房间名称</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="room_name" placeholder="请输入房间名称" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="max_count" class="col-sm-2 control-label">
                        最大人数</label>
                    <div class="col-sm-10">
                        <select class="form-control" id="max_count" runat="server">
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="createBtn" runat="server" Text="创建" CssClass="btn btn-primary" 
                            onclick="createBtn_Click" />
                        <a href="list.aspx" class="btn btn-default">返回</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
