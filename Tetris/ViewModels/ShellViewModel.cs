using Caliburn.Micro;
using Tetris.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;
        readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator e, IWindowManager win)
        {
            _events = e;
            _events.Subscribe(this);
            _windowManager = win;
        }

        protected override void OnViewLoaded(object view)
        {
            ActivateItem(new StartViewModel());
        }


        public void ExecuteAction(ActionExecutionContext context)
        {
            var eventArgs = (KeyEventArgs)context.EventArgs;

          //  if (eventArgs.Key != Key.Enter) return;

            _events.Publish(eventArgs, action => Task.Factory.StartNew(action));

        }
    }
}

