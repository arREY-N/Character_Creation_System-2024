using System;
using MySql.Data.MySqlClient;

namespace CharacterCreationSystem
{
    // Class containing all the methods needed to connect to MySQL
	public class SQLConnection
    {
        private static MySqlConnection? connMaster;
        private static string server = "localhost";
        private static string database = "charactercreationdb";
        private static string Uid = "root";
        private static string password = "password";
        static SQLConnection con = new SQLConnection();

        // Sets the SQL connection object
        public SQLConnection()
        {
            string connectionString = $"server={server};database={database};User Id={Uid};Password={password};";
            connMaster = new MySqlConnection(connectionString);
        }
        // Returns the SQL connection master
        public MySqlConnection GetConnection()
        {
            return connMaster ?? throw new Exception("Connection cannot be established!");
        }
        // Opens the SQL connection
        public void ConnOpen()
        {
            if(connMaster.State == System.Data.ConnectionState.Closed)
            {
                connMaster.Open();
            }
        }
        // Closes the SQL connection
        public void ConnClose()
        {
            if (connMaster.State == System.Data.ConnectionState.Open)
            {
                connMaster.Close();
            }
        }
        // (SELECT) Method to query data from the SQL database to a local database
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

                        Pirate pirate = Character.CreateCharacter(SQLtoLocal(dataRow));
                        Database.AddToLocalDatabase(pirate);
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
        // Converts SQL data to local Element object
        public static object[] SQLtoLocal(object[] informationArray)
        {
            object[] elementArray = new object[21];
            int index = 0;

            foreach (object obj in Dictionaries.dictionaries)
            {
                object[,] innerArray = (object[,])obj;

                for (int i = 0; i < innerArray.GetLength(0); i++)
                {
                    Dictionary<int, Element> dictionary = (Dictionary<int, Element>)innerArray[i, 1];

                    if (dictionary != null)
                    {
                        foreach (KeyValuePair<int, Element> pair in dictionary)
                        {
                            if(informationArray[index] is bool)
                            {
                                string pirateCode = (Convert.ToBoolean(informationArray[index]) == true) ? "Yes" : "No";
                                
                                if (pirateCode == pair.Value.Name)
                                {
                                    elementArray[index] = pair.Value;
                                }
                            } 
                            else
                            {
                                if ((string)informationArray[index] == pair.Value.Name)
                                {
                                    elementArray[index] = pair.Value;
                                }
                            }
                        }
                    }
                    else
                    {
                        elementArray[index] = informationArray[index];
                    }
                    index++;
                }
            }
            return elementArray;
        }
        // INSERT character to SQL Database
        public static void AddToSQLDatabase(Pirate pirate)
        {
            try
            {
                string characterName = pirate.CharacterInfo.Name;
                string moonCycle = pirate.CharacterInfo.MoonCycles.Name;
                string form = pirate.CharacterInfo.Form.Name;
                bool pirateCode = pirate.CharacterInfo.PirateCode;
                string mainWeapon = pirate.CharacterWeapons.MainWeapon.Name;
                string secondarySkill = pirate.CharacterWeapons.SecondarySkill.Name;
                string natureSkill = pirate.CharacterWeapons.NatureSkill.Name;
                string additionalSkill = pirate.CharacterWeapons.AdditionalSkill.Name;
                string physicalTrademark = pirate.CharacterTraits.PhysicalTrademark.Name;
                string skinTone = pirate.CharacterTraits.SkinTone.Name;
                string hairStyle = pirate.CharacterTraits.HairStyle.Name;
                string facialHair = pirate.CharacterTraits.FacialHair.Name;
                string baseClothing = pirate.CharacterTraits.BaseClothing.Name;
                string accessory = pirate.CharacterTraits.Accessory.Name;
                string pirateOrigin = pirate.CharacterTraits.PirateOrigin.Name;
                string shipType = pirate.CharacterTraits.ShipType.Name;
                string shipSize = pirate.CharacterTraits.ShipSize.Name;
                string pet = pirate.CharacterTraits.Pet.Name;
                string crew = pirate.CharacterTraits.Crew.Name;
                string trigger = pirate.CharacterTraits.Trigger.Name;
                string debuff = pirate.CharacterTraits.Debuff.Name;
                int agility = pirate.CharacterStats.Agility;
                int charisma = pirate.CharacterStats.Charisma;
                int health = pirate.CharacterStats.Health;
                int intelligence = pirate.CharacterStats.Intelligence;
                int strength = pirate.CharacterStats.Strength;

                con.ConnOpen();
                string sql = "INSERT INTO characterInformation VALUES " +
                    "(@characterName, @moonCycle, @form, @pirateCode, @mainWeapon, @secondarySkill, @natureSkill, " +
                    "@additionalSkill, @physicalTrademark, @skinTone, @hairStyle, @facialHair, @baseClothing, " +
                    "@accessory, @pirateOrigin, @shipType, @shipSize, @pet, @crew, @trigger, @debuff, " +
                    "@agility, @charisma, @health, @intelligence, @strength)";

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
                    cmd.Parameters.AddWithValue("@agility", agility);
                    cmd.Parameters.AddWithValue("@charisma", charisma);
                    cmd.Parameters.AddWithValue("@health", health);
                    cmd.Parameters.AddWithValue("@intelligence", intelligence);
                    cmd.Parameters.AddWithValue("@strength", strength);

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
        // DELETE character from SQL
        public static void RemoveFromSQLDatabase(Pirate pirate)
        {
            try
            {
                string characterName = pirate.CharacterInfo.Name;

                con.ConnOpen();
                string sql = "DELETE FROM characterInformation WHERE characterName = @characterName";

                using (MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@characterName", characterName);
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
}