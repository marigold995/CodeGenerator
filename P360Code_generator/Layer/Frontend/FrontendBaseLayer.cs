using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class FrontendBaseLayer: LayerBase
    {
        public FrontendBaseLayer(): base()
        {
            Extension = ExtensionEnum.ts;
        }
    }
}
