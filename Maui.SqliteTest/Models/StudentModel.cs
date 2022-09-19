using SQLite;

namespace Maui.SqliteTest.Models
{
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
