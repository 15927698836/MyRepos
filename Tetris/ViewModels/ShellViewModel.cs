using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator e, IWindowManager win)
        {
            _events = e;
            _events.Subscribe(this);
            _windowManager = win;
        }

        protected override void OnViewLoaded(object view)
        {
            ActivateItem(new HomeViewModel());
        }

        public void ExecuteAction(ActionExecutionContext context)
        {
            var eventArgs = (KeyEventArgs)context.EventArgs;

            _events.Publish(eventArgs, action => Task.Run(action));
        }

        public void Add()
        {
        }
    }
}