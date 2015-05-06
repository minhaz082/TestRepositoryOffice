<%@ Page Title="SolarHome Placing,Stored & Attainment Report" Language="C#" MasterPageFile="~/MegnaSolar.Master" AutoEventWireup="true" 
CodeBehind="rptSolarHomePlacingStoredAndAttainment.aspx.cs" Inherits="EATL.WebClient.CommonUI.rptSolarHomePlacingStoredAndAttainment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1 class="accordionHeaderSelected">
        Solar Home System Placing, Stored and Attainment Report</h1>
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
<table class="centerAlignedTable">                
                <tr>
                    <td class="LabelTD">
                        Branch Name 
                    </td>
                    <td><b>:</b></td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" CssClass="STextBox" Width="200px" runat="server"> </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD">
                        From Date 
                    </td>
                    <td><b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="STextBox" Width="250px"></asp:TextBox>
                        <ajaxConTK:CalendarExtender ID="calExtFromDate" runat="server" Enabled="True" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                        </ajaxConTK:CalendarExtender>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD">
                        To Date
                    </td>
                    <td><b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="STextBox" Width="250px"></asp:TextBox>
                        <ajaxConTK:CalendarExtender ID="calExtToDate" runat="server" Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                        </ajaxConTK:CalendarExtender>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td> </td>
                    <td align="left;">
                        <asp:Button ID="btnReport" runat="server" Text="Show Report" Width="100px"  OnClick="btnReport_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
            <td colspan="5">
                <asp:Label ID="lblWarning" runat="server" Text="" CssClass="LabelTD"></asp:Label>
            </td>
        </tr>
            </table>
</asp:Content>
