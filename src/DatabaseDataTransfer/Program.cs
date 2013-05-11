using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace DatabaseDataTransfer
{
    class Program
    {
        static void Transfer(string src, string target, string[] src_fields, string[] target_fields)
        {
            string conn_schema = "Data Source = {0}";
            string sqlite = string.Format(conn_schema, "E:/code/vcms1/src/vuuvv.web/App_Data/test.db");
            string sqlce = string.Format(conn_schema, "E:/code/vcms1/src/vuuvv.web/App_Data/vuuvv.sdf");

            using (SQLiteConnection conn = new SQLiteConnection(sqlite))
            {
                conn.Open();
                string sql = string.Format("select {0} from {1}", string.Join(",", src_fields), src);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        using (SqlCeConnection conn1 = new SqlCeConnection(sqlce))
                        {
                            conn1.Open();
                            int count = 0;
                            while (reader.Read())
                            {
                                Dictionary<string, object> rec = new Dictionary<string, object>();
                                for (int i = 0; i < target_fields.Length; i++)
                                {
                                    rec.Add(target_fields[i], CorrectType(target_fields[i], reader.GetValue(i)));
                                }
                                InsertRecorder(target, rec, conn1);
                                Console.WriteLine(++count);
                            }
                        }
                    }
                }
            }
        }

        static object CorrectType(string field, object value)
        {
            if (value.GetType() == typeof(Int64))
            {
                int id =  Convert.ToInt32(value);

                /* for Correct HonorCategory
                if (field == "CategoryId" && id >= 5)
                {
                    id -= 3;
                }
                */
                /* for Correct DealerArea
                if (field == "ParentId" && id > 40)
                    id -= 1;
                */
                if (field == "AreaId" && id > 40)
                    id -= 1;

                return id;
            }
            return value;
        }

        static void TransferPress()
        {
            string[] src_fields = {"category_id", "title", "sub_title", "author", "press_from", "summary", "content", "is_active", "thumbnail", "tags", "publish_date"};
            string[] target_fields = {"CategoryId", "Title", "SubTitle", "Author", "PressFrom", "Summary", "Content", "Active", "Thumbnail", "Tags", "CreatedDate"};
            Transfer("press_press", "Presses", src_fields, target_fields);
        }

        static void TransferMagzineYear()
        {
            string[] src_fields = {"year"};
            string[] target_fields = {"Year"};
            Transfer("press_magzineyear", "MagzineYears", src_fields, target_fields);
        }

        static void TransferMagzine()
        {
            string[] src_fields = {"name", "ordering", "thumbnail", "active", "year_id", "slug"};
            string[] target_fields = {"Name", "Ordering", "Thumbnail", "Active", "MagzineYearId", "Slug"};
            Transfer("press_magzine", "Magzines", src_fields, target_fields);
        }

        static void TransferStyleCategory()
        {
            string[] src_fields = {"name", "active", "slug"};
            string[] target_fields = {"Name", "Active", "Slug"};
            Transfer("product_stylecategory", "StyleCategories", src_fields, target_fields);
        }

        static void TransferStyle()
        {
            string[] src_fields = {"category_id", "name", "slug", "ordering", "active", "summary", "introduce"};
            string[] target_fields = {"styleCategoryId", "Name", "Slug", "Ordering", "Active", "Summary", "Introduce"};
            Transfer("product_style", "Styles", src_fields, target_fields);
        }

        static void TransferStyleImage()
        {
            string[] src_fields = {"style_id", "image", "thumbnail"};
            string[] target_fields = {"StyleId", "Image", "Thumbnail"};
            Transfer("product_styleimage", "StyleImages", src_fields, target_fields);
        }

        static void TransferHonorCategory()
        {
            string[] src_fields = {"name", "slug", "ordering"};
            string[] target_fields = {"Name", "Slug", "Ordering"};
            Transfer("honor_category", "HonorCategories", src_fields, target_fields);
        }

        static void TransferHonor()
        {
            string[] src_fields = {"category_id", "name", "year", "description", "image", "ordering", "active"};
            string[] target_fields = {"CategoryId", "Name", "Year", "Description", "Image", "Ordering", "Active"};
            Transfer("honor_honor", "Honors", src_fields, target_fields);
        }

        static void TransferJob()
        {
            string[] src_fields = {"name", "experience", "education", "professional", "age", "gender", "description", "publish_date", "expired_date"};
            string[] target_fields = {"Name", "Experience", "Education", "Professional", "Age", "Gender", "Description", "PublishDate", "ExpiredDate"};
            Transfer("jobs_job", "Jobs", src_fields, target_fields);
        }

        static void TransferCase()
        {
            string[] src_fields = {"category_id", "name", "description", "image", "create_date"};
            string[] target_fields = {"CategoryId", "Name", "Description", "Image", "CreatedDate"};
            Transfer("case_case", "Cases", src_fields, target_fields);
        }

        static void TransferCaseCategory()
        {
            string[] src_fields = {"name", "slug"};
            string[] target_fields = {"Name", "Slug"};
            Transfer("case_category", "CaseCategories", src_fields, target_fields);
        }

        static void TransferArea()
        {
            string[] src_fields = {"parent_id", "name", "boundary"};
            string[] target_fields = {"ParentId", "Name", "Boundary"};
            Transfer("dealer_area", "Areas", src_fields, target_fields);
        }

        static void TransferDealer()
        {
            string[] src_fields = {"area_id", "name", "address", "contact", "tel", "mobile", "fax", "website", "zipcode", "latitude", "longitude", "active"};
            string[] target_fields = {"AreaId", "Name", "Address", "Contact", "Tel", "Mobile", "Fax", "Website", "Zipcode", "latitude", "longitude", "Active"};
            Transfer("dealer_dealer", "Dealers", src_fields, target_fields);
        }

        static void CreateProduct()
        {
            string path = "E:/code/vcms1/src/vuuvv.web/App_Data/product_category.txt";
            StreamReader reader = new StreamReader(path);
            string line = "";
            string conn_schema = "Data Source = {0}";
            string sqlce = string.Format(conn_schema, "E:/code/vcms1/src/vuuvv.web/App_Data/vuuvv.sdf");

            using (SqlCeConnection conn = new SqlCeConnection(sqlce))
            {
                conn.Open();
                while (line != null)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                    if (line != null && line != "")
                    {
                        var parts = line.Split();
                        var cateId = parts[0];
                        var pname = parts[1];
                        Dictionary<string, object> rec = new Dictionary<string, object>();
                        rec["Sku"] = pname;
                        rec["Name"] = pname;
                        rec["Slug"] = pname;
                        rec["Image"] = string.Format("upload/product/{0}.jpg", pname);
                        rec["Thumbnail"] = string.Format("upload/product/thumb/{0}.jpg", pname);
                        rec["Ordering"] = 1000;
                        rec["Active"] = true;
                        rec["CreatedDate"] = DateTime.Now;
                        var id = InsertRecorder("Products", rec, conn);

                        rec = new Dictionary<string, object>();
                        rec["Product_Id"] = id;
                        rec["ProductCategory_Id"] = Convert.ToInt32(cateId);
                        InsertRecorder("ProductProductCategories", rec, conn);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            TransferDealer();
            Console.ReadKey();
        }

        static int InsertRecorder(string table, Dictionary<string, object> recorder, SqlCeConnection conn)
        {
            var keys = recorder.Keys;
            var pkeys = new List<string>();
            foreach (var key in keys)
            {
                pkeys.Add("@" + key);
            }
            string sql = string.Format("INSERT INTO {0}({1}) VALUES ({2})", 
                table, string.Join(",", keys), string.Join(",", pkeys));

            using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
            {
                foreach (var col in recorder)
                {
                    cmd.Parameters.AddWithValue("@" + col.Key, col.Value);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT @@IDENTITY AS TEMPVALUE", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        static void ReadRecorders()
        {
        }
    }
}
