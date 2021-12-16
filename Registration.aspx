<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="HospitalSystem.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="style.css" rel="stylesheet" />
    <style>
        .registerpanel {
            position: absolute;
            top: 50%;
            left: 20%;
            transform: translate(-50%,-50%);
            width: 400px;
            height: 450px;
            padding: 70px 40px;
            box-sizing: border-box;
            background: rgba(0,0,0,0.5);
        }
        .input{
            width:100%;
            margin-bottom:20px;
            margin-top:5px;
            border:none;
            border-bottom:3px solid;
            outline:none;
            height:25px;
            color:#fff;
            font-size:14px;
            background-color:transparent;
        }
        .linkbtn_have{
            margin-left:8px;

        }
        .error{
            position: absolute;
            top: 72%;
            left:19%;
            transform: translate(-50%,-50%);
            width: auto;
            height: auto;
            padding: 80px 40px;
            box-sizing: border-box;
            background: rgba(0, 0, 0, 0.00);
        }
        ::-webkit-input-placeholder{
            color:#fff;
        }
        .lblstatus{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:700;
            color:antiquewhite;
            margin-left:auto;
            margin-right:auto;
            text-align:center;
        }
        
    </style>
</head>
<body class="registerbody">
    <form id="formregister" autocomplete="off" runat="server">
        <div class="registerpanel">
        
        <img src="doctor.png" alt="Alternate Text" class="user"/>
        <h1>Create Account</h1>
            
            <asp:TextBox ID="tb_email" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>

            
            <asp:TextBox ID="tb_username" runat="server" CssClass="input"  placeholder="Username"></asp:TextBox>

            
            <asp:TextBox ID="tb_password" runat="server" CssClass="input"  placeholder="Password"></asp:TextBox>

            
            <asp:TextBox ID="tb_confirm" runat="server" CssClass="input" placeholder="Confirm password"></asp:TextBox>

            <asp:CheckBox ID="Cb_doctor" runat="server" CssClass="cb_doctor" Text="Doctor"/>
            <asp:LinkButton ID="lbtn_register" runat="server" CssClass="linkbtn_have" OnClick="lbtn_register_Click" >Already have an account?</asp:LinkButton>
            <br />
            <asp:Label ID="Lbl_status" runat="server" CssClass="lblstatus" Text="Status" Visible ="false"></asp:Label>
            <asp:Button ID="Btn_register" runat="server" CssClass="btnregister" Text="Register" OnClick="Btn_register_Click"/>
            <br />
    </div>
        
    </form>
</body>
</html>
