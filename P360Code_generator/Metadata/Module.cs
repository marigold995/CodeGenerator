using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Domain;

namespace _360Generator.Metadata
{
    public class Module
    {
        private string moduleName;
        public List<Entity> Entities{ get; set; }        

        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        public Module(string moduleName)
        {
            this.moduleName = moduleName;
            this.Entities = new List<Entity>();
        }     
        
        public void AddEntity(Entity entityName)
        {
            this.Entities.Add(entityName);
        }
    }
}
