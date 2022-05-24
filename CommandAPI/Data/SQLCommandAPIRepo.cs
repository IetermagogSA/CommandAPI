using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class SQLCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        public SQLCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(ci => ci.Id.Equals(id));
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
