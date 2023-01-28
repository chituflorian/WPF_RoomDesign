using System;
using WPF_Design.Models;

namespace WPF_Design.ViewModels.Commands
{
    public class FileManipulationCommand : BaseCommand<RoomObjects>
    {
        public FileManipulationCommand(Action<RoomObjects> action, Func<RoomObjects, bool> canExecute = null)
            : base(action, canExecute)
        {
        }
    }
}
