using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels
{
    /// <summary>
    /// Preview VM!
    /// </summary>
    public class CSCodePreviewViewModel : ReactiveObject
    {
        /// <summary>
        /// preview code
        /// </summary>
        public string Code
        {
            get => _code;
            set => this.RaiseAndSetIfChanged(ref _code, value);
        }
        private string _code;
        private readonly ObservableAsPropertyHelper<string> _outCode;
        /// <summary>
        /// Out Code
        /// </summary>
        public string OutCode => _outCode.Value;
        /// <summary>
        /// Constructor!
        /// </summary>
        public CSCodePreviewViewModel()
        {
            this.WhenAnyValue(vm => vm.Code).Where(c => c != null)
                .Select(c =>
                {
                    return c;
                }).ToProperty(this, vm => vm.OutCode, out _outCode);
        }
    }
}
