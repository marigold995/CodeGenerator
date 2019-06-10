using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Metadata
{
    public class Entity
    {
        public string EntityName { get; set; }
       
        public List<string> Attributes{ get; set; }
        public List<string> Screens { get; set; }
        public bool Cache { get; set; }
        public string Facade { get; set; }        

        public Entity(string EntityName)
        {
            this.EntityName = EntityName;
            this.Attributes = new List<string>();            
        }
    }
}
