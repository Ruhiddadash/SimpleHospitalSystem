<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardDoctor.aspx.cs" Inherits="HospitalSystem.DashboardDoctor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
     <style>
        body {
            margin: 0;
            padding: 0;
            background-image: url('cover4.jpg');
            background-size:cover;
            font-family: 'Tw Cen MT';
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
        #h1{
            font-family: 'Tw Cen MT';
            font-weight:bold;
            font-size:40px;
            position:absolute;
            top:30%;
            left:8%
        }
        #h2{
            font-family: 'Tw Cen MT';
            font-weight:bold;
            font-size:40px;
            position:absolute;
            top:35%;
            left:8%
        }
        #h3{
            font-family: 'Tw Cen MT';
            font-weight:300;
            font-size:20px;
            width:35vw;
            position:absolute;
            top:45%;
            left:8%
            
        }
        .apointment{
            position:absolute;
            left:8%;
            bottom:32%;
            border:none;
            outline:none;
            height:45px;
            width:auto;
            font-size:18px;
            color:#fff;
            background-color:rgb(255,9,9);
            cursor:pointer;
            transition:.3s ease-in-out;
            font-family: 'Tw Cen MT';
            font-weight:bold;
        }
        .doctor{
            position:absolute;
            left:17%;
            bottom:32%;
            border:none;
            outline:none;
            height:45px;
            width:auto;
            font-size:18px;
            color:#fff;
            background-color:rgb(255,9,9);
            cursor:pointer;
            transition:.3s ease-in-out;
            font-family: 'Tw Cen MT';
            font-weight:bold;
        }
        .account{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:800;
            position:absolute;
            right:9%;
            margin-top:20px;
        }
    </style>
</head>
<body class="bodyuser">
        <form id="dashboard" runat="server">

   
    <div class="uppanel">
        <img src ="healthcare.png" alt="Alternate Text" class="image"/>
        <h1 class="logo">Medical Help</h1>
        <asp:Label ID="Lbl_account" runat="server" CssClass="account" Text="Label"></asp:Label>
        <asp:Button ID="Btn_logout" runat="server" CssClass="logout" Text="Log Out" OnClick="Btn_logout_Click" />
        
        
    </div>
        <p id="h1">Making Health</p>
        <p id="h2">Care Better Together</p>
        <p id="h3">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
          </p>
            <asp:Button ID="Btn_update" runat="server" CssClass="apointment" Text="Update Profile" OnClick="Btn_update_Click"/>
            <asp:Button ID="Btn_view" runat="server" CssClass="doctor" Text="View My Passient" OnClick="Btn_view_Click"  />
    </form>
        </body>
</html>
