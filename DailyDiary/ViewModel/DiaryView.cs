using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DailyDiary.Model;

namespace DailyDiary.ViewModel
{
    public class TodoViewModel
    {
        private static TodoViewModel _todoViewModel = new TodoViewModel();
        private ObservableCollection<Todo> _allToDos = new ObservableCollection<Todo>();

        public ObservableCollection<Todo> AllTodos
        {
            get
            {
                return _todoViewModel._allToDos;
            }
        }

        public IEnumerable<Todo> GetTodos()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection("Database=acsm_b4446bccb835e14;Data Source=ap-cdbr-azure-southeast-b.cloudapp.net;User Id=b08f4fde5ed1ba;Password=23cef3a3;SslMode=None"))
                {
                    connection.Open();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT Diary FROM DailyDiary";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _todoViewModel._allToDos.Add(new Todo(reader.GetString("Diary")));
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                // Handle it :)
            }
            return _todoViewModel.AllTodos;
        }

        public bool InsertNewTodo(string what)
        {
            Todo newTodo = new Todo(what);
            // Insert to the collection and update DB
            try
            {
                using (MySqlConnection connection = new MySqlConnection("Database=acsm_b4446bccb835e14;Data Source=ap-cdbr-azure-southeast-b.cloudapp.net;User Id=b08f4fde5ed1ba;Password=23cef3a3;SslMode=None"))
                {
                    connection.Open();
                    MySqlCommand insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT INTO DailyDiary(Diary)VALUES(@Diary)";
                    insertCommand.Parameters.AddWithValue("@Diary", newTodo.whatToDO);
                    insertCommand.ExecuteNonQuery();
                    _todoViewModel._allToDos.Add(newTodo);
                    return true;

                }
            }
            catch (MySqlException)
            {
                // Don't forget to handle it
                return false;
            }

        }


        public TodoViewModel()
        {
            // Establish the connection

        }
    }
}