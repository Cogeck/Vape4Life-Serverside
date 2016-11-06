using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapeForLife.HTML_Prebuilds
{
    /// <summary>
    /// Definiert die nachzuladenen Inhalte
    /// </summary>
    public class SmallHtmlPreBuild
    {
        /// <summary>
        /// HTML-Content der nachgeladen werden soll
        /// </summary>
        public string HTML { get; set; }

        /// <summary>
        /// JS das nachgeladen werden soll
        /// </summary>
        public string JS { get; set; }


        /// <summary>
        /// Konstruktor, setzt den HTML und JS auf string.Empty
        /// </summary>
        public SmallHtmlPreBuild()
        {
            this.HTML = string.Empty;
            this.JS = string.Empty;
        }

        /// <summary>
        /// Konstruktor mit Übergabeparameter HTML der nachgeladen werden soll
        /// </summary>
        /// <param name="html">Der HTML der nachgeladen werden soll</param>
        public SmallHtmlPreBuild(string html)
        {
            this.HTML = html;
        }

        /// <summary>
        /// Konstruktor mit Übergabeparameter HTML und JS der nachgeladen werden soll
        /// </summary>
        /// <param name="html">Der HTML der nachgeladen werden soll</param>
        /// <param name="JS">Das JS das nachgeladen werden soll</param>
        public SmallHtmlPreBuild(string html, string JS)
        {
            this.HTML = html;
            this.JS = JS;
        }
    }
}