using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using VapeForLife.DataClasses;
using VapeForLife.DBContext;
using VapeForLife.HTML_Prebuilds;

namespace VapeForLife.Services.UserManagement
{
    public static class UserManagement
    {
        /// <summary>
        /// Erstellt aus dem parameter einen SHA256 Hash-Code //TODO: Weitere Features hinzufügen
        /// </summary>
        /// <param name="value">Der zu verschlüsselnde String</param>
        /// <returns>SHA256 String</returns>
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Prüft ob der User registriert ist und ob die Passwörter übereinstimmen
        /// </summary>
        /// <param name="user">Der zu prüfende JSON-String</param>
        /// <returns>Neuer Content der angezeigt werden darf</returns>
        public static SmallHtmlPreBuild CheckIfUserAlloewdAccess(string user)
        {
            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(user);

            SmallHtmlPreBuild outPut = null;

            if (!string.IsNullOrEmpty(userObject.Password))
            {

                using (var entities = new Vape4LifeEntities())
                {
                    if (entities.users.Any())
                    {
                        var hash = sha256_hash(userObject.Password);

                        if (entities.users.AsNoTracking().FirstOrDefault(e => e.Email.Equals(userObject.Email))?.Password?.Equals(hash) == true)
                        {
                            outPut =
                              new HTML_Prebuilds.SmallHtmlPreBuild("reloadcontent/afterlogin/ReloadedAfterLogin.html",
                              "reloadcontent/afterlogin/ReloadedAfterLogin.js",
                              "reloadcontent/afterlogin/ReloadedAfterLogin.css");

                            outPut.AlloewdToReload = true;
                        }
                        else
                        {
                            outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                            outPut.AlloewdToReload = false;
                        }
                    }
                    /*
                     * TODO: Dies ist der erste Benutzer (Adminuser beim Starten den Anwendung)
                     * Dieser muss entsprechend umgebaut werden
                    */
                    //else
                    //{
                    //    user u = new user();
                    //    u.Name = "admin";
                    //    u.Lastname = "admin";
                    //    u.Nickname = "admin";
                    //    u.Password = sha256_hash("admin");
                    //    u.Email = "admin@admin.admin";
                    //    entities.users.Add(u);
                    //    entities.SaveChanges();
                    //    outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                    //    outPut.HTML = "NOPE";
                    //}
                }
            }
            else
            {
                outPut = new SmallHtmlPreBuild();
                outPut.AlloewdToReload = false;
            }

            return outPut;
        }

        public static SmallHtmlPreBuild Validate(string user)
        {
            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(user);
            SmallHtmlPreBuild outPut = new SmallHtmlPreBuild();



            return outPut;
        }

        /// <summary>
        /// Registrieren eines Benutzers
        /// </summary>
        /// <param name="user">Der zu prüfende JSON-String</param>
        /// <returns>Neuer Content der angezeigt werden darf</returns>
        public static SmallHtmlPreBuild Register(string nickname)
        {
            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(nickname);
            SmallHtmlPreBuild outPut = new SmallHtmlPreBuild();

            //TODO: Prüfen ob der Benutzer valide Werte eingegeben hat. Dies muss auf mehreren Seiten geschehen.
            //TODO: Prüfen im Content ob Valide eingaben getätigt wurden
            //TODO: Prüfen im Code ob die Eingaben Valide sind
            using (var entities = new Vape4LifeEntities())
            {

                if (entities.users.Any(e => e.Email.ToLower().Equals(userObject.Email.ToLower()) || e.Nickname.ToLower().Equals(userObject.NickName.ToLower())))
                {
                    //TODO: Meldung anzeigen, dass email oder Benutzer schon existieren.
                }
                else
                {
                    var u = entities.users.Create<user>();
                    u.Email = userObject.Email;
                    u.Lastname = userObject.LastName ?? string.Empty;
                    u.Name = userObject.Name ?? string.Empty;
                    u.Nickname = userObject.NickName ?? string.Empty;
                    u.Password = sha256_hash(userObject.Password);

                    entities.users.Add(u);
                    entities.SaveChanges();
                    outPut = new SmallHtmlPreBuild();
                    outPut.HTML.Add("reloadcontent/usermanagement/loginafterregistration.html");
                    outPut.JS.Add("js/usermanagement/loginafterregistration.js");
                    SendMail(userObject);
                }
            }

            return outPut;
        }

        private static void SendMail(User userObject)
        {
            MailAddress from = new MailAddress("registration@flavours-world.com");
            MailAddress to = new MailAddress(userObject.Email);
            MailMessage email = new MailMessage(from, to);

            email.Subject = "Registrierung";
            email.Body = "RegistrationKey: " + sha256_hash(userObject.Email).Substring(0, 6)[0];

            SmtpClient client = new SmtpClient("smtp.cyberkeks.net", 465);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("m03b93eb", "QJVgoaHS9ErBkLrq");
            try
            {
                //TODO: Senden einer eMail schlägt fehl -> Prüfen!!!
                //client.Send(email);
            }
            catch (Exception ex)
            {

            }
        }
    }
}