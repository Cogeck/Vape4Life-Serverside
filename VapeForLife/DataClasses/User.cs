using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapeForLife.DataClasses
{
    /// <summary>
    /// Die Userdefinition
    /// </summary>
    public class User
    {
        /// <summary>
        /// Die Id des Users (Datenbankgeneriert)
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Die Email des Benutzers
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Der NickName des Benutzers
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Das Passwort des Benutzers
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Der Vorname des Benutzers
        /// </summary>
        /// 
        public string Name { get; set; }
        /// <summary>
        /// Der Nachname des Benutzers
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Hat der Benutzer sich erfolgreich mit seiner Email authenzifiziert
        /// </summary>
        public int UserLevel { get; set; }

        /// <summary>
        /// Der ValidationKey den der Benutzer eingeben muss
        /// </summary>
        public string ValidationKey { get; set; }
    }
}