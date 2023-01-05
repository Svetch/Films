using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films
{
    internal class Film
    {
        static List<Film> films = new List<Film>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Genre Genre { get; set; }

        private Film(int id, string name, string description, string image, Genre genre)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Genre = genre;
            films.Add(this);
        }

        public static Film create(string name, string description, string image, Genre genre)
        {
            MySqlCommand command = Database.Instance.newMysqlCommand($"insert into filmns (name,description,image,genre_id) values ('{name}','{description}','{image}','{genre.Id}')");
            command.ExecuteNonQuery();
            return new Film((int)command.LastInsertedId, name, description, image, genre);
        }
        public void update(object updateParams)
        {
            var updateParamString = string.Join(", ", updateParams.GetType().GetProperties().Select(selector => $"{selector.Name} = {selector.GetValue(updateParams)}").ToArray());
            MySqlCommand command = Database.Instance.newMysqlCommand($"update genre set {updateParamString}");
            command.ExecuteNonQuery();
        }
        public void delete() {
            MySqlCommand command = Database.Instance.newMysqlCommand($"Delete from film where id = {Id}");
            command.ExecuteNonQuery();
        }
    }
}
