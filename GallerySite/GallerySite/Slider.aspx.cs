using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GallerySite
{
    public partial class Slider : System.Web.UI.Page
    {
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Image1.ImageUrl = "~/images/Рисунок1.png";
        }

        /*protected void Button1_Click(object sender, EventArgs e)
        {
            i++;
            Image1.ImageUrl = "~/images/Рисунок" + i + ".png";
            Label1.Text = "Картинка должна быть " + i.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            i--;
            Image1.ImageUrl = "~/images/Рисунок" + i + ".png";
            Label1.Text = "Картинка должна быть " + i.ToString();
        }*/
    }
}