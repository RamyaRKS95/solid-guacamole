using BeHapi.Models;
using System;
using System.Threading.Tasks;

namespace BeHapi.BusinessLogic
{
    public class BackingStoreService : IBackingStoreService
    {
        public void Insert() { }
        public void Update() { }
        public void Get() { }
        public Task GetManyAsync() { throw new NotImplementedException(); }
        public void Delete() { }
    }
}
