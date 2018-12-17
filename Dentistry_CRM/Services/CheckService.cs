using System;
using System.IO;
using System.Threading.Tasks;
using Dentistry_CRM.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Dentistry_CRM.Services
{
    public class CheckService
    {
        private readonly Document _document;
        public CheckService()
        {
            _document = new Document(PageSize.A6);
            ////using (var writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))
            ////{
            ////    document.Open();

            ////    // do some work here

            ////    document.Close();
            ////    writer.Close();
            ////}

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

        public async Task<string> GenerateCheck(DateTime time,Patient patient)
        {
            var name = patient.Fullname + ".pdf";
            using (var writer = PdfWriter.GetInstance(_document,
                new FileStream(name, FileMode.OpenOrCreate)))
            {
                _document.Open();
                BaseFont bf = BaseFont.CreateFont(@"C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Paragraph emptyParagraph = new Paragraph(" ");
                Paragraph para = new Paragraph("Стоматологія", new Font(bf));
                para.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Chunk chunk = new Chunk("Підпис                      Дата : " + time.ToShortDateString(), new Font(bf));
                chunk.SetUnderline(0.5f, -1.5f);


                PdfPTable table = new PdfPTable(3);

                var cell = new PdfPCell();
                cell.MinimumHeight = 10;
                cell.Phrase = new Phrase(new Chunk("Номер",new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.MinimumHeight = 40;
                cell.Phrase = new Phrase(new Chunk("Послуга", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.MinimumHeight = 10;
                cell.Phrase = new Phrase(new Chunk("Ціна", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("1", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("Стирильний набір", new Font(bf,10)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("500", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("2", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("Марля", new Font(bf,10)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                cell.Phrase = new Phrase(new Chunk("20", new Font(bf)));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                _document.Add(emptyParagraph);
                _document.Add(para);
                _document.Add(emptyParagraph);
                _document.Add(new Chunk("Пацієнт : Олександр Петрович", new Font(bf)));
                _document.Add(table);
                _document.Add(emptyParagraph);
                _document.Add(chunk);
                _document.Close();
            }

            return name;
        }
    }
}
