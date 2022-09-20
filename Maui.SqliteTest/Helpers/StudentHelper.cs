using Maui.SqliteTest.Models;

using SQLite;

namespace Maui.SqliteTest.Helpers
{
    public class StudentHelper
    {
        private SQLiteAsyncConnection dbConnection;

        private async Task ConnectionDB()
        {
            if (this.dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                this.dbConnection = new SQLiteAsyncConnection(dbPath);

                // Create Table
                await this.dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await ConnectionDB();
            return await this.dbConnection.InsertAsync(studentModel);
        }

        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await ConnectionDB();
            return await this.dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            await ConnectionDB();
            var studentList = await dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }

        public async Task<int> UpdateStudent(StudentModel studentModel)
        {
            await ConnectionDB();
            return await this.dbConnection.UpdateAsync(studentModel);
        }
    }
}
