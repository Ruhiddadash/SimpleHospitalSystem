<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HospitalSystem.Doctor" %>

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
        .list{
            background-color:#fff;
            width:20vw;
            margin-right:20px;
        }
        .container{
            margin-top:60px;
            display:flex;
            padding:10px;
        }
        .account{
            font-family:'Tw Cen MT';
            font-size:20px;
            font-weight:800;
            position:absolute;
            right:9%;
            margin-top:20px;
        }
        .input{
            font-family:'Tw Cen MT';
            position:absolute;
            margin-top:15px;
            right:20%;
            width:100px;
            height:30px;
            color:black;
            font-size:16px;
            background-color:transparent;
        }
        .img{
            position:absolute;
            right:17%;
            margin-top:22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="uppanel">
        <img src ="healthcare.png" alt="Alternate Text" class="image"/>
        <h1 class="logo">Medical Help</h1>
            <asp:TextBox ID="Tb_search" runat="server" placeholder="Catagory" CssClass="input"></asp:TextBox>
            <asp:ImageButton ID="Img_search" Height="25px" Width="25px" runat="server" CssClass="img" ImageUrl="~/search.png" OnClick="Img_search_Click" />
            <asp:Label ID="Lbl_account" runat="server" CssClass="account" Text="Label"></asp:Label>
            <asp:Button ID="Btn_logout" runat="server" CssClass="logout" Text="Log Out" OnClick="Btn_logout_Click" />
 
    </div>
        <div class="container">
                 <asp:ListView ID="ListView_doctor" runat="server">
                <ItemTemplate>
                    <div class="list">
                        <table>
                            <tr>
                                <td>
                                    <img src ="image/<%#Eval("image") %>.<%#Eval("imageext") %>" style="width:250px; "/>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <h1>
                                <%#Eval("Username") %>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>
                                <%#Eval("Catagory") %>
                                    </h3>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <%#Eval("description") %>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            </div>
    </form>
</body>
</html>
