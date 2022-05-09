using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public CompilationUnitSyntax Code
        {
            get => _code;
            set => this.RaiseAndSetIfChanged(ref _code, value);
        }
        private CompilationUnitSyntax _code;
        private readonly ObservableAsPropertyHelper<string> _outCode;
        /// <summary>
        /// Out Code
        /// </summary>
        public string StringCode => _outCode.Value;
        /// <summary>
        /// Constructor!
        /// </summary>
        public CSCodePreviewViewModel()
        {
            this.WhenAnyValue(vm => vm.Code).Where(c => c != null)
                .Select(c =>
                {
                    return c.NormalizeWhitespace().ToString();
                }).ToProperty(this, vm => vm.StringCode, out _outCode);
        }
    }
}
