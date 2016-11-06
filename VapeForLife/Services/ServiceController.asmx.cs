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
                    if (entities.user.Any())
                    {
                        var hash = sha256_hash(userObject.Password);
                        
                        if (entities.user.AsNoTracking().FirstOrDefault(e => e.Email.Equals(userObject.Email))?.Password?.Equals(hash) == true)
                        {
                            outPut = new HTML_Prebuilds.SmallHtmlPreBuild("reloadcontent/afterlogin/ReloadedAfterLogin.html");
                        }
                        else
                        {
                            outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                            outPut.HTML = "NOPE";
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
                        entities.user.Add(u);
                        entities.SaveChanges();
                        outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                        outPut.HTML = "NOPE";
                    }
                }
            }
            else
            {
                outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                outPut.HTML = "NOPE";

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



            HTML_Prebuilds.SmallHtmlPreBuild outPut = new HTML_Prebuilds.SmallHtmlPreBuild("reloadcontent/usermanagement/signup.html");

            return outPut;
        }
    }
}
