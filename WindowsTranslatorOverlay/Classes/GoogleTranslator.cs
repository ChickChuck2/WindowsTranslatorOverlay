using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace WindowsTranslatorOverlay.Classes
{
    internal class GoogleTranslator
    {
        public string[] LangTitle_PTBR =
        {
            "Africâner","Albanês","Alemão","Amárico","Árabe","Armênio","Azerbaijano","Basco","Bengali","Bielo-russo","Birmanês","Bósnio","Búlgaro","Canarês",
            "Catalão","Cazaque", "Cebuano","Chicheua","Chinês","Chona","Cingalês","Coreano","Corso","Crioulo haitiano","Croata","Curdo",
            "Dinamarquês","Eslovaco","Esloveno","Espanhol","Esperanto","Estoniano","Filipino","Finlandês","Francês","Frísio","Gaélico escocês",
            "Galego","Galês","Georgiano","Grego","Guzerate","Hauçá","Havaiano","Hebraico","Hindi","Hmong","Holandês","Húngaro","Igbo","Iídiche",
            "Indonésio","Inglês","Ioruba","Irlandês","Islandês","Italiano","Japonês","Javanês","Khmer","Kinyarwanda","Laosiano","Latim","Letão",
            "Lituano","Luxemburguês","Macedônio","Malaiala","Malaio","Malgaxe","Maltês","Maori","Marata","Mongol","Nepalês","Norueguês",
            "Oriá","Pachto","Persa","Polonês","Português","Punjabi","Quirguiz","Romeno","Russo","Samoano","Sérvio","Sessoto","Sindi","Somali","Suaíle","Sueco",
            "Sundanês","Tadjique","Tailandês","Tâmil","Tártaro","Tcheco","Telugo","Turco","Turcomano","Ucraniano","Uigur","Urdu","Uzbeque","Vietnamita","Xhosa","Zulu",
        };

        public List<KeyValuePair<string, string>> ValueName()
        {
            List<string> Key = new List<string>() { };
            List<string> Value = new List<string>() { };

            List<KeyValuePair<string, string>> KeyValueLang = new List<KeyValuePair<string, string>>() { };


            foreach (string langTitle in LangTitle_PTBR)
                Key.Add(langTitle);
            foreach (string langCode in Enum.GetNames(typeof(LANG)))
                if(langCode != "auto")
                    Value.Add(langCode);

            for (int i = 0; i < Value.Count; i++)
                KeyValueLang.Add(new KeyValuePair<string, string>(Key[i], Value[i]));

            return KeyValueLang;
        }
        public enum LANG
        {
            auto,af,sq,de,am,ar,hy,az,eu,bn,be,my,bs,
            bg,kn,ca,kk,ceb,ny,zhCN,sn,si,ko,co,ht,hr,
            ku,da,sk,sl,es,eo,et,tl,fi,fr,fy,gd,gl,cy,
            ka,el,gu,ha,haw,iw,hi,hmn,nl,hu,ig,yi,id,en,
            yo,ga,IS,it,ja,jw,km,rw,lo,la,lv,lt,lb,mk,ml,
            ms,mg,mt,mi,mr,mn,ne,no,or,ps,fa,pl,pt,pa,ky,
            ro,ru,sm,sr,st,sd,so,sw,sv,su,tg,th,ta,tt,cs,
            te,tr,tk,uk,ug,ur,uz,vi,xh,zu,

        }
        public static string Translate(string query, LANG LangEntrada = LANG.auto, LANG LangSaida = LANG.en)
        {
            if (LangEntrada == LANG.auto && LangSaida == LANG.auto)
                throw new Exception("Linguagem de Entrada e saída não podem ser automatico");
            else if (LangSaida == LANG.auto)
                throw new Exception("Linguagem de Saída não pode ser automatica.");

            string url = "";

            if (LangEntrada  == LANG.zhCN)
                url = $"https://translate.google.com/m?sl=zh-CN&tl={LangSaida}&q={query}";
            else if(LangSaida == LANG.zhCN)
                url = $"https://translate.google.com/m?sl={LangEntrada}&tl=zh-CN&q={query}";
            else
                url = $"https://translate.google.com/m?sl={LangEntrada}&tl={LangSaida}&q={query}";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);
            var docNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[4]").InnerHtml;
            var value = docNode.Replace("&#32", " ")
                .Replace("&#33", "!")
                .Replace("&#34", "“")
                .Replace("&#35", "#")
                .Replace("&#37", "%")
                .Replace("&#44", ",")
                .Replace("&#45", "-")
                .Replace("&#46", ".")
                .Replace("&#47", "/")
                .Replace("&#39;", "'")
                .Replace("&#39;;", "'");
            return value;
        }
    }
}
