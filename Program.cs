﻿using AutoSale.Model;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    public class Program
    {
        public static Connect conn = new Connect();
        public static List<Car> cars = new List<Car>();
        public static void feladat1() 
        {
            
            string sql = "SELECT * FROM cars";

            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            do
            {
                Car car = new Car();
                car.Id = dr.GetInt32(0);
                car.Brand = dr.GetString(1);
                car.Type = dr.GetString(2);
                cars.Add(car);
            } while (dr.Read());



            



            conn.Connection.Close();
        }
        static void Main(string[] args)
        {
            feladat1();
            Console.WriteLine(cars.Count);
            Console.ReadLine();
        }
    }
}
