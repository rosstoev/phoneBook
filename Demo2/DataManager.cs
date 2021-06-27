using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class DataManager
    {
        public const string QUERY_CONNECTION = "server=localhost;user id=root;password=;database=contact_book;";
        public List<Contact> Contacts { get; } = new List<Contact>();

        public List<Contact> GetAllContacts()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(QUERY_CONNECTION);
            MySqlCommand mySqlCommand = new MySqlCommand("select * from contacts", mySqlConnection);

            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                int id = int.Parse(mySqlDataReader.GetString(0));
                string name = mySqlDataReader.GetString(1);
                string phoneNumber = mySqlDataReader.GetString(2);

                Contacts.Add(new Contact(id, name, phoneNumber));
            }

            mySqlConnection.Close();
            return Contacts;
        }

        public void SaveContact(string name, string phoneNumber)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(QUERY_CONNECTION);
            MySqlCommand mySqlCommand = new MySqlCommand(
                "INSERT INTO contacts (name, number) VALUES(@name, @phoneNumber)",
                mySqlConnection
                );
            mySqlCommand.Parameters.AddWithValue("@name", name);
            mySqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public void EditContact(string id, string name, string phoneNumber)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(QUERY_CONNECTION);
            MySqlCommand mySqlCommand = new MySqlCommand(
                "UPDATE contacts SET name=@name, number=@phoneNumber WHERE id=@contactId",
                mySqlConnection
                );
            mySqlCommand.Parameters.AddWithValue("@contactId", id);
            mySqlCommand.Parameters.AddWithValue("@name", name);
            mySqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public void DeleteContact(string id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(QUERY_CONNECTION);
            MySqlCommand mySqlCommand = new MySqlCommand(
                "DELETE FROM contacts WHERE id=@id",
                mySqlConnection
                );
            mySqlCommand.Parameters.AddWithValue("@id", id);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public Contact GetContactById(string id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(QUERY_CONNECTION);
            MySqlCommand mySqlCommand = new MySqlCommand(
                "SELECT * FROM contacts WHERE id=@id",
                mySqlConnection
                );
            mySqlCommand.Parameters.AddWithValue("@id", id);
            mySqlConnection.Open();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            reader.Read();
            int contactId = int.Parse(reader.GetString(0));
            string name = reader.GetString(1);
            string phoneNumber = reader.GetString(2);

            Contact contact = new Contact(contactId, name, phoneNumber);

            mySqlConnection.Close();
            return contact;
        }
    }
}
