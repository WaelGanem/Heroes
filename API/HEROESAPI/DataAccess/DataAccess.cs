namespace HEROESAPI.Data
{
    using HEROESAPI.Models;
    using Microsoft.Data.SqlClient;
    using System.Data;

    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("HeroesDatabase");
        }

        public async Task<Hero> GetHeroNameById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("GetHeroNameById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@HeroId", id);

                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (!await reader.ReadAsync())  // No hero found
                            {
                                return null;  // Or throw an exception if preferred
                            }

                            else
                            {
                                return new Hero
                                {
                                    ID = (int)reader["ID"], // Assuming your column name is "ID"
                                    HERO_NAME = reader["HERO_NAME"].ToString() // Assuming ...  "HERO_NAME" 
                                };
                            }
                        }
                    }
                }

                return null; // No hero found
            }
            catch (Exception ex)
            {
                //logging
                throw ex;
            }
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetAllHeroes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var heroes = new List<Hero>();
                        while (await reader.ReadAsync())
                        {
                            heroes.Add(new Hero
                            {
                                ID = (int)reader["ID"], // Assuming your column name is "ID"
                                HERO_NAME = reader["HERO_NAME"].ToString()  // Assuming ... "HERO_NAME"
                            });
                        }
                        return heroes;
                    }
                }
            }
        }


        // TODO: Implement the GetAllHeroes method similarly 
    }
}
