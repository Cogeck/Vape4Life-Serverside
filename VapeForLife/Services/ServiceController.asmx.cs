using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

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
        public HTML_Prebuilds.SmallHtmlPreBuild CheckIfUserAlloewdAccess(string user){

            var serializer = new JavaScriptSerializer(); //stop point set here
            DataClasses.User userObject = serializer.Deserialize<DataClasses.User>(user);

            HTML_Prebuilds.SmallHtmlPreBuild outPut;

            //ToDo DBZugriff
            if (userObject.Email == "TEST" && userObject.Password == "TEST")
            {
                outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
            }
            else
            {
                outPut = new HTML_Prebuilds.SmallHtmlPreBuild();
                //ToDo Besserenfall überlegen
                outPut.HTML = "NOPE";
            }
            
            return outPut;
        }        
    }
}
