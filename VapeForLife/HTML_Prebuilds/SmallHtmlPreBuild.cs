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
        public List<string> HTML { get; set; } = new List<string>();

        /// <summary>
        /// JS das nachgeladen werden soll
        /// </summary>
        public List<string> JS { get; set; } = new List<string>();

        // <summary>
        /// CSS das nachgeladen werden soll
        /// </summary>
        public List<string> CSS { get; set; } = new List<string>();

        /// <summary>
        /// Steuert ob der Nutzer die Anfrage erhalten darf
        /// </summary>
        public bool AlloewdToReload { get; set; }

        /// <summary>
        /// Konstruktor, setzt den HTML und JS auf string.Empty
        /// </summary>
        public SmallHtmlPreBuild()
        {
        }

        /// <summary>
        /// Konstruktor mit Übergabeparameter HTML der nachgeladen werden soll
        /// </summary>
        /// <param name="html">Der HTML der nachgeladen werden soll</param>
        public SmallHtmlPreBuild(string html)
        {
            this.HTML.Add(html);
        }

        /// <summary>
        /// Konstruktor mit Übergabeparameter HTML und JS der nachgeladen werden soll
        /// </summary>
        /// <param name="html">Der HTML der nachgeladen werden soll</param>
        /// <param name="JS">Das JS das nachgeladen werden soll</param>
        public SmallHtmlPreBuild(string html, string JS)
        {
            this.HTML.Add(html);
            this.JS.Add(JS);
        }

        /// <summary>
        /// Konstruktor mit Übergabeparameter HTML JS und CSS der nachgeladen werden soll
        /// </summary>
        /// <param name="html">Der HTML der nachgeladen werden soll</param>
        /// <param name="JS">Das JS das nachgeladen werden soll</param>
        public SmallHtmlPreBuild(string html, string JS, string css)
        {
            this.HTML.Add(html);
            this.JS.Add(JS);
            this.CSS.Add(css);
        }
    }
}