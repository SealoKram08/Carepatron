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
            dataContext.Add(new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e6"), "John", "Smith", "john@gmail.com", "+18202820232"));
            dataContext.Add(new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e5"), "Mark", "Olaes", "Mark@gmail.com", "+18202820232"));
            dataContext.Add(new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e4"), "Anthony", "Olaes", "Anthony@gmail.com", "+18202820232"));
            dataContext.Add(new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e3"), "John", "Doe", "Doe@gmail.com", "+18202820232"));
            dataContext.Add(new Client(new Guid("516945eb-d70e-469e-a3f6-1d549e5ed5e2"), "Tony", "Stark", "Tony@gmail.com", "+18202820232"));

            dataContext.SaveChanges();
        }
    }
}

