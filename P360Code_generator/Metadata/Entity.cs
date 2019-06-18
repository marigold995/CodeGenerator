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
            this.Attributes = new List<string>();
            this.Screens = new List<screenEnum>();
        }

        //public void AddScreen(screenEnum screen) {
        //    Screens.Add(screen);
        //}

        public Entity AddScreenList()
        {
            var entity = this;
            entity.Screens.Add(Entity.screenEnum.GetAll);
            return entity;
        }
        public Entity AddScreenDetails()
        {
            var entity = this;
            entity.Screens.Add(Entity.screenEnum.Get);
            return entity;            
        }
        public Entity AddScreenCreate()
        {
            var entity = this;
            entity.Screens.Add(Entity.screenEnum.Post);
            return entity;
            
        }
        public Entity AddScreenUpdate()
        {
            var entity = this;
            entity.Screens.Add(Entity.screenEnum.Put);
            return entity;
        }

        public Entity AddGBMFacade()
        {
            var entity = this;
            entity.Facade = Entity.facadeEnum.GBM;
            return entity;
        }

    }
}
