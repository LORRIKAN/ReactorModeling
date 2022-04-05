using CustomFormsElements;
using Model;
using System.Collections.Generic;

namespace Researcher.Export
{
    public record struct ExportMessage(string Title, IEnumerable<Parameter> Inputs, IEnumerable<Parameter> Outputs,
            IEnumerable<Plot> Plots, IEnumerable<TableExportMessage> Tables, string FilePath);
}
