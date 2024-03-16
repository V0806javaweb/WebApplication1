using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GuestbookService
    {
        //SQL連接字串(移至Web.Config集中管理)
        /*private readonly string cnstr = @"Persist Security Info = False;Integrated Security = True;
            Server = localhost;Initial Catalog = exampleDB;";*/
        private readonly string cnstr = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
        public List<Guestbooks> GetDataList()
        {
            List<Guestbooks> DataList = new List<Guestbooks>();
            string sql = @"Select * from Guestbooks";
            SqlConnection conn = new SqlConnection(cnstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Guestbooks Data = new Guestbooks();
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Name = dr["Name"].ToString();
                Data.Content = dr["Content"].ToString();
                DataList.Add(Data);
            }
            conn.Close();
            return DataList;
        }
    }
}