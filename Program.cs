using AutoSale.Model;
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
                car.License = dr.GetString(3);
                car.Date = dr.GetInt32(4);

                cars.Add(car);
            } while (dr.Read());



            



            conn.Connection.Close();
        }
        public static void feladat2()
        {
            
            string marka, tipus, azon;
            int ev;
            Console.WriteLine("Kérem az autó márkáját");
            marka = Console.ReadLine();

            Console.WriteLine("Kérem az autó tipusat");
            tipus = Console.ReadLine();

            Console.WriteLine("Kérem az autó motorkodjat");
            azon = Console.ReadLine();

            Console.WriteLine("Kérem az autó gyártási évét");
            ev = Convert.ToInt32( Console.ReadLine());

            string sql = $"INSERT INTO `cars`( `Brand`, `Type`, `License`, `Date`) VALUES ('{marka}','{tipus}','{azon}','{ev}')";
            conn.Connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();
            conn.Connection.Close() ;
        }
        public static void feladat3()
        {
            int ev, id;
            Console.WriteLine("Kérem az auto idjet");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("kérem az új gyártási idejét");
            ev = Convert.ToInt32( Console.ReadLine());
            string sql = $"UPDATE `cars` SET `Date`='{ev}' WHERE `id`={id}";
            conn.Connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();
            conn.Connection.Close();
        }
        public static void feladat4()
        {
            int id;
            Console.WriteLine("Kérem a törölni kívánt auto idjet");
            id = Convert.ToInt32(Console.ReadLine());
            string sql = $"DELETE FROM `cars` WHERE `id`={id}";
            conn.Connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();
            conn.Connection.Close();
        }
        static void Main(string[] args)
        {
            feladat1();
            foreach (var item in cars) 
            {
                Console.WriteLine($"Márka: {item.Brand}, azonositó: {item.License}");
            }
            feladat2();
            feladat3();
            feladat4();
            
        }
    }
}
