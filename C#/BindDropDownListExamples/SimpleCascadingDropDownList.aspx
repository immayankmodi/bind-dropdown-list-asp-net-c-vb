<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleCascadingDropDownList.aspx.cs"
    Inherits="BindDropDownListExamples.SimpleCascadingDropDownList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AspnetO | Simple cascading country-state-city dropdownlist example in asp.net</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Simple cascading country-state-city dropdownlist example in asp.net</h4>
            <table>
                <tr>
                    <td>Select Country:
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Select State:
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Select City:
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
