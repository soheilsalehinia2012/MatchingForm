using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleDb
{
    public static class DataAnalayser
    {
        public static List<List<User>> CreateGroups(List<User> users, int groupSize)
        {
            var orderedUsers = users.Zip(users.Select(user => user.TestResult.Sum(c => Char.GetNumericValue(c))),
                (user, d) => new {User = user, Score = d})
                .OrderBy(tuple => tuple.Score);
            var result = new List<List<User>>();
            var room = new List<User>();
            foreach (var user in orderedUsers)
            {
                room.Add(user.User);
                if (room.Count == groupSize)
                {
                    result.Add(room);
                    room = new List<User>();
                }
            }

            if (room.Count != 0)
                result.Add(room);

            return result;
        }
    }
}