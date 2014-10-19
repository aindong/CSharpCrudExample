using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpCRUDExample.Interfaces;
using MySql.Data.MySqlClient;

namespace CSharpCRUDExample.Models
{
    class Group : IDatabaseModel<Group>
    {
        /*
         * Private properties declaration
         * ****************************************************************/
        private List<Group> groups = new List<Group>();

        /*
         * Public properties declaration
         * ****************************************************************/
        public int id { get; set; }
        public string group_name { get; set; }

        /// <summary>
        /// Retrieve the list of groups from the database
        /// </summary>
        /// <returns>List of groups</returns>
        public List<Group> Retrieve()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Properties.Settings.Default.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT id, group_name FROM groups";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Group group = new Group();
                        group.id = Int32.Parse(reader["id"].ToString());
                        group.group_name = reader["group_name"].ToString();

                        // Add the group into the list
                        groups.Add(group);
                    }
                }
            }
            catch (MySqlException ex)
            {

            }

            return groups;
        }

        public Group FindById(int id)
        {
            Group group = new Group();

            return group;
        }

        public void Create()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Properties.Settings.Default.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO groups(group_name) VALUES(@group_name)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("group_name", this.group_name);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {

            }
        }

        public void Update(Group group)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
