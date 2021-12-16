<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPassient.aspx.cs" Inherits="HospitalSystem.ViewPassient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        body{
            background-color:grey;
        }
        .uppanel {
            position: absolute;
            top: 0;
            right: 0;
            bottom: 92%;
            left: 0;
            background: #fff;
        }
        .image{
            width:50px;
            height:50px;
            position:absolute;
            left:3%;
            margin-top:5px;
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
         .input{
            width:80%;
            border:none;
            border-bottom:3px solid;
            outline:none;
            height:25px;
            color:#fff;
            font-size:14px;
            background-color:transparent;
        }
          .panel{
            position:absolute;
            top:50%;
            left:20%;
            transform:translate(-50%,-50%);
            width:380px;
            height:300px;
            padding:20px 40px;
            box-sizing:border-box;
            background:rgba(0,0,0,0.5);
        }
          .view{
            position:absolute;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%);
            width:auto;
            height:auto;
            padding:20px 40px;
            box-sizing:border-box;
            background:#fff;
          }
          .submit{
            margin-top:10px;
            border:none;
            outline:none;
            height:40px;
            font-size:14px;
            color:#fff;
            background-color:rgb(255,9,9);
            cursor:pointer;
            transition:.3s ease-in-out;
          }
          .account{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:800;
            position:absolute;
            right:9%;
            margin-top:20px;
        }
          ::-webkit-input-placeholder{
            color:#fff;
        }
          .submit{
            margin-top:10px;
            border:none;
            outline:none;
            height:40px;
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
        <div class="uppanel">
        <img src ="healthcare.png" alt="Alternate Text" class="image"/>
        <h1 class="logo">Medical Help</h1>
            <asp:Label ID="Lbl_account" runat="server" CssClass="account" Text="Label"></asp:Label>
            <asp:Button ID="Btn_logout" runat="server" CssClass="logout" Text="Log Out" OnClick="Btn_logout_Click" />
        </div>
        <div class="panel">
            <asp:TextBox ID="Tb_id" runat="server" CssClass="input" placeholder="Appoinment ID"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Btn_delete" runat="server" CssClass="submit" Text="Delete" OnClick="Btn_delete_Click" />
        </div>
        <div class="view">
            <asp:GridView ID="GridView_appoint" runat="server" Height="284px" style="margin-left: 0px" Width="363px"></asp:GridView>
        </div>
    </form>
</body>
</html>
