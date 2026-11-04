using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

// GET https://api.pwnedpasswords.com/range/{first 5 SHA-1 chars}

namespace PasswordBreachChecker.Services
{
    internal class HaveIBeenPwnedService : IPasswordBreachCheckService
    {
        private const string BaseURL = "https://api.pwnedpasswords.com/range/";

        public async Task<Dictionary<string, int>> GetBreachedHashes(string hashPrefix)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(BaseURL)
            };

            string response = await client.GetStringAsync(hashPrefix);
            string[] lines = response.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                result.Add(parts[0], int.Parse(parts[1]));
            }

            return result;
        }
    }
}
