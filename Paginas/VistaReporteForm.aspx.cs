using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationReport.Clases;

namespace WebApplicationReport.Paginas
{

    public partial class VistaReporteForm : System.Web.UI.Page
    {
        List<Persona> personas = new List<Persona>
            {
                new Persona { ID = 1, Nombre = "John Doe", Edad = 30 },
                new Persona { ID = 2, Nombre = "Jane Smith", Edad = 25 },
                new Persona { ID = 3, Nombre = "Sam Brown", Edad = 40 }
            };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }

        }
        public void CargarTabla()
        {
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }
        public void btnGenerar_Click(object sender, EventArgs e)
        {

            // Ruta temporal para guardar el PDF
            string filePath = Server.MapPath("~/DescargaReportes/GeneratedReport.pdf");

            // Crear el archivo PDF
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);
                    document.Add(new Paragraph("Reporte de Personas"));

                    foreach (var person in personas)
                    {
                        document.Add(new Paragraph($"ID: {person.ID}"));
                        document.Add(new Paragraph($"Nombre: {person.Nombre}"));
                        document.Add(new Paragraph($"Edad: {person.Edad}"));
                        document.Add(new Paragraph("-------------------------------------------------------"));
                    }

                    document.Close();
                }
            }

            // Descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}