using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapeForLife.HTML_Prebuilds
{
    //Masterklasse definieren!!!
    public class SmallHtmlPreBuild
    {
        public string HTML { get; set; }
        public string JS { get; set; }

        public SmallHtmlPreBuild()
        {
            this.HTML = "ReloadContent/AfterLogin/ReloadedAfterLogin.html";
            this.JS = "ReloadContent/AfterLogin/ReloadedAfterLogin.js";
        }
    }
}