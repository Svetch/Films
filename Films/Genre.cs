using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films
{
    internal class Genre
    {
        public static Dictionary<int,Genre> genres = new Dictionary<int,Genre>();
        public int Id { get; set; }
        public string Name { get; set; }
        private Genre(int id, string name)
        {
            Id = id;
            Name = name;
            genres.Add(id, this);
        }
        static Genre valueOf(int id) {
            return genres[id];
        }

        public static Genre create(string name) {
            /*Database.Instance.*/
            MySqlCommand mySqlCommand = Database.Instance.newMysqlCommand($"Insert into genre (name) values ('{name}')");
            mySqlCommand.ExecuteNonQuery();
            return new Genre((int)mySqlCommand.LastInsertedId, name);
        }

        public void update(string name) { 
            MySqlCommand command = Database.Instance.newMysqlCommand($"Update genre set name = {name} where id = {Id}");
            command.ExecuteNonQuery();
        }

        public void delete()
        {
            MySqlCommand command = Database.Instance.newMysqlCommand($"Delete from genre wheere id = {Id}");
            command.ExecuteNonQuery();
        }
    }
}
