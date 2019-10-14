using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{

    class DatabaseOperations
    {

        public static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
            + System.IO.Directory.GetCurrentDirectory() + "\\CarHire.mdf;Integrated Security=True;Connect Timeout=30;");

        public static bool testConnection()
        {
            try
            {
                connect.Open();
                connect.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void readDatabase(out List<Car> cars, out List<Van> vans)
        {
            List<Car> car_ = new List<Car>();
            List<Van> van_ = new List<Van>();

            try
            {
                connect.Open();
                SqlCommand read = new SqlCommand("SELECT * FROM dbo.Vehicles;", connect);
                SqlDataReader reader = read.ExecuteReader();

                while (reader.Read())
                {
                    if ((bool)reader["Car"])
                    {
                        Car c = new Car();
                        c.Make = reader["Make"].ToString();
                        c.Model = reader["Model"].ToString();
                        c.EngineSize = (int)reader["Engine"];
                        c.FuelType = reader["Fuel"].ToString();
                        c.Manual = (bool)reader["Manual"];
                        c.Price = double.Parse(reader["Price"].ToString());
                        c.Doors = (int)reader["Doors"];
                        c.Seats = (int)reader["Seats"];
                        c.Body = reader["Body"].ToString();
                        //c.Available = (bool)reader["Available"];
                        //c.AvailableOn = (DateTime)reader["AvailableOn"];
                        c.RegNumber = reader["RegNumber"].ToString();

                        car_.Add(c);

                    }
                    else
                    {
                        Van v = new Van();
                        v.Make = reader["Make"].ToString();
                        v.Model = reader["Model"].ToString();
                        v.EngineSize = (int)reader["Engine"];
                        v.FuelType = reader["Fuel"].ToString();
                        v.Manual = (bool)reader["Manual"];
                        v.Price = double.Parse(reader["Price"].ToString());
                        v.CargoSpace = Convert.ToDouble(reader["Cargo"]);
                        v.SideDoor = (bool)reader["SideDoor"];
                        v.Wheelbase = Convert.ToChar(reader["WheelBase"]);
                       // v.Available = (bool)reader["Available"];
                       // v.AvailableOn = (DateTime)reader["AvailableOn"];
                        v.RegNumber = reader["RegNumber"].ToString();
                        van_.Add(v);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                connect.Close();
            }

            cars = car_;
            vans = van_;
            try
            {
                
                for (int i = 0; i < cars.Count; i++)
                {
                    connect.Open();
                    SqlCommand readDates = new SqlCommand("SELECT * FROM dbo.HireDates WHERE RegNumber LIKE @regNumber;", connect);
                    readDates.Parameters.AddWithValue("@regNumber", cars[i].RegNumber);
                    readDates.ExecuteNonQuery();
                    SqlDataReader datesReader = readDates.ExecuteReader();

                    while (datesReader.Read())
                    {

                        Hired temp = new Hired((DateTime)datesReader["StartDate"], (DateTime)datesReader["ReturnDate"]);
                        Console.WriteLine(temp);
                        cars[i].hiredDates.Add(temp);
                    }
                    cars[i].sortHiredList();
                    connect.Close();
                }
                for (int i = 0; i < vans.Count; i++)
                {
                    connect.Open();
                    SqlCommand readDates = new SqlCommand("SELECT * FROM dbo.HireDates WHERE RegNumber LIKE @regNumber;", connect);
                    readDates.Parameters.AddWithValue("@regNumber", vans[i].RegNumber);
                    readDates.ExecuteNonQuery();
                    SqlDataReader datesReader = readDates.ExecuteReader();

                    while (datesReader.Read())
                    {

                        Hired temp = new Hired((DateTime)datesReader["StartDate"], (DateTime)datesReader["ReturnDate"]);
                        Console.WriteLine(temp);
                        vans[i].hiredDates.Add(temp);
                    }
                   vans[i].sortHiredList();
                    connect.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
        public static void writeDatabase(List<Car> cars, List<Van> vans)
        {
            try
            {
                connect.Open();

                for (int i = 0; i < cars.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO dbo.Vehicles (Car,RegNumber,Make,Model,Engine,Fuel,Manual,Price,Doors,Seats,Body,Available,AvailableOn) " +
                         "VALUES (@car,@regNumber,@make,@model,@engine,@fuel,@manual,@price,@doors,@seats,@body,@available,@availableOn);", connect);

                    command.Parameters.AddWithValue("@car", true);
                    command.Parameters.AddWithValue("@regNumber", cars[i].RegNumber);
                    command.Parameters.AddWithValue("@make", cars[i].Make);
                    command.Parameters.AddWithValue("@model", cars[i].Model);
                    command.Parameters.AddWithValue("@engine", cars[i].EngineSize);
                    command.Parameters.AddWithValue("@fuel", cars[i].FuelType);
                    command.Parameters.AddWithValue("@manual", cars[i].Manual);
                    command.Parameters.AddWithValue("@price", cars[i].Price);
                    command.Parameters.AddWithValue("@doors", cars[i].Doors);
                    command.Parameters.AddWithValue("@seats", cars[i].Seats);
                    command.Parameters.AddWithValue("@body", cars[i].Body);
                    command.Parameters.AddWithValue("@available", cars[i].Available);
                    command.Parameters.AddWithValue("@availableOn", cars[i].AvailableOn);
                    command.ExecuteNonQuery();

                }

                for (int i = 0; i < vans.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO dbo.Vehicles (Car,RegNumber,Make,Model,Engine,Fuel,Manual,Price,Cargo,SideDoor,WheelBase,Available,AvailableOn)" +
                         " VALUES (@car,@regNumber,@make,@model,@engine,@fuel,@manual,@price,@cargo,@sideDoor,@wheelBase,@available,@availableOn);", connect);

                    command.Parameters.AddWithValue("@car", false);
                    command.Parameters.AddWithValue("@regNumber", vans[i].RegNumber);
                    command.Parameters.AddWithValue("@make", vans[i].Make);
                    command.Parameters.AddWithValue("@model", vans[i].Model);
                    command.Parameters.AddWithValue("@engine", vans[i].EngineSize);
                    command.Parameters.AddWithValue("@fuel", vans[i].FuelType);
                    command.Parameters.AddWithValue("@manual", vans[i].Manual);
                    command.Parameters.AddWithValue("@price", vans[i].Price);
                    command.Parameters.AddWithValue("@cargo", vans[i].CargoSpace);
                    command.Parameters.AddWithValue("@sideDoor", vans[i].SideDoor);
                    command.Parameters.AddWithValue("@wheelBase", vans[i].Wheelbase);
                    command.Parameters.AddWithValue("@available", vans[i].Available);
                    command.Parameters.AddWithValue("@availableOn", vans[i].AvailableOn);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("asd");
            }
            finally
            {
                connect.Close();
            }
        }
        public static void writeHire(Vehicle inputVehicle)
        {
            try
            {
                connect.Open();


                SqlCommand command = new SqlCommand("INSERT INTO dbo.HireDates (RegNumber, StartDate,ReturnDate) " +
                     "VALUES (@regNumber,@start,@return);", connect);

                command.Parameters.AddWithValue("@regNumber", inputVehicle.RegNumber);
                command.Parameters.AddWithValue("@start", inputVehicle.hiredDates[inputVehicle.hiredDates.Count - 1].StartDate);
                command.Parameters.AddWithValue("@return", inputVehicle.hiredDates[inputVehicle.hiredDates.Count - 1].ReturnDate);
                command.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                connect.Close();
            }
        }
        public static void updateVehicle(Vehicle inputVehicle)
        {

            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand("UPDATE dbo.Vehicles SET Available = @available, AvailableOn = @availableOn WHERE RegNumber LIKE @nbReg;", connect);

                command.Parameters.AddWithValue("@nbReg", inputVehicle.RegNumber);
                command.Parameters.AddWithValue("@available", inputVehicle.Available);
                command.Parameters.AddWithValue("@availableOn", inputVehicle.AvailableOn);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                connect.Close();
            }
            writeHire(inputVehicle);
        }
    }

}
