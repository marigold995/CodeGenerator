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

        public List<string> Attributes { get; set; }
        public  enum screenEnum
        {
            GetAll,
            Get,
            Post,
            Put,
            Delete
        }

        public List<screenEnum> Screens { get; set; }

        public bool Cache { get; set; }

        public enum facadeEnum
        {
            GBM,
            ABM,
            API,
            USM
        }

        public facadeEnum Facade { get; set; }

        public Entity(string EntityName)
        {
            this.EntityName = EntityName;
            Attributes = new List<string>();
            Screens = new List<screenEnum>();
        }
        
        public Entity AddScreenList()
        {
            Screens.Add(Entity.screenEnum.GetAll);
            return this;
        }
        public Entity AddScreenDetails()
        {
            Screens.Add(Entity.screenEnum.Get);
            return this;            
        }
        public Entity AddScreenCreate()
        {
            Screens.Add(Entity.screenEnum.Post);
            return this;
            
        }
        public Entity AddScreenUpdate()
        {
            Screens.Add(Entity.screenEnum.Put);
            return this;
        }

        public Entity AddScreenDelete()
        {            
            Screens.Add(Entity.screenEnum.Delete);
            return this;
        }        

        public Entity AddGBMFacade()
        {
            var entity = this;
            entity.Facade = Entity.facadeEnum.GBM;
            return entity;
        }

    }
}
