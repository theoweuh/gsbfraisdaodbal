using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace gsbfraisdaodbal.Data
{
    public class Dbal
    {
        private MySqlConnection connection;

        public Dbal(string database, string uid = "root", string password = "&6HAUTdanslaFauré", string server = "localhost")
        {
            Initialize(database, uid, password, server);

        }


        private void Initialize(string database, string uid, string password, string server)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);


        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        private void CUDQuery(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Insert statement
        public void Insert(string query)
        {
            query = "INSERT INTO " + query; // tablename (field1, field2) VALUES('value 1', 'value 2')";
            CUDQuery(query);

        }
        //Update statement
        public void Update(string query)
        {
            query = "UPDATE " + query;

            CUDQuery(query);
        }

        //Delete statement
        public void Delete(string query)
        {
            query = "DELETE FROM " + query;

            CUDQuery(query);
        }
        //RQuery: Read query method (to execute SELECT queries)
        private DataSet RQuery(string query)
        {
            DataSet dataset = new DataSet();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Add query data in a DataSet
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataset);
                CloseConnection();
            }
            return dataset;
        }
        public DataTable SelectAll(string table)
        {
            string query = "SELECT * FROM " + table;
            DataSet dataset = RQuery(query);

            return dataset.Tables[0];
        }
        public DataRow SelectById(string table, int id)
        {
            string query = "SELECT * FROM " + table + " where id='" + id + "'";
            DataSet dataset = RQuery(query);

            return dataset.Tables[0].Rows[0];
        }
        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + " where " + fieldTestCondition;
            DataSet dataset = RQuery(query);

            return dataset.Tables[0];
        }
    }

    internal class MySqlCommand
    {
        private string query;
        private MySqlConnection connection;

        public MySqlCommand(string query, MySqlConnection connection)
        {
            this.query = query;
            this.connection = connection;
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    internal class MySqlException : Exception
    {
        public MySqlException()
        {
        }

        public MySqlException(string? message) : base(message)
        {
        }

        public MySqlException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MySqlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class MySqlConnection
    {
        private string connectionString;

        public MySqlConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }

    internal class MySqlDataAdapter
    {
        public MySqlDataAdapter(string query, MySqlConnection connection)
        {
            Query = query;
            Connection = connection;
        }

        public string Query { get; }
        public MySqlConnection Connection { get; }

        internal void Fill(DataSet dataset)
        {
            throw new NotImplementedException();
        }
    }
}
