using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrlShortner.App_Code;

namespace UrlShortner
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateShortUrl_Click(object sender, EventArgs e)
        {
            string longUrl = txtFullUrl.Text;
            if (string.IsNullOrWhiteSpace(txtFullUrl.Text))
            {
                SetErrorMessage("Enter url before generating shortened version");
            }
            else if (!UrlDB.UrlExists(longUrl))
            {
                SetErrorMessage("Url could not be confirmed");
            }
            else
            {

                UrlDB shortUrl = new UrlDB(longUrl);
                aUrl.HRef = shortUrl.Href;
                ltlHref.Text = shortUrl.Href;
                pnlShortUrl.Visible = true;

                ClearErrorMessage();
            }
                
        }

        private void SetErrorMessage(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.CssClass = "error-msg";

            aUrl.HRef = null;
            ltlHref.Text = null;
            pnlShortUrl.Visible = false;
        }

        private void ClearErrorMessage()
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
        }
    }
}