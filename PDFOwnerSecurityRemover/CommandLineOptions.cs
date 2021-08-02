using CommandLine;
using System.Collections.Generic;

namespace PDFOwnerSecurityRemover
{
    public sealed class CommandLineOptions
    {
        [Option('f', "file", Required = true, HelpText = "PDF file(s) to remove owner permissions", Separator = ' ')]
        public IEnumerable<string> InputFiles { get; set; }
    }
}
