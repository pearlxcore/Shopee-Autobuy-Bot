using System.Drawing;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot.Services.Logger
{
    public interface IAutoBuyLoggerService
    {
        public void AutoBuyProcessLog(string text, Color? color = null, bool NewLine = true, bool Production = true, bool WithDateTime = true);
        public void ProgramLog();
        public void SaveAutoBuyProcessLogToLogFile(RichTextBox richTextBox);
    }
}
