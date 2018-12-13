using System;
using System.IO;
using System.Threading.Tasks;
using Dentistry_CRM.Models;
using iTextSharp.text.pdf;

namespace Dentistry_CRM.Services
{
    public class CheckService
    {
        private readonly iTextSharp.text.Document _document;
        public CheckService()
        {
            _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A6);
            ////using (var writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))
            ////{
            ////    document.Open();

            ////    // do some work here

            ////    document.Close();
            ////    writer.Close();
            ////}
            //BaseFont bf = BaseFont.CreateFont(@"C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //var headingFont = new iTextSharp.text.Font(bf, 13, Font.BOLD);
            //var dayFont = new iTextSharp.text.Font(bf, 11, Font.NORMAL);
            //var mainFont = new Font(bf, 12, Font.NORMAL);
            //var document = new Document(iTextSharp.text.PageSize.A4);
            ////PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Mounth + "." + year + ".pdf", FileMode.OpenOrCreate));
            //document.Open();
            //iTextSharp.text.Paragraph EmptyParagraph = new iTextSharp.text.Paragraph(" ");
            ////iTextSharp.text.Paragraph para = new iTextSharp.text.Paragraph(Mounth, new Font(bf, 15, Font.BOLD));
            //para.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            //document.Add(para);
            //document.Add(EmptyParagraph);
            //PdfPTable table = new PdfPTable(7);
        }

        public async Task GenerateCheck(DateTime time,Patient patient)
        {
            using (var writer = PdfWriter.GetInstance(_document,
                new FileStream(patient.Fullname + "." + time.ToShortDateString() + ".pdf", FileMode.OpenOrCreate)))
            {
                _document.Open();
            }
        }
    }
}
