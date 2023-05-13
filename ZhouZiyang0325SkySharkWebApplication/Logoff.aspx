<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Logoff.aspx.cs" Inherits="ZhouZiyang0325SkySharkWebApplication.Logoff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HOME
    <style type="text/css">
        #TextArea1 {
            height: 165px;
            width: 752px;
        }
    </style>
    <style type="text/css">
        #TextArea1 {
            height: 130px;
            width: 1007px;
        }
    </style>
    <style type="text/css">
        #TextArea1 {
            height: 135px;
            width: 803px;
        }
        #form1 {
            height: 168px;
            width: 807px;
        }
    </style>
    <style type="text/css">
        #TextArea1 {
            height: 136px;
            width: 719px;
        }
        #form1 {
            height: 207px;
            width: 724px;
        }
    </style>
    <style type="text/css">
        #TextArea1 {
            height: 186px;
            width: 741px;
        }
        #form1 {
            margin-right: 299px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div style="height: 187px; width: 720px">
        
        <textarea id="TextArea1">
        Thank you for using SkyShark Airlines.
        Looking forward for serving you again.
    </textarea><br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Click Here to Logon</asp:HyperLink></div>
    </form>
</asp:Content>
