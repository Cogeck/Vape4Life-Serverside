using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VapeForLife.DataClasses;
using VapeForLife.DBContext;

namespace VapeForLife.HTML_Prebuilds
{
    /// <summary>
    /// Definiert die nachzuladenen Inhalte
    /// </summary>
    public class ContentFileManager
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
        public ContentFileManager(){}

        /// <summary>
        /// Konstruktor, setzt den HTML und JS auf string.Empty
        /// </summary>
        public ContentFileManager(string scriptMethodName)
        {
            using (var entities = new Vape4LifeEntities())
            {
                var serverScriptMethod = entities.ServerScriptMethods.AsNoTracking().FirstOrDefault(s => s.Name == scriptMethodName);
                if (serverScriptMethod == null)
                {
                    throw new Exception("Der ServerScriptMethod-Name wurde nicht in der DB gefunden!");
                }
                else
                {
                    entities.ReloadebleContentHTMLs.AsNoTracking().Where(r => r.IdfServerScriptMethod == serverScriptMethod.IdServerScriptMethod).ToList().ForEach(r => this.HTML.Add(r.FilePath));
                    entities.ReloadebleContentJS.AsNoTracking().Where(r => r.IdfServerScriptMethod == serverScriptMethod.IdServerScriptMethod).ToList().ForEach(r => this.HTML.Add(r.FilePath));
                    entities.ReloadebleContentCSSes.AsNoTracking().Where(r => r.IdfServerScriptMethod == serverScriptMethod.IdServerScriptMethod).ToList().ForEach(r => this.HTML.Add(r.FilePath));
                }
            }
        }        
    }
}