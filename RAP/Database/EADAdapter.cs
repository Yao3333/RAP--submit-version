using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using RAP.Research;
using System.Windows;

namespace RAP
{
    class EADAdapter
    {
        //链接用的 
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;
        private static bool reportingErrors;

        //通过字符串获取枚举值的方法
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        /// /// /// /// /// /// /// /// 

        /// /// /// /// /// /// /// /// 


        //researcher信息功能 函数 用到的
        //1. 
        public static List<Researcher> fetchBasicResearcherDetails()
        {
            List<Researcher> ResearcherList = new List<Researcher>();

            //连接mysql
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                //打开数据库连接
                conn.Open();

                //创建命令对象
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title from researcher", conn);

                //执行命令,ExcuteReader返回的是DataReader对象
                rdr = cmd.ExecuteReader();

                // //循环单行读取数据，当读取为null时，就退出循环. 从数据库里读出以后，往我们声明的researcher变量里存
                while (rdr.Read())
                {

                    ResearcherList.Add(new Researcher
                    {
                        ID = rdr.GetInt32(0),
                        FamilyName = rdr.GetString(1),
                        GivenName = rdr.GetString(2),
                        Title = rdr.GetString(4)
                    });
                }
            }
            //容错报错
            catch (MySqlException e)
            {
                ReportError("feching researcher Basic details", e);
            }

            //关闭数据库
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return ResearcherList;

        }

        //2. 
        public static Researcher fetchFullResearcherDetails(int id)
        {
            List<Position> Positions = new List<Position>();
            Researcher r = new Researcher();

            //连接mysql
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                //打开数据库连接
                conn.Open();

                //创建命令对象
                MySqlCommand cmd = new MySqlCommand("select * from researcher where id=" + id, conn);
                //执行命令,ExcuteReader返回的是DataReader对象
                rdr = cmd.ExecuteReader();

                // //循环单行读取数据，当读取为null时，就退出循环. 从数据库里读出以后，往我们声明的researcher变量里存
                while (rdr.Read())
                {
                    r.ID = rdr.GetInt32(0);
                    r.researcherType = ParseEnum<ResearcherType>(rdr.GetString(1));
                    r.GivenName = rdr.GetString(2);
                    r.FamilyName = rdr.GetString(3);

                    r.Campus = ParseEnum<Campus>(rdr.GetString(6));
                    r.Email = rdr.GetString(7);
                    r.Photo = rdr.GetString(8);
                }
            }
            //容错报错
            catch (MySqlException e)
            {
                ReportError("feching researcher Basic details", e);
            }

            //关闭数据库
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return r;
        }

        //3.
        public static Researcher completeResearcherDetails(Researcher r)
        {
        }


        //4. 
        public static List<Publication> fetchBasicPublicationDetails(Researcher r)
        {
            List<Publication> publications = new List<Publication>();
            //连接mysql
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                //打开数据库连接
                conn.Open();

                //创建命令对象
                MySqlCommand cmd = new MySqlCommand("select doi, title, authors, year, type,cite_as, available from publication", conn);

                //执行命令,ExcuteReader返回的是DataReader对象
                rdr = cmd.ExecuteReader();

                // //循环单行读取数据，当读取为null时，就退出循环. 从数据库里读出以后，往我们声明的publication变量里存
                while (rdr.Read())
                {

                    publications.Add(new Publication
                    {
                        Doi = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Authors = rdr.GetString(2),
                        PublicationYear = rdr.GetDateTime(3).Year,
                        Type = ParseEnum<OutputType>(rdr.GetString(4)),
                        CiteAs = rdr.GetString(5),
                        AvailableDate = rdr.GetDateTime(6),

                    });
                }
            }
            //容错报错
            catch (MySqlException e)
            {
                ReportError("feching researcher Basic details", e);
            }

            //关闭数据库
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return publications;
        }

        //5.
        public static Publication completePublicationDetails(Publication p)
        {

            
            //连接mysql
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                //打开数据库连接
                conn.Open();

                //创建命令对象
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title from researcher", conn);

                //执行命令,ExcuteReader返回的是DataReader对象
                rdr = cmd.ExecuteReader();

                // //循环单行读取数据，当读取为null时，就退出循环. 从数据库里读出以后，往我们声明的researcher变量里存
                while (rdr.Read())
                {
                    p.Doi = rdr.GetString(0);
                    p.Type = ParseEnum<OutputType>(rdr.GetString(4));
                    p.CiteAs = rdr.GetString(5);
                    p.AvailableDate = rdr.GetDateTime(6);
                    p.Age();

                }
            }
            //容错报错
            catch (MySqlException e)
            {
                ReportError("feching researcher Basic details", e);
            }

            //关闭数据库
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return p;
        }

        //6. 
        public static List<int> fetchPublicationCounts(DateTime firstPub, DateTime latestPub)
        {
            List<int> yearCount = new List<int>();
            Researcher r = new Researcher();


            return yearCount;
        }

        //这里是 生成 报错 的方法
        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}