using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;

namespace BotDetectionApplication
{





    public class BotDetector
    {


        private List<string> _bots;
        public List<string> bots
        {
            get
            {
                if (_bots == null)
                {
                    _bots = new List<string>(){"008","ABACHOBot","Accoona-AI-Agent","AddSugarSpiderBot","AnyApexBot","Arachmo","B-l-i-t-z-B-O-T","Baiduspider","BecomeBot",
        "BeslistBot","BillyBobBot","Bimbot","Bingbot","BlitzBOT","boitho.com-dc","boitho.com-robot","btbot","CatchBot","Cerberian Drtrs",
        "Charlotte","ConveraCrawler","cosmos","Covario IDS","DataparkSearch","DiamondBot","Discobot","Dotbot","EARTHCOM.info","EmeraldShield.com WebBot",
        "envolk[ITS]spider","EsperanzaBot","Exabot","FAST Enterprise Crawler","FAST-WebCrawler","FDSE robot","FindLinks","FurlBot","FyberSpider",
        "g2crawler","Gaisbot","GalaxyBot","genieBot","Gigabot","Girafabot","Googlebot-Image","Googlebot","GurujiBot","HappyFunBot","hl_ftien_spider",
        "Holmes","htdig","iaskspider","ia_archiver","iCCrawler","ichiro","igdeSpyder","IRLbot","IssueCrawler","Jaxified Bot","Jyxobot","KoepaBot",
        "L.webis","LapozzBot","Larbin","LDSpider","LexxeBot","Linguee Bot","LinkWalker","lmspider","lwp-trivial","mabontland","magpie-crawler",
        "Mediapartners-Google","MJ12bot","MLBot","Mnogosearch","mogimogi","MojeekBot","Moreoverbot","Morning Paper","msnbot","MSRBot","MVAClient",
        "mxbot","NetResearchServer","NetSeer Crawler","NewsGator","NG-Search","nicebot","noxtrumbot","Nusearch Spider","NutchCVS","Nymesis","obot",
        "oegp","omgilibot","OmniExplorer_Bot","OOZBOT","Orbiter","PageBitesHyperBot","Peew","polybot","Pompos","PostPost","Psbot","PycURL","Qseero",
        "Radian6","RAMPyBot","RufusBot","SandCrawler","SBIder","ScoutJet","Scrubby","SearchSight","Seekbot","semanticdiscovery","Sensis Web Crawler",
        "SEOChat::Bot","SeznamBot","Shim-Crawler","ShopWiki","Shoula robot","silk","Sitebot","Snappy","sogou spider","Sosospider","Speedy Spider",
        "Sqworm","StackRambler","suggybot","SurveyBot","SynooBot","Teoma","TerrawizBot","TheSuBot","Thumbnail.CZ robot","TinEye","truwoGPS","TurnitinBot",
        "TweetedTimes Bot","TwengaBot","updated","Urlfilebot","Vagabondo","VoilaBot","Vortex","voyager","VYU2","webcollage","Websquash.com","wf84",
        "WoFindeIch Robot","WomlpeFactory","Xaldon_WebSpider","yacy","Yahoo! Slurp","Yahoo! Slurp China","YahooSeeker","YahooSeeker-Testing","YandexBot",
        "YandexImages","YandexMetrika","Yasaklibot","Yeti","YodaoBot","yoogliFetchAgent","YoudaoBot","Zao","Zealbot","zspider","ZyBorg", "teoma" ,"bot", "spieder", "crawler", "walker"};
                }

                return _bots;
            }

        }





        private List<string> _botsSearchEngine;
        public List<string> botsSearchEngine
        {
            get
            {
                if (_botsSearchEngine == null)
                {
                    _botsSearchEngine = new List<string>() { "googlebot", "yahoo", "ask", "bing", "msn", "teoma" };
                }

                return _botsSearchEngine;
            }

        }




        public BotDetector(string useragent)
        {
            SearchBots(useragent);
        }


        private void SearchBots(string useragent)
        {
            bool bot = false;
            bool searchengine = false;
            DateTime time = DateTime.Now;

            foreach (string b in bots)
            {
                if (useragent.Contains(b))
                {
                    bot = true;
                    time = DateTime.Now;
                }


            }

            foreach (string b in botsSearchEngine)
            {
                if (useragent.Contains(b))
                {
                    searchengine = true;
                    time = DateTime.Now;
                }
            }


            if (bot | searchengine)
            {
               string url = HttpContext.Current.Request.Url.AbsoluteUri;


                if (bot)
                {
                    string subject = "Malicious Engine bot";
                    StringBuilder message = new StringBuilder();
                    message.AppendLine("Site: " + url);
                    message.AppendLine("Time: " + time.ToLongTimeString());
                    message.AppendLine("Bot Type: " + "Malicious Engine bot");
                    message.AppendLine("User Agent: " + useragent);
                    Notification.SendEmailNetwork(subject, message.ToString());
                }

                if (searchengine)
                {
                    string subject = "Search Engine bot";
                    StringBuilder message = new StringBuilder();
                    message.AppendLine("Site: " + url);
                    message.AppendLine("Time: " + time.ToLongTimeString());
                    message.AppendLine("Bot Type: " + "Search Engine bot");
                    message.AppendLine("User Agent: " + useragent);
                    Notification.SendEmailNetwork(subject, message.ToString());
                }

            }


        }


    }
}
