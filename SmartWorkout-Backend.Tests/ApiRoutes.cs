using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout_Backend.Tests
{
    public static class ApiRoutes
    {
        private static readonly string _baseUrl = "https://localhost:7263/api/v1/";

        public static class Users
        {
            private static readonly string _usersControllerUrl = string.Concat(_baseUrl, "User");
            public static readonly string GetAllUsers = _usersControllerUrl;
            public static readonly string SaveUser = _usersControllerUrl;
            public static readonly string Authenticate = string.Concat(_usersControllerUrl, "/Authenticate");
            public static readonly string GetUserById = string.Concat(_usersControllerUrl, "/1");
        }

        public static class Exercise
        {
            private static readonly string _exerciseControllerUrl = string.Concat(_baseUrl, "Exercise");
            public static readonly string GetAllExercises = _exerciseControllerUrl;
            public static readonly string GetExerciseById = string.Concat(_exerciseControllerUrl, "/1");
            public static readonly string GetFavoriteById = string.Concat(_exerciseControllerUrl, "/Favorite/User/1");
            public static readonly string GetRecommendById = string.Concat(_exerciseControllerUrl, "/Recommend/User/1");
        }

        public static class Dumbbell
        {
            private static readonly string _DumbbellControllerUrl = string.Concat(_baseUrl, "Dumbbell");
            public static readonly string GetAllDumbbell = _DumbbellControllerUrl;
            public static readonly string GetDumbbellById = string.Concat(_DumbbellControllerUrl, "/1");
        }

        public static class ExerciseMonitor
        {
            private static readonly string _ExerciseMonitorControllerUrl = string.Concat(_baseUrl, "ExerciseMonitor");
            public static readonly string GetAllExerciseMonitorsByUserId = string.Concat(_ExerciseMonitorControllerUrl, "/User/1");
            public static readonly string GetExerciseMonitorId = string.Concat(_ExerciseMonitorControllerUrl, "/1");
        }
    }
}
