using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEModel
{
    public class DBHelper
    {

        public static void Update()
        {
            UpdateSkills();
            UpdateOres();
            UpdateStructureEfficiencyModifiers();
        }

        public static void UpdateSkills()
        {
            SDEEntities SDE = new SDEEntities();

            SQL("TRUNCATE TABLE skills");

            foreach (invType type in SDE.invTypes)
            {

                if(type.TopmostMarketGroup != null && type.TopmostMarketGroup.marketGroupName == "Skills")
                {
                    int rank = SDE.GetAttribute(type.typeID, 275).First().IntOrFloatValue;
                    int primaryAttr = SDE.GetAttribute(type.typeID, 180).First().IntOrFloatValue - 164;
                    int secondaryAttr = SDE.GetAttribute(type.typeID, 181).First().IntOrFloatValue - 164;
                    SQL("INSERT INTO [dbo].[skills] ([typeId], [typeName], [rank], [primaryAttr], [secondaryAttr]) VALUES (" + type.typeID + ", \'" + type.typeName + "\', " + rank + ", " + primaryAttr + ", " + secondaryAttr + ")");
                    
                }

            }
            
        }

        public static void UpdateStructureEfficiencyModifiers()
        {

        }

        public static void UpdateOres()
        {
            SDEEntities SDE = new SDEEntities();

            SQL("TRUNCATE TABLE ore");

            foreach (invType type in SDE.invTypes)
            {

                if (type.invMarketGroup != null && type.invMarketGroup.parent != null && type.invMarketGroup.parent.marketGroupName == "Standard Ores" && type.typeName.StartsWith("Compressed"))
                {
                    var types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Tritanium");
                    int Tritanium = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Pyerite");
                    int Pyerite = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Mexallon");
                    int Mexallon = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Isogen");
                    int Isogen = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Nocxium");
                    int Nocxium = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Zydrine");
                    int Zydrine = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Megacyte");
                    int Megacyte = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;

                    types = type.invTypeMaterials.Where(x => x.materialType.typeName == "Morphite");
                    int Morphite = types.Count() > 0 ? types.First().quantity.GetValueOrDefault() : 0;
                    

                    SQL(String.Format("INSERT INTO [dbo].[ore] ([typeID], [name], [Tritanium], [Pyerite], [Mexallon], [Isogen], [Nocxium], [Zydrine], [Megacyte], [Morphite]) " +
                        "VALUES (" + type.typeID + ", \'" + type.typeName + "\', " +
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", Tritanium, Pyerite, Mexallon, Isogen, Nocxium, Zydrine, Megacyte, Morphite));


                }

            }

        }
        public static void SQL(string queryString)
        {

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                          Integrated Security=true;
                          AttachDbFilename=E:\Users\jimne\Desktop\Visual Studio Projects\Eve Desktop\EVE\SDE.mdf;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
