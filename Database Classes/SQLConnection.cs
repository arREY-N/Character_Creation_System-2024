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
        public static void AddToSQLDatabase(object[] informationArray)
        {
            try
            {
                string? characterName = Convert.ToString(informationArray[0]);
                string moonCycle = Convert.ToString(((Element)informationArray[1]).Name);
                string form = Convert.ToString(((Element)informationArray[2]).Name);
                bool pirateCode = (((Element)informationArray[3]).Name) == "Yes" ? true : false;
                string mainWeapon = Convert.ToString(((Element)informationArray[4]).Name);
                string secondarySkill = Convert.ToString(((Element)informationArray[5]).Name);
                string natureSkill = Convert.ToString(((Element)informationArray[6]).Name);
                string additionalSkill = Convert.ToString(((Element)informationArray[7]).Name);
                string physicalTrademark = Convert.ToString(((Element)informationArray[8]).Name);
                string skinTone = Convert.ToString(((Element)informationArray[9]).Name);
                string hairStyle = Convert.ToString(((Element)informationArray[10]).Name);
                string facialHair = Convert.ToString(((Element)informationArray[11]).Name);
                string baseClothing = Convert.ToString(((Element)informationArray[12]).Name);
                string accessory = Convert.ToString(((Element)informationArray[13]).Name);
                string pirateOrigin = Convert.ToString(((Element)informationArray[14]).Name);
                string shipType = Convert.ToString(((Element)informationArray[15]).Name);
                string shipSize = Convert.ToString(((Element)informationArray[16]).Name);
                string pet = Convert.ToString(((Element)informationArray[17]).Name);
                string crew = Convert.ToString(((Element)informationArray[18]).Name);
                string trigger = Convert.ToString(((Element)informationArray[19]).Name);
                string debuff = Convert.ToString(((Element)informationArray[20]).Name);

                con.ConnOpen();
                string sql = "INSERT INTO characterInformation VALUES " +
                    "(@characterName, @moonCycle, @form, @pirateCode, @mainWeapon, @secondarySkill, @natureSkill, " +
                    "@additionalSkill, @physicalTrademark, @skinTone, @hairStyle, @facialHair, @baseClothing, " +
                    "@accessory, @pirateOrigin, @shipType, @shipSize, @pet, @crew, @trigger, @debuff)";

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