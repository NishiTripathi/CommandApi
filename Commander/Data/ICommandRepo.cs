using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data{

 public interface ICommandRepo
 {
        bool SaveChanges();
        IEnumerable<Command> GetAppCommand();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
    }
}