<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaReporteForm.aspx.cs" Inherits="WebApplicationReport.Paginas.VistaReporteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
     <asp:GridView CssClass="tablas" runat="server" ID="gvPersonas" AutoGenerateColumns="false" 
         EmptyDataText="No hay Datos Cargados"
         >
         <Columns>
             <asp:BoundField HeaderText="ID" DataField="ID"/>
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
             <asp:BoundField HeaderText="Edad" DataField="Edad"/>
         </Columns>
     </asp:GridView>

     <asp:Button runat="server" ID="btnGenerar" Text="Generar Reporte" OnClick="btnGenerar_Click" CssClass="botones"/>
 </div>
    </form>
</body>
</html>
