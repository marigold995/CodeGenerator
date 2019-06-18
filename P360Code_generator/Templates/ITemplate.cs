using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Templates
{
    public interface ITemplate
    {
        IDictionary<string, object> Session { get; set; }
        void Initialize();
        string TransformText();
    }
}
