using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommandRepo 
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;            
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            { throw new ArgumentNullException(nameof(cmd));}
            _context.Command.Add(cmd);
            //_context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateCommand(Command cmd)
        {
            
        }

        IEnumerable<Command> ICommandRepo.GetAppCommand()
        {
             return _context.Command.ToList();
        }

        Command ICommandRepo.GetCommandById(int id)
        {
            return  _context.Command.FirstOrDefault(p=> p.Id == id);
        }
    }
}