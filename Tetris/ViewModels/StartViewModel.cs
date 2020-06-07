using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace Tetris.ViewModels
{
    [Export(typeof(StartViewModel))]
    public class StartViewModel : Conductor<object>
    {
        protected override void OnViewLoaded(object view)
        {
        }

        public void Start()
        {
        }
    }
}