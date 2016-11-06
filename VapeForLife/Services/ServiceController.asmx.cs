using System.Web.Services;
using System.Web.Script.Services;

namespace VapeForLife.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class ServiceController : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild CheckIfUserAlloewdAccess(string user)
        {
            return UserManagement.UserManagement.CheckIfUserAlloewdAccess(user);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild SignUp()
        {
            HTML_Prebuilds.SmallHtmlPreBuild outPut = new HTML_Prebuilds.SmallHtmlPreBuild("reloadcontent/usermanagement/signup.html", "reloadcontent/usermanagement/register.js");
            outPut.AlloewdToReload = true;
            return outPut;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild Register(string nickname)
        {
            return UserManagement.UserManagement.Register(nickname);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.SmallHtmlPreBuild Validate(string user)
        {
            return UserManagement.UserManagement.Validate(user);
        }
    }
}
