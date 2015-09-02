using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleDb
{
    public static class DataAnalayser
    {
        public static List<List<User>> CreateGroups(List<User> users, int groupSize)
        {
            var orderedUsers = users.Zip(users.Select(user => user.TestResult
                .Select(Char.GetNumericValue)),
                (user, d) => new { User = user, Score = d }).ToList();

            var result = new List<List<User>>();

            for (int i = orderedUsers.Count; i >= groupSize; i -= groupSize)
            {
                var user = orderedUsers[i-1];

                var distances = new List<Tuple<double, int>>();
                for (int j = 0; j < i; j++)
                    // Item1 : Distance, Item2 : User Index
                    distances.Add(Tuple.Create(user.Score
                        .Zip(orderedUsers[j].Score, (d, d1) => Math.Abs(d1 - d)).Sum(d => d), j));

                // People how the least distance with this guy, have the least distance with each other too
                var roommates = (distances.OrderBy(tuple => tuple.Item1)
                    .Take(groupSize)
                    .Select(tuple => orderedUsers[tuple.Item2])).ToList();

                foreach (var u in roommates)
                    orderedUsers.Remove(u);

                result.Add(roommates.Select(anon => anon.User).ToList());
            }

            if (orderedUsers.Any())
                result.Add(orderedUsers.Select(anon => anon.User).ToList());

            return result;
        }
    }
}