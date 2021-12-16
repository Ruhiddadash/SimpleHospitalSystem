<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="HospitalSystem.Forget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            margin:0;
            padding:0;
            background-image:url('background.jpg');
            background-size:auto;
            font-family:'Tw Cen MT';
        }
        .panel{
            position:absolute;
            top:50%;
            left:20%;
            transform:translate(-50%,-50%);
            width:350px;
            height:220px;
            padding:20px 40px;
            box-sizing:border-box;
            background:rgba(0,0,0,0.5);
        }
        .input{
            width:100%;
            border:none;
            border-bottom:3px solid;
            outline:none;
            height:25px;
            color:#fff;
            font-size:14px;
            background-color:transparent;
        }
        ::-webkit-input-placeholder{
            color:#fff;
        }
        .button{
            margin-top:15px;
            border:none;
            outline:none;
            height:45px;
            width:60px;
            font-size:14px;
            color:#fff;
            background-color:rgb(255,9,9);
            cursor:pointer;
            transition:.3s ease-in-out;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel">
            <asp:TextBox ID="tb_email" CssClass="input" runat="server" placeholder="Email"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tb_code" CssClass="input" runat="server" placeholder="Reset Code"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tb_new" CssClass="input" runat="server" placeholder="New Password"></asp:TextBox>
            <asp:CheckBox ID="Cb_doctor" runat="server" Text="Doctor"/>
            <br />
            <asp:Button ID="Btn_send" runat="server" CssClass="button" Text="Send" OnClick="Btn_send_Click" />
            <asp:Button ID="Btn_sumbit" runat="server" CssClass="button" Text="Submit" OnClick="Btn_sumbit_Click" />
            <asp:Button ID="Btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="Btn_reset_Click" />

        </div>
    </form>
</body>
</html>
