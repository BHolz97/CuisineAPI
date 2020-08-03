using CuisineOrdersAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CuisineOrdersAPI.Data
{
    public class SqlCuisineOrderRepo : ICuisineOrderRepo
    {
        private readonly CuisineOrderContext _context; 

        public SqlCuisineOrderRepo(CuisineOrderContext context) 
        {
            _context = context;
        }

    public void CreateCuisineOrder(CuisineOrder cmd)
        {           
            throw new NotImplementedException();
        }

        public void CreateCuisineOrder(OnlineOrderHeader header, OnlineOrderLines lines) 
        {
            if (header == null || lines == null)
            {
                throw new ArgumentNullException();
            }

            _context.OnlineOrderHeader.Add(header);

            try
            {
                SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine("Unable to save changes to OnlineOrderHeader");
                throw new Exception(@"[Unable to save changes]", e);
            }

            Console.WriteLine(_context.OnlineOrderHeader.Max(p => p.OnlineOrderId));//TEST

            lines.OnlineOrderHeaderId = _context.OnlineOrderHeader.Max(p => p.OnlineOrderId);

            _context.OnlineOrderLines.Add(lines);            

            StoredProcInt();
        }

public IEnumerable<CuisineOrder> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        private int StoredProcInt() //Change to number retrieved from DB
        {
            int outInt = 0;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = "server=41.185.30.246; initial catalog=CUFABMWPJune2014; User ID=Jean; Password=Genie77;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_ProcessOnlineOrders";
            cmd.Parameters.AddWithValue("@AppOrderID", 5863);

            cmd.Parameters.Add("@OutInt", SqlDbType.Int);
            cmd.Parameters["@OutInt"].Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                outInt = Convert.ToInt32(cmd.Parameters["@OutInt"].Value);               
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
            return outInt;
        }
    }
}
