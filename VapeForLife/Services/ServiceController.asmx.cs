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
        public HTML_Prebuilds.ContentFileManager CheckIfUserAlloewdAccess(string user)
        {
            return UserManagement.UserManagement.CheckIfUserAlloewdAccess(user);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.ContentFileManager SignUp()
        {
            HTML_Prebuilds.ContentFileManager outPut = new HTML_Prebuilds.ContentFileManager("SignUp");
            return outPut;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.ContentFileManager Register(string nickname)
        {
            return UserManagement.UserManagement.Register(nickname);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HTML_Prebuilds.ContentFileManager Validate(string user)
        {
            return UserManagement.UserManagement.Validate(user);
        }
    }
}
