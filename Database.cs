using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CharacterCreationSystem
{ 
    public class SQLConnection
    {
        private static MySqlConnection connMaster;
        
        private static string server = "localhost";
        private static string database = "charactercreationdb";
        private static string Uid = "root";
        private static string password = "password";
        public SQLConnection()
        {
            string connectionString = $"server={server};database={database};User Id={Uid};Password={password};";
            connMaster = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connMaster ?? throw new Exception("Connection cannot be established!");
        }

        public void ConnOpen()
        {
            if(connMaster.State == System.Data.ConnectionState.Closed)
            {
                connMaster.Open();
            }
        }

        public void ConnClose()
        {
            if (connMaster.State == System.Data.ConnectionState.Open)
            {
                connMaster.Close();
            }
        }

        static SQLConnection con = new SQLConnection();
        public static void AddToLocalDatabase()
        {
            try
            {
                con.ConnOpen();
                string sql = "SELECT * FROM characterInformation";

                using (MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection()))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] dataRow = new object[reader.FieldCount];

                        reader.GetValues(dataRow);

                        object[] pirateElements = Character.SetCharacter(dataRow);
                        Pirate pirate = Character.CreateCharacter(pirateElements);
                        Database.AddToDatabase(pirate);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.ConnClose();
            }
            finally
            {
                con.ConnClose();
            }
        }
        // Add character to SQL Database
        public static void AddToSQLDatabase(object[] informationArray)
        {
            try
            {
                string characterName = Convert.ToString(informationArray[0]);
                int moonCycle = Convert.ToInt32(informationArray[1]);
                int form = Convert.ToInt32(informationArray[2]);
                int pirateCode = Convert.ToInt32(informationArray[3]);
                int mainWeapon = Convert.ToInt32(informationArray[4]);
                int secondarySkill = Convert.ToInt32(informationArray[5]);
                int natureSkill= Convert.ToInt32(informationArray[6]);
                int additionalSkill = Convert.ToInt32(informationArray[7]);
                int physicalTrademark = Convert.ToInt32(informationArray[8]);
                int skinTone = Convert.ToInt32(informationArray[9]);
                int hairStyle = Convert.ToInt32(informationArray[10]);
                int facialHair = Convert.ToInt32(informationArray[11]);
                int baseClothing = Convert.ToInt32(informationArray[12]);
                int accessory = Convert.ToInt32(informationArray[13]);
                int pirateOrigin = Convert.ToInt32(informationArray[14]);
                int shipType = Convert.ToInt32(informationArray[15]);
                int shipSize = Convert.ToInt32(informationArray[16]);
                int pet = Convert.ToInt32(informationArray[17]);
                int crew = Convert.ToInt32(informationArray[18]);
                int trigger = Convert.ToInt32(informationArray[19]);
                int debuff = Convert.ToInt32(informationArray[20]);

                string characterTable = "characterInformation";

                con.ConnOpen();
                string sql = $"INSERT INTO {characterTable} (characterName, moonCycle, form, pirateCode, mainWeapon, secondarySkill, natureSkill, additionalSkill, physicalTrademark, " +
                    $"skinTone, hairStyle, facialHair, baseClothing, accessory, pirateOrigin, shipType, shipSize, pet, crew, trigger, debuff) " +
                    $"VALUES (@characterName, @moonCycle, @form, @pirateCode, @mainWeapon, @secondarySkill, @natureSkill, @additionalSkill, @physicalTrademark, @skinTone, " +
                    $"@hairStyle, @facialHair, @baseClothing, @accessory, @pirateOrigin, @shipType, @shipSize, @pet, @crew, @trigger, @debuff)";

                using (MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@characterName", characterName);
                    cmd.Parameters.AddWithValue("@moonCycle", moonCycle);
                    cmd.Parameters.AddWithValue("@form", form);
                    cmd.Parameters.AddWithValue("@pirateCode", pirateCode);
                    cmd.Parameters.AddWithValue("@mainWeapon", mainWeapon);
                    cmd.Parameters.AddWithValue("@secondarySkill", secondarySkill);
                    cmd.Parameters.AddWithValue("@natureSkill", natureSkill);
                    cmd.Parameters.AddWithValue("@additionalSkill", additionalSkill);
                    cmd.Parameters.AddWithValue("@physicalTrademark", physicalTrademark);
                    cmd.Parameters.AddWithValue("@skinTone", skinTone);
                    cmd.Parameters.AddWithValue("@hairStyle", hairStyle);
                    cmd.Parameters.AddWithValue("@facialHair", facialHair);
                    cmd.Parameters.AddWithValue("@baseClothing", baseClothing);
                    cmd.Parameters.AddWithValue("@accessory", accessory);
                    cmd.Parameters.AddWithValue("@pirateOrigin", pirateOrigin);
                    cmd.Parameters.AddWithValue("@shipType", shipType);
                    cmd.Parameters.AddWithValue("@shipSize", shipSize);
                    cmd.Parameters.AddWithValue("@pet", pet);
                    cmd.Parameters.AddWithValue("@crew", crew);
                    cmd.Parameters.AddWithValue("@trigger", trigger);
                    cmd.Parameters.AddWithValue("@debuff", debuff);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.ConnClose();
            }
            finally
            {
                con.ConnClose();
            }
        }
    }
    public class Database
    {
        public static Dictionary<string, Pirate> pirateDictionary { get; set; } = [];
        public static List<Pirate> pirateList { get; set; } = [];    

        public static void AddToDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Add(pirate.CharacterInfo.Name, pirate);
                pirateList.Add(pirate);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n:::::Error adding to database!:::::\n" + e.Message);
            }
        }

        public static void RemoveFromDatabase(Pirate pirate)
        {
            try
            {
                pirateDictionary.Remove(pirate.CharacterInfo.Name);
                pirateList.Remove(pirate);
            } 
            catch (Exception e)
            {
                Console.WriteLine("\n:::::Error removing from database!:::::\n" + e.Message);
            }
            
        }

        public static void ViewDatabase()
        {
            int i = 0;
            Console.WriteLine($"\n{"Pirate Name", -15}");

            if(pirateDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, Pirate> pirate in pirateDictionary)
                {
                    Console.WriteLine($"| {i + 1,-2} | {pirate.Key} ");
                    i++;
                }
            } else
            {
                throw new DatabaseEmptyException(":::::The database doensn't contain any entries!:::::");
            }
        } 

        public static Pirate GetPirate(int index)
        {
            if(index <= pirateList.Count && index > 0)
            {
                return pirateList[index - 1];
            } else
            {
                throw new OptionUnavailableException($":::::{index} not found in the options!:::::");
            }   
        }
    }
}