<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="HospitalSystem.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:grey;
            font-family:'Tw Cen MT';
        }
        .panel{
            position:absolute;
            margin-top:25%;
            left:50%;
            transform:translate(-50%,-50%);
            width:350px;
            height:450px;
            padding:70px 40px;
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
            font-size:16px;
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
        .uppanel {
            position: absolute;
            top: 0;
            right: 0;
            bottom: 92%;
            left: 0;
            background: #fff;
        }
        .logo{
            position:absolute;
            left:8%;
            margin-top:15px;
            font-family: 'Tw Cen MT';
            font-weight:bold;
            color:black;
        }
        .logout{
            position:absolute;
            right:3%;
            margin-top:10px;
            font-family: 'Tw Cen MT';
            font-weight:bold;
            border:none;
            outline:none;
            height:40px;
            width:auto;
            font-size:14px;
            color:#fff;
            background-color:rgb(255,9,9);
            cursor:pointer;
            transition:.3s ease-in-out;
        }
        .image{
            width:50px;
            height:50px;
            position:absolute;
            left:3%;
            margin-top:5px;
        }
        .account{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:800;
            position:absolute;
            right:9%;
            margin-top:20px;
        }
        .status{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:800;
            margin-right:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="uppanel">
        <img src ="healthcare.png" alt="Alternate Text" class="image"/>
        <h1 class="logo">Medical Help</h1>
        <asp:Label ID="Lbl_account" runat="server" CssClass="account" Text="Label"></asp:Label>
        <asp:Button ID="Btn_logout" runat="server" CssClass="logout" Text="Log Out" OnClick="Btn_logout_Click" />
    </div>
        <div class="panel">
            <h2 style ="color:aliceblue;text-align:center">Update Profile</h2>
            <asp:TextBox ID="Tb_email" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="Tb_catagory" runat="server" CssClass="input" placeholder="Catagory"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="Tb_description" runat="server" CssClass="input" placeholder="Description"></asp:TextBox>
            <br />
            <br />
            <asp:FileUpload ID="Image_upload" runat="server" />
            <br />
            <br />
            <asp:Button ID="Btn_add" runat="server" Text="Add" CssClass="button" OnClick="Btn_add_Click" />
            <asp:Label ID="Lbl_status" runat="server" CssClass="status" Text="Status"></asp:Label>
        </div>
    </form>
</body>
</html>
