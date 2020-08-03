using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuisineOrdersAPI.Models;

namespace CuisineOrdersAPI.Data
{
    public interface ICuisineOrderRepo
    {
        bool SaveChanges();

        IEnumerable<CuisineOrder> GetAllCommands(); 
        void CreateCuisineOrder(CuisineOrder cmd); 
        void CreateCuisineOrder(OnlineOrderHeader header, OnlineOrderLines lines); 
    }
}
