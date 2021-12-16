<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalSystem.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body class="loginbody">
    <div class="loginpanel">
        <form id="formlogin" autocomplete="off" runat="server">
        <img src ="doctor.png" alt="Alternate Text" class="user"/>
        <h1>Login here</h1>
        <br />
        <br />
            <asp:Label ID="lbl_username" runat="server" CssClass="lbluser" Text="Username"></asp:Label>
            <asp:TextBox ID="tb_username" runat="server" CssClass="tbuser"></asp:TextBox>
            <asp:Label ID="lbl_password" runat="server" CssClass="lblpass" Text="Password"></asp:Label>
            <asp:TextBox TextMode="Password" ID="tb_password" runat="server" CssClass="tbpass"></asp:TextBox>
            <asp:CheckBox ID="Cb_doctor" runat="server" CssClass="cb_doctor" Text="Doctor"/>
            <asp:Button ID="Btn_login" runat="server" CssClass="btnlogin" Text="Login" OnClick="Btn_login_Click" />
            <asp:Label ID="Lbl_status" runat="server" CssClass="lblstatus" Text="Status" Visible ="false"></asp:Label>
            <br />
            <asp:LinkButton ID="lbtn_forget" runat="server" CssClass="linkbtn_forget" OnClick="lbtn_forget_Click">Forget password?</asp:LinkButton>
            <asp:LinkButton ID="lbtn_register" runat="server" CssClass="linkbtn_create" OnClick="lbtn_register_Click">Create new account</asp:LinkButton>
        </form>
    </div>
</body>
</html>
