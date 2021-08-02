using CommandLine;
using iText.Kernel.Pdf;
using System.IO;

namespace PDFOwnerSecurityRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(opts => Execute(opts));
        }

        private static void Execute(CommandLineOptions opts)
        {
            foreach (string file in opts.InputFiles)
            {
                if (File.Exists(file))
                {
                    string fileName = Path.Combine(Path.GetDirectoryName(file), "unprotected_" + Path.GetFileName(file));

                    using PdfReader pdfReader = new PdfReader(file);
                    pdfReader.SetUnethicalReading(true);
                    using PdfDocument protectedPdfDocument = new PdfDocument(pdfReader);

                    using PdfWriter pdfWriter = new PdfWriter(fileName);
                    using PdfDocument unprotectedPdfDocument = new PdfDocument(pdfWriter);

                    protectedPdfDocument.CopyPagesTo(1, protectedPdfDocument.GetNumberOfPages(), unprotectedPdfDocument);

                    protectedPdfDocument.Close();
                    unprotectedPdfDocument.Close();
                }
            }
        }
    }
}
