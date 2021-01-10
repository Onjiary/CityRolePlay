﻿using AltV.Net;
using CityRoleplay.Entitys;
using CityRoleplay.Utility;
using MySql.Data.MySqlClient;
using System;


namespace CityRoleplay.Database
{
    class PlayerDatabase
    {

        public static int CreatePlayer(string username, string password)
        {
            string saltedPassword = PasswortDerivation.Derive(password);

            try
            {
                MySqlConnection connection = MyDatabase.DB.GetConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO users (name, password) VALUES (@name, @password)";

                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@password", saltedPassword);

                command.ExecuteNonQuery();
                connection.Close();
                return (int)command.LastInsertedId;

            }
            catch (Exception e)
            {
                Alt.Log("CreatePlayer: " + e.StackTrace);
                Alt.Log("CreatePlayer: " + e.Message);
            }
            return -1;
        }

        public static void LoadPlayer(MyPlayer player)
        {
            try
            {
                MySqlConnection connection = MyDatabase.DB.GetConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE name=@name LIMIT 1";

                command.Parameters.AddWithValue("@name", player.DisplayName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        player.DB_ID = reader.GetInt16("id");
                        player.Cash = reader.GetUInt32("cash");
                    }
                }

                connection.Close();

            }
            catch (Exception e)
            {
                Alt.Log("LoadPlayer: " + e.StackTrace);
                Alt.Log("LoadPlayer: " + e.Message);
            }
        }

        public static void UpdatePlayer(MyPlayer player)
        {
            try
            {
                MySqlConnection connection = MyDatabase.DB.GetConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE users SET name=@name, cash=@cash WHERE id=@id";

                command.Parameters.AddWithValue("@id", player.DB_ID);
                command.Parameters.AddWithValue("@name", player.DisplayName);
                command.Parameters.AddWithValue("@cash", player.Cash);

                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                Alt.Log("UpdatePlayer: " + e.StackTrace);
                Alt.Log("UpdatePlayer: " + e.Message);
            }
        }

        public static bool CheckLoginDetails(string username, string input)
        {
            string password = "";

            try
            {
                MySqlConnection connection = MyDatabase.DB.GetConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT password FROM users WHERE name=@name LIMIT 1";

                command.Parameters.AddWithValue("@name", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        password = reader.GetString("password");
                    }
                }
                connection.Close();

                return PasswortDerivation.Verify(password, input);

            }
            catch (Exception e)
            {
                Alt.Log("CheckLoginDetails: " + e.StackTrace);
                Alt.Log("CheckLoginDetails: " + e.Message);
            }
            return false;
        }

        public static bool DoesPlayerNameExists(string username)
        {
            try
            {
                MySqlConnection connection = MyDatabase.DB.GetConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE name=@name LIMIT 1";

                command.Parameters.AddWithValue("@name", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();

            }
            catch (Exception e)
            {
                Alt.Log("DoesPlayerNameExists: " + e.StackTrace);
                Alt.Log("DoesPlayerNameExists: " + e.Message);
            }
            return false;
        }
    }
}




/*
 * 
 * 
 * 
 * 
 * 
 
 * [02:36:27] CreateTables:You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near
 * 'EXIST users (id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,name VARCHAR(40) N...' at line 1 */


