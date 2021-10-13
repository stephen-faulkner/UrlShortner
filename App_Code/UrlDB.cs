using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net;

namespace UrlShortner.App_Code
{
    public class UrlDB
    {
        private static string ConnStr = SqlDB.ConnStr;

        public Guid Id { get; set; }
        public string UrlLong { get; set; }
        public string UrlShort { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Href { get { return $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}/r/{this.UrlShort}"; } }

        public UrlDB()
        {

        }

        public UrlDB(string _urlLong)
        {
            this.UrlLong = _urlLong;
            if (!this.CheckForLongUrl())
            {
                this.Id = Guid.NewGuid();
                this.UrlLong = _urlLong;
                this.CreateNewShortUrl();
                this.CreatedDate = DateTime.Now;

                this.SaveShortUrl();
            }
            
        }

        public void SaveShortUrl()
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnStr))
            {
                sqlCon.Open();
                using(SqlCommand sqlCmd = new SqlCommand("Url_SaveShortUrl", sqlCon))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@url_id", this.Id);
                    sqlCmd.Parameters.AddWithValue("@url_long", this.UrlLong);
                    sqlCmd.Parameters.AddWithValue("@url_short", this.UrlShort);
                    sqlCmd.Parameters.AddWithValue("@created_date", this.CreatedDate);

                    sqlCmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        
        public void CreateNewShortUrl()
        {
            this.UrlShort = Guid.NewGuid().ToString().Substring(0, 6);
        }

        public bool CheckForLongUrl()
        {
            bool urlExists = false;

            using (SqlConnection sqlCon = new SqlConnection(ConnStr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand("Url_CheckForLongUrl", sqlCon))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@url_long", this.UrlLong);

                    using (SqlDataReader read = sqlCmd.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            urlExists = true;

                            read.Read();
                            this.Id = new Guid(read["url_id"].ToString().Trim());
                            this.UrlLong = read["url_long"].ToString().Trim();
                            this.UrlShort = read["url_short"].ToString().Trim();
                            this.CreatedDate = Convert.ToDateTime(read["created_date"]);
                        }
                    }
                }
                sqlCon.Close();
            }

            return urlExists;
        }

        public void GetByShortUrl(string _shortUrl)
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnStr))
            {
                sqlCon.Open();
                using(SqlCommand sqlCmd = new SqlCommand("Url_GetByShortUrl", sqlCon))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@url_short", _shortUrl);

                    using(SqlDataReader read = sqlCmd.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            read.Read();
                            this.Id = new Guid(read["url_id"].ToString().Trim());
                            this.UrlLong = read["url_long"].ToString().Trim();
                            this.UrlShort = read["url_short"].ToString().Trim();
                            this.CreatedDate = Convert.ToDateTime(read["created_date"]);
                        }
                    }
                }
                sqlCon.Close();
            }
        }

        public static bool UrlExists(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(UriFormatException ex)
            {
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}