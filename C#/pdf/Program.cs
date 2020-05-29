using System.IO;
using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfReader reader = new PdfReader(Directory.GetCurrentDirectory() + "\\1.pdf");

            var parser = new PdfReaderContentParser(reader);
            ITextExtractionStrategy strategy;
            strategy= parser.ProcessContent<SimpleTextExtractionStrategy>(1,new SimpleTextExtractionStrategy());
            var data=strategy.GetResultantText();
        }
    }
}
