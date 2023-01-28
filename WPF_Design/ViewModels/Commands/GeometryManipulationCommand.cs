using System;
using WPF_Design.Models;

namespace WPF_Design.ViewModels.Commands
{
    public class GeometryManipulationCommand : BaseCommand<BaseFurniture>
    {
        public GeometryManipulationCommand(Action<BaseFurniture> action, Func<BaseFurniture, bool> canExecute = null)
            : base(action, canExecute)
        {
        }
    }
}
