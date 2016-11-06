using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using VapeForLife.DBContext;
using System.Security.Cryptography;
using System.Text;

namespace VapeForLife.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class ServiceController : WebService
    {
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild CheckIfUserAlloewdAccess(string user)
        {
            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(user);

            HTML_Prebuilds.SmallHtmlPreBuild outPut;

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
                    else
                    {
                        user u = new user();
                        u.Name = "admin";
                        u.Lastname = "admin";
                        u.Nickname = "admin";
                        u.Password = sha256_hash("admin");
                        u.Email = "admin@admin.admin";
                        entities.users.Add(u);
                        entities.SaveChanges();
                        outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                        outPut.AlloewdToReload = false;
                    }
                }
            }
            else
            {
                outPut = new HTML_Prebuilds.SmallHtmlPreBuild();                
                outPut.AlloewdToReload = false;
            }
            return outPut;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild SignUp()
        {
            HTML_Prebuilds.SmallHtmlPreBuild outPut = new HTML_Prebuilds.SmallHtmlPreBuild("reloadcontent/usermanagement/signup.html", "reloadcontent/usermanagement/register.js");

            return outPut;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild Register(string nickname)
        {
            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(nickname);
            HTML_Prebuilds.SmallHtmlPreBuild outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
            
            //TODO: Prüfen ob der Benutzer valide Werte eingegeben hat. Dies kann auf mehreren Seiten geschehen.
            using (var entities = new Vape4LifeEntities())
            {
                var u = entities.users.Create<user>();
                u.Email = userObject.Email;
                u.Lastname = userObject.LastName ?? string.Empty;
                u.Name = userObject.Name ?? string.Empty;
                u.Nickname = userObject.NickName ?? string.Empty;
                u.Password = sha256_hash(userObject.Password);

                entities.users.Add(u);
                entities.SaveChanges();
                outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                outPut.HTML.Add("reloadcontent/usermanagement/signup.html");
            }

            return outPut;
        }
    }
}
