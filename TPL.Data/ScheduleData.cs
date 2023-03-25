using System.Data.SqlClient;
using TPL.Model;

namespace TPL.Data
{
    public class ScheduleData
    {
        string _connectionString = string.Empty;

        public ScheduleData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Round> GetSchedule(int season)
        {
            List<Round> schedule = new List<Round>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetSchedule", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Season", season);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedule.Add(new Round
                            {
                                RoundId = (Guid)reader["RoundId"],
                                Date = Convert.ToDateTime(reader["Date"]),
                                Name = reader["RoundName"].ToString(),
                                Details = reader["Details"].ToString(),
                                Game = reader["Game"].ToString(),
                                IsMajor = reader["IsMajor"] == DBNull.Value ? false : (bool)reader["IsMajor"],
                                Course = new Course
                                {
                                    CourseId = (Guid)reader["CourseId"],
                                    Name = reader["CourseName"].ToString(),
                                    Url = reader["CourseUrl"].ToString(),
                                    Par = (int)reader["Par"],
                                    Rating = reader["Rating"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["Rating"]),
                                    Slope = reader["Slope"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Slope"])
                                },
                                BeerDuty = new Golfer
                                {
                                    GolferId = reader["BeerDutyGolferId"] == DBNull.Value ? Guid.Empty : (Guid)reader["BeerDutyGolferId"],
                                    Alias = reader["Alias"].ToString(),
                                    Name = reader["GolferName"].ToString(),
                                    Avatar = reader["Avatar"] == DBNull.Value ? null : (byte[])reader["Avatar"]
                                },
                                FoodDuty = new Golfer
                                {
                                    GolferId = reader["FoodDutyGolferId"] == DBNull.Value ? Guid.Empty : (Guid)reader["FoodDutyGolferId"],
                                    Alias = reader["FoodAlias"].ToString(),
                                    Name = reader["FoodName"].ToString(),
                                    Avatar = reader["FoodAvatar"] == DBNull.Value ? null : (byte[])reader["Avatar"]
                                }
                            });
                        }
                    }

                    connection.Close();
                }
            }

            return schedule;
        }
    }
}