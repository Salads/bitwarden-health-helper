using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

// GET https://api.pwnedpasswords.com/range/{first 5 SHA-1 chars}

namespace PasswordBreachChecker.Services
{
    internal class HaveIBeenPwnedService : IPasswordBreachCheckService
    {
        private const string BaseURL = "https://api.pwnedpasswords.com/range/";

        private HttpClient m_client = new();

        public HaveIBeenPwnedService()
        {
            m_client.BaseAddress = new Uri(BaseURL);
        }

        public async Task<Dictionary<string, int>> GetBreachedHashes(string hashPrefix)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

#if DEBUG_MOCK
            string response = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "MockData", "mockapiresult.txt"));
#else
            string response = await m_client.GetStringAsync(hashPrefix);
#endif

            string[] lines = response.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                result.Add(string.Format("{0}{1}", hashPrefix, parts[0]), int.Parse(parts[1]));
            }

            return result;
        }
    }
}
