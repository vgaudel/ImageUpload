namespace ImageUpload.Models
{
    public class FileService : IDisposable
    {
        protected BddContext _bddContext;

        public FileService()
        {
            _bddContext = new BddContext();
        }

        public List<User> GetUsers()
        {
            return this._bddContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return this._bddContext.Users.Find(id);
        }

        public void initBdd()
        {
            this._bddContext.InitializeDb();
        }

        public User AddUser(User user)
        {
            Console.WriteLine("ajout User BDD");
            this._bddContext.Users.Add(user);
            this._bddContext.SaveChanges();
            return user;

        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }

    }
}
