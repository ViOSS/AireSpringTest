<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="AireSpringTest.Web.Employees" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }

            table th {
                background-color: #B8DBFD;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
            }

            table, table table td {
                border: 0px solid #ccc;
            }
        .auto-style1 {
            height: 50px;
        }
        .auto-style2 {
            width: 75px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="dvGrid" style="padding: 10px; width: 450px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <h2>Search:</h2>
                        <table border="1" style="border-collapse: collapse">
                            <tr>
                                <td style="width: 170px">Last Name:<br />
                                    <asp:TextBox ID="txtLastNameSearch" runat="server" Width="170"></asp:TextBox>
                                </td>
                                <td style="width: 170px">Phone:<br />
                                    <asp:TextBox ID="txtPhoneSearch" runat="server" Width="170"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedSearchExtender" runat="server" TargetControlID="txtPhoneSearch"
                                        Mask="(999) 999-9999" MessageValidatorTip="true" MaskType="None" ClearMaskOnLostFocus="false"></cc1:MaskedEditExtender>
                                </td>
                                <td style="width: 75px">
                                    <asp:Button ID="btnSearch" Width="75" runat="server" Text="Search" OnClick="Search" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <h2>Employees:</h2>
                        <asp:GridView
                            ID="employeesGrid"
                            runat="server"
                            AutoGenerateColumns="False"
                            OnRowDataBound="OnRowDataBound"
                            DataKeyNames="EmployeeID"
                            OnRowEditing="OnRowEditing"
                            OnRowCancelingEdit="OnRowCancelingEdit"
                            PageSize="5"
                            AllowPaging="True"
                            OnPageIndexChanging="OnPaging"
                            OnRowUpdating="OnRowUpdating"
                            OnRowDeleting="OnRowDeleting"
                            EmptyDataText="No records has been added."
                            Width="1024">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>' Width="100"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeLastName" runat="server" Text='<%# Eval("EmployeeLastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeLastName" runat="server" Text='<%# Eval("EmployeeLastName") %>' Width="150px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeFirstName" runat="server" Text='<%# Eval("EmployeeFirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeFirstName" runat="server" Text='<%# Eval("EmployeeFirstName") %>' Width="140"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeePhone" runat="server" Text='<%# Eval("EmployeePhone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeePhone" runat="server" Text='<%# Eval("EmployeePhone") %>' Width="140" CssClass="MaskText"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="maskedEditPhone" runat="server" TargetControlID="txtEmployeePhone"
                                            Mask="(999) 999-9999" MessageValidatorTip="true" MaskType="None" ClearMaskOnLostFocus="false"></cc1:MaskedEditExtender>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zip" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeZip" runat="server" Text='<%# Eval("EmployeeZip") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeZip" runat="server" Text='<%# Eval("EmployeeZip") %>' Width="140"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hire Date" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHireDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "HireDate")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHireDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "HireDate")).ToString("MM/dd/yyyy") %>' Width="140"></asp:TextBox>
                                        <cc1:CalendarExtender ID="calendarExtender" Format="MM/dd/yyyy" TargetControlID="txtHireDate" runat="server"></cc1:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                    ItemStyle-Width="150">
                                    <ItemStyle Width="150px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <table border="1" style="border-collapse: collapse">
                            <tr>
                                <td style="width: 170px">Last Name *<br />
                                    <asp:TextBox ID="txtLastName" runat="server" Width="170"></asp:TextBox>
                                </td>
                                <td style="width: 170px">First Name *<br />
                                    <asp:TextBox ID="txtFirstName" runat="server" Width="170"></asp:TextBox>
                                </td>
                                <td style="width: 170px">Phone<br />
                                    <asp:TextBox ID="txtPhone" runat="server" Width="170"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="maskedAddPhone" runat="server" TargetControlID="txtPhone"
                                        Mask="(999) 999-9999" MessageValidatorTip="true" MaskType="None" ClearMaskOnLostFocus="false"></cc1:MaskedEditExtender>
                                </td>
                                <td style="width: 170px">Zip<br />
                                    <asp:TextBox ID="txtZip" runat="server" Width="170"></asp:TextBox>
                                </td>
                                <td style="width: 170px">Hire Date *<br />
                                    <asp:TextBox ID="txtHireDate" runat="server" Width="170"></asp:TextBox>
                                    <cc1:CalendarExtender ID="calendarExtender" Format="MM/dd/yyyy" TargetControlID="txtHireDate" runat="server"></cc1:CalendarExtender>
                                </td>
                                <td style="width: 75px">
                                    <asp:Button ID="btnAdd" Width="75" runat="server" Text="Add" OnClick="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1" colspan="6">
                                    <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" ForeColor="#000066"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
