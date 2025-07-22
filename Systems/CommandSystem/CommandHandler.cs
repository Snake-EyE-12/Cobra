using System.Collections.Generic;

namespace Cobra.DesignPattern
{
    public class CommandHandler
    {
        private List<Command> commandOrder;
        private int index;

        public CommandHandler()
        {
            commandOrder = new List<Command>();
            index = 0;
        }
        
        public void Execute(Command command) {
            if(commandOrder.Count > index) commandOrder.RemoveRange(index, commandOrder.Count - index);
            commandOrder.Add(command);
            command.Execute();
            index++;
        }

        public bool Undo()
        {
            if(index <= 0)
            {
                return false;
            }
            index--;
            commandOrder[index].Undo();
            return true;
        }

        public bool Redo()
        {
            if(index == commandOrder.Count)
            {
                return false;
            }
            commandOrder[index].Execute();
            index++;
            return true;
        }
        
        public void Clear() {
            commandOrder.Clear();
            index = 0;
        }

        public int Count => index;

    }

    public interface Command
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}