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

        /// <summary>
        /// Get a group by id
        /// </summary>
        /// <param name="id">The id primary key</param>
        /// <returns>Group</returns>
        public Group FindById(int id)
        {
            Group group = new Group();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Properties.Settings.Default.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT id, group_name FROM groups WHERE id = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        group.id = Int32.Parse(reader["id"].ToString());
                        group.group_name = reader["group_name"].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // When a mysql error occurs
                // TODO: Throw an exception or return a string
            }

            return group;
        }

        /// <summary>
        /// Create a new group
        /// </summary>
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
                // When a mysql error occurs
                // TODO: Throw an exception or return a strings
            }
        }

        /// <summary>
        /// Update an existing group
        /// </summary>
        /// <param name="group"></param>
        public void Update(Group group)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
