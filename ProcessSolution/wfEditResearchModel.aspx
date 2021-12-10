<%@ Page Title="" Language="C#" MasterPageFile="~/masterSite.Master" AutoEventWireup="true" CodeBehind="wfEditResearchModel.aspx.cs" Inherits="ProcessSolution.wfEditResearchModel" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
    $(document).ready(function () {
        $('[data-toggle="popover"]').popover();
    });
</script>

    <asp:Button ID="Button1" runat="server" Text="add" OnClick="Button1_Click" CssClass="btn btn-outline-danger small" style="font-size: smaller;" /><br />
    <asp:GridView ID="dg0" cssclass="table table-light table-hover small" runat="server" OnRowCommand="dg0_RowCommand" AutoGenerateColumns="false">
        <Columns>
             <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lb1" runat="server" Text="Numer"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txNumber" runat="server" Text='<%#Eval("Number") %>'></asp:TextBox>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lb2" runat="server" Text="Nazwa"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lb3" runat="server" Text="Opis"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>

                    <asp:TextBox ID="txDescription" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lb4" runat="server" Text="Planowany start"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txstart" runat="server" Text='<%#Eval("ResearchPlannedStartTime","{0:yyyy-MM-dd}") %>'  TextMode="Date"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lb5" runat="server" Text="Planowany koniec"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txend" runat="server" Text='<%#Eval("ResearchPlannedEndTime","{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <HeaderTemplate>

                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button7" runat="server" Text="Wybierz" CommandArgument='<%#Eval("id") %>' CommandName="sel" CssClass="btn btn-outline-primary small" style="font-size: smaller;" />
                    <asp:Button ID="Button8" runat="server" Text="Zapisz" CommandArgument='<%#Eval("id") %>' CommandName="sav" CssClass="btn btn-outline-success small" style="font-size: smaller;" />
                    <asp:Button ID="Button9" runat="server" Text="Usuń" CommandArgument='<%#Eval("id") %>' CommandName="del" CssClass="btn btn-outline-danger small" style="font-size: smaller;" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>





    <asp:Button ID="Button2" runat="server" Text="save" OnClick="Button2_Click" CssClass="btn btn-outline-success" style="font-size: smaller;" />
     <asp:Button ID="Button3" runat="server" Text="add column" OnClick="Button3_Click" CssClass="btn btn-outline-secondary" style="font-size: smaller;" /><br />
    <asp:GridView ID="dg1" cssclass="table table-light table-hover small" runat="server" OnRowCommand="dg1_RowCommand" OnRowDataBound="dg1_RowDataBound" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txname" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txdescription" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label3" runat="server" Text="itemType"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txitemtype" runat="server" Text='<%#Eval("itemType") %>' style="visibility:hidden;max-width:1px;max-height:1px;"></asp:TextBox>
                    <asp:DropDownList ID="ddlitemtype" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label4" runat="server" Text="ListPossibleItems"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<asp:TextBox ID="txlistpossibleitems" runat="server" Text='<%#Eval("ListPossibleItems") %>' textmode="MultiLine" Width="400"></asp:TextBox>--%>
                    <asp:Button ID="btnAddListItem" runat="server" Text="add column" OnClick="btnAddListItem_Click" CssClass="btn btn-outline-secondary" CommandArgument='<%#Eval("id") %>' style="font-size: smaller;" /><br />
                    <asp:GridView ID="dgitems" runat="server" AutoGenerateColumns="false" OnRowCommand="dgitems_RowCommand">
                        <Columns>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lb1" runat="server" Text="Nazwa"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txname" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lb2" runat="server" Text="Opis"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txdescription" runat="server" Text='<%#Eval("description") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnSave" runat="server" Text="Zapisz" CssClass="btn btn-outline-success small" CommandArgument='<%#Eval("id") %>' CommandName="sav" />
                                    <asp:Button ID="btndel" runat="server" Text="Usuń" CssClass="btn btn-outline-danger small" CommandArgument='<%#Eval("id") %>' CommandName="del" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Usun" CommandArgument='<%#Eval("id") %>' CssClass="btn btn-outline-danger" style="font-size: smaller;" />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView><br />
     <asp:Button ID="Button6" runat="server" Text="addEntry" OnClick="Button6_Click" CssClass="btn btn-outline-primary" style="font-size: smaller;" />   
    <br />
    <asp:GridView ID="dg2" cssclass="table table-light table-hover small" runat="server" OnRowCommand="dg2_RowCommand">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button4" runat="server" Text="Edit" CommandArgument='<%#Eval("id") %>' CommandName="ed" CssClass="btn btn-outline-primary" style="font-size: smaller;"/>
                    <asp:Button ID="btnDelete" runat="server" Text="Usun" CommandArgument='<%#Eval("id") %>'  CommandName="del" CssClass="btn btn-outline-danger" style="font-size: smaller;"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>      
    </asp:GridView><br />


    <div id="editEntry" runat="server" class="card text-white bg-secondary mb-3 container"  style="position: absolute;top: 50%;left: 50%;transform: translate(-50%, -50%);width:400px;">
        <div class="card-header">
            <asp:Button ID="btnCardClose" runat="server" CssClass="btn-close" style="float:right;" OnClick="btnCardClose_Click" Text="" />
        </div>

        <div onchange="intent()">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
    <asp:Label ID="lbid" runat="server" Text="0" style="visibility:hidden;height:0px;"></asp:Label>
    </div>
    <asp:Button ID="Button5" runat="server" Text="Przelicz" OnClick="Button5_Click" />
</asp:Content>
