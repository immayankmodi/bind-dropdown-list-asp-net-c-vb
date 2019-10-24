<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxCascadingDropDownList.aspx.cs"
    Inherits="BindDropDownListExamples.AjaxCascadingDropDownList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AspnetO | Ajax bind cascading country-state-city dropdownlist without page refresh example in asp.net</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <h4>Ajax bind cascading country-state-city dropdownlist without page refresh</h4>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>Select Country:
                            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Select State:
                            <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                AutoPostBack="true">
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
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <div id="ajaxloader">
                                Loading..
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
