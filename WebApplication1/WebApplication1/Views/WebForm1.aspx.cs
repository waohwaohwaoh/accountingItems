using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebApplication1.Models;
using WebApplication1.DTO;
using WebApplication1.DAL;

namespace WebApplication1.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<User> temp = new User().GetAll();
            GridView1.DataSource = temp;
            GridView1.DataBind();
        }
    }
}