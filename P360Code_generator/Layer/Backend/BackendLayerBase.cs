using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Backend
{
    public abstract class BackendLayerBase: BaseLayer
    {
        public BackendLayerBase(): base()
        {
            Extension = ExtensionEnum.cs;
        }
    }
}
