using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommand()
        {
           var commands = new List<Command>
           {
                new Command{Id=0,HowTo="adc",Line="ffdf",Platform="jnjn"},
                new Command{Id=1,HowTo="adc",Line="ffdf",Platform="jnjn"},
                new Command{Id=2,HowTo="adc",Line="ffdf",Platform="jnjn"}
           };
           return commands;
        }
        public Command GetCommandById(int id)
        {
           return new Command{Id=0,HowTo="adc",Line="ffdf",Platform="jnjn"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }      
}
    
    
