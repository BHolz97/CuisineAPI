using CuisineOrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisineOrdersAPI.Data
{
    public class MockCuisineOrderRepo : ICuisineOrderRepo
    {
        public void CreateCuisineOrder(CuisineOrder cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateCuisineOrder(OnlineOrderHeader header, OnlineOrderLines lines)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CuisineOrder> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
