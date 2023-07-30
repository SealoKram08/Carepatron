using api.Models;

namespace api.Data
{
    public class DataSeeder
    {
        private readonly DataContext dataContext;

        public DataSeeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Seed()
        {
            var client = new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e6"), "John", "Smith", "john@gmail.com", "+18202820232");

            dataContext.Add(client);
            dataContext.SaveChanges();
        }
    }
}

