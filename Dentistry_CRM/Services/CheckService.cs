using System;
using System.Collections.Generic;
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
        }

        public async Task<string> GenerateCheck(DateTime time,string Name,List<Service> services)
        {
            var name = Name + ".pdf";
            using (var writer = PdfWriter.GetInstance(_document,
                new FileStream(name, FileMode.OpenOrCreate)))
            {
                _document.Open();

                var bf = BaseFont.CreateFont(@"C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var emptyParagraph = new Paragraph(" ");

                var paragraph = new Paragraph("Стоматологія", new Font(bf));
                paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

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

                int counter = 1;

                foreach (var ser in services)
                {
                    cell.Phrase = new Phrase(new Chunk(counter.ToString(), new Font(bf)));
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                    cell.Phrase = new Phrase(new Chunk(ser.Name, new Font(bf, 10)));
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                    cell.Phrase = new Phrase(new Chunk(ser.Price.ToString(), new Font(bf)));
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                    counter++;
                }

                _document.Add(emptyParagraph);
                _document.Add(paragraph);
                _document.Add(emptyParagraph);
                _document.Add(new Chunk($"Пацієнт : {Name}", new Font(bf)));
                _document.Add(table);
                _document.Add(emptyParagraph);
                _document.Add(chunk);
                _document.Close();
            }

            return name;
        }
    }
}
