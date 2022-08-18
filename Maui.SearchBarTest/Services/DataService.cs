using Maui.SearchBarTest.Models;

namespace Maui.SearchBarTest.Services
{
    public class DataService
    {
        private static List<ItemModel> results;

        public static List<ItemModel> GetResult()
        {
            results = new List<ItemModel>();

            results.Add(new ItemModel() { ID = 1, Name = "A홍길동" });
            results.Add(new ItemModel() { ID = 2, Name = "B강감찬" });
            results.Add(new ItemModel() { ID = 3, Name = "C이순신" });
            results.Add(new ItemModel() { ID = 4, Name = "C이율곡" });
            results.Add(new ItemModel() { ID = 4, Name = "B강이식" });
            results.Add(new ItemModel() { ID = 4, Name = "D홍두께" });
            results.Add(new ItemModel() { ID = 4, Name = "C이이" });
            results.Add(new ItemModel() { ID = 4, Name = "E유관순" });

            return results;
        }

        public static List<ItemModel> GetSearchResults(string query)
        {
            return results.Where(c => c.Name.Contains(query) == true).ToList();
        }
    }
}
