using System.Windows.Forms;

namespace Researcher.Export
{
    public record struct TableExportMessage(string Name, string VLabel, string HLabel, int VMult, int HMult,
        DataGridView Data);
}
