using System.ComponentModel;
using System.Windows.Forms;

namespace PlenBotLogUploader.Tools;

internal sealed class ToolStripMenuItemCustom<T> : ToolStripMenuItem
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal T LinkedObject { get; set; }
}
