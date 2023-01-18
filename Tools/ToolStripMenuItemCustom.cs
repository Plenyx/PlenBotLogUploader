using System.Windows.Forms;

namespace PlenBotLogUploader.Tools
{
    internal sealed class ToolStripMenuItemCustom<T> : ToolStripMenuItem
    {
        internal T LinkedObject { get; set; }
    }
}
