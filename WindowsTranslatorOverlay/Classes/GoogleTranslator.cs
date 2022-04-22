using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WindowsTranslatorOverlay.Classes
{
    public static class GoogleTranslator
    {
        public static LangCode InputCode(string value)
        {
            return (LangCode)Enum.Parse(typeof(LangCode), value);
        }
        public static LangCode OutputCode(string value)
        {
            return (LangCode)Enum.Parse(typeof(LangCode), value);
        }

        public static string[] LangTitle_PTBR =
        {
            "Africâner","Albanês","Alemão","Amárico","Árabe","Armênio","Azerbaijano","Basco","Bengali","Bielo-russo","Birmanês","Bósnio","Búlgaro","Canarês",
            "Catalão","Cazaque", "Cebuano","Chicheua","Chinês","Chona","Cingalês","Coreano","Corso","Crioulo haitiano","Croata","Curdo",
            "Dinamarquês","Eslovaco","Esloveno","Espanhol","Esperanto","Estoniano","Filipino","Finlandês","Francês","Frísio","Gaélico escocês",
            "Galego","Galês","Georgiano","Grego","Guzerate","Hauçá","Havaiano","Hebraico","Hindi","Hmong","Holandês","Húngaro","Igbo","Iídiche",
            "Indonésio","Inglês","Ioruba","Irlandês","Islandês","Italiano","Japonês","Javanês","Khmer","Kinyarwanda","Laosiano","Latim","Letão",
            "Lituano","Luxemburguês","Macedônio","Malaiala","Malaio","Malgaxe","Maltês","Maori","Marata","Mongol","Nepalês","Norueguês",
            "Oriá","Pachto","Persa","Polonês","Português","Punjabi","Quirguiz","Romeno","Russo","Samoano","Sérvio","Sessoto","Sindi","Somali","Suaíle","Sueco",
            "Sundanês","Tadjique","Tailandês","Tâmil","Tártaro","Tcheco","Telugo","Turco","Turcomano","Ucraniano","Uigur","Urdu","Uzbeque","Vietnamita","Xhosa","Zulu"
                ,
        };

        public static List<KeyValuePair<string, string>> ValueName()
        {
            List<string> Key = new List<string>() { };
            List<string> Value = new List<string>() { };

            List<KeyValuePair<string, string>> KeyValueLang = new List<KeyValuePair<string, string>>() { };


            foreach (string langTitle in LangTitle_PTBR)
                Key.Add(langTitle);
            foreach (string langCode in Enum.GetNames(typeof(LangCode)))
                if(langCode != "auto")
                    Value.Add(langCode);

            for (int i = 0; i < Value.Count; i++)
                KeyValueLang.Add(new KeyValuePair<string, string>(Key[i], Value[i]));

            return KeyValueLang;
        }
        public enum LangCode
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

        public static string[] GetLangCode(LangCode langCode)
        {
            return Enum.GetNames(langCode.GetType());
        }

        public static LangCode DefaultInput = LangCode.auto;
        public static LangCode DefaultOutput = LangCode.en;

        public static string Translate(string query, LangCode LangEntrada, LangCode LangSaida)
        {
            if (LangEntrada == LangCode.auto && LangSaida == LangCode.auto)
                throw new Exception("Linguagem de Entrada e saída não podem ser automatico");
            else if (LangSaida == LangCode.auto)
                throw new Exception("Linguagem de Saída não pode ser automatica.");

            string url;
            if (LangEntrada  == LangCode.zhCN)
                url = $"https://translate.google.com/m?sl=zh-CN&tl={LangSaida}&q={query}";
            else if(LangSaida == LangCode.zhCN)
                url = $"https://translate.google.com/m?sl={LangEntrada}&tl=zh-CN&q={query}";
            else
                url = $"https://translate.google.com/m?sl={LangEntrada}&tl={LangSaida}&q={query}";

            HtmlWeb doc = new HtmlWeb();

            string docNode = doc.LoadFromBrowser(url).DocumentNode.SelectSingleNode("/html/body/div[1]/div[4]").InnerHtml;
            string value = docNode.Replace("&#32", " ")
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
