<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="room.aspx.cs" Inherits="Dollers.room" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>-碎心湖-师大匿名版</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.css" type="text/css" rel="Stylesheet" />
    <link href="css/bootstrap-theme.min.css" type="text/css" rel="Stylesheet" />
    <link href="css/dollers.css" type="text/css" rel="Stylesheet" />
    <link href="css/tag.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="message_box">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-xs-12 col-sm-offset-3">
                    <div class="row">
                        <div class="col-sm-2 col-xs-2 message_name">
                            <h4>
                                <asp:Label ID="name" runat="server" Text="name"></asp:Label></h4>
                        </div>
                        <div class="col-sm-2 col-xs-3 message_signout">
                            <h4>
                                <asp:Button ID="signout_btn" runat="server" Text="退出" CssClass="btn btn-primary btn-lg btn-block btn-xs"
                                    OnClick="signout_btn_Click" />
                            </h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-xs-12 message_input">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="message_text" runat="server" CssClass="form-control" Rows="4" MaxLength="140"
                                        TextMode="MultiLine"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="submit_btn" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-4 col-sm-offset-4 col-xs-offset-4 message_submit">
                            <asp:Button ID="submit_btn" runat="server" Text="提交" CssClass="btn btn-primary btn-lg btn-block btn-xs"
                                OnClick="submit_btn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="message_content container" id="messages">
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:Repeater ID="message_Repeater" runat="server">
                    <ItemTemplate>
                        <div class="row" <%#((Dollers.model.Message)Container.DataItem).is_message?"style='display:block'":"style='display:none'"%>>
                            <div class="col-sm-1 col-xs-2 col-sm-offset-3">
                                <div class="profile">
                                    <img src='<%#((Dollers.model.Message)Container.DataItem).user_profile %>' width="100%" />
                                    <%#((Dollers.model.Message)Container.DataItem).user_name%></div>
                            </div>
                            <div class="col-sm-5 col-xs-10">
                                <div class="tag">
                                    <div class="arrow">
                                        <em></em><span></span>
                                    </div>
                                    <div class="text">
                                        <%#((Dollers.model.Message)Container.DataItem).content%><div class="clear">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" <%#((Dollers.model.Message)Container.DataItem).is_message?"style='display:none'":"style='display:block'"%>>
                            <div class="col-sm-5 col-xs-7 col-sm-offset-3">
                                <div class="info">
                                    <%#((Dollers.model.Message)Container.DataItem).content%></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="submit_btn" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
