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
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.CommandItems.Add(command);
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
