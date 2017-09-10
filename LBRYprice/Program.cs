using System.Windows.Forms;
using HtmlAgilityPack;
using System.Threading;
namespace LBRYprice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                string Url = "https://coinmarketcap.com/currencies/library-credit/";
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(Url);

                string price = doc.DocumentNode.SelectNodes("//*[@id=\"quote_price\"]")[0].InnerText;

                NotifyIcon ico = new NotifyIcon()
                {
                    BalloonTipIcon = ToolTipIcon.Info,
                    BalloonTipTitle = "LBRY coin price",
                    BalloonTipText = price,
                    Text = null,
                    Icon = System.Drawing.SystemIcons.Question,
                    Visible = true,
                };
                ico.ShowBalloonTip(3000);
                ico.Visible = false;
                ico.Dispose();
                Thread.Sleep(200000);
            }
        }
    }
}