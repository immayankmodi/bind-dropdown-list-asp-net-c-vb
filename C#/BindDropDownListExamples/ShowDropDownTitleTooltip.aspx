<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDropDownTitleTooltip.aspx.cs"
    Inherits="BindDropDownListExamples.ShowDropDownTitleTooltip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AspnetO | Show Title/Tooltip in asp.net dropdownlist items dynamically </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Show Title/Tooltip in asp.net dropdownlist items dynamically</h4>
            Select Subject:
        <asp:DropDownList ID="ddlSubjects" runat="server" OnDataBound="ddlSubjects_OnDataBound">
        </asp:DropDownList>
        </div>
    </form>
</body>
</html>
