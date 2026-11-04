using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Models
{
    internal class VaultStats
    {
        public HashSet<string> BreachedPasswords { get; private set; } = new HashSet<string>();

        // password, entry
        public Dictionary<string, List<PasswordEntry>> PasswordMap { get; private set; } = new Dictionary<string, List<PasswordEntry>>();

        // hash prefixes (for minimizing API requests)
        public HashSet<string> HashPrefixes { get; private set; } = new HashSet<string>();

        public void AddEntry(PasswordEntry entry)
        {
            PasswordMap[entry.Password!].Add(entry);
            HashPrefixes.Add(entry.HashString.AsSpan(0, 5).ToString());
        }

        public void AddBreachedPassword(string password)
        {
            BreachedPasswords.Add(password);
        }

        public List<PasswordEntry> GetBreachedEntries()
        {
            List<PasswordEntry> result = new List<PasswordEntry>();

            foreach(string breachedPassword in BreachedPasswords)
            {
                result.AddRange(PasswordMap[breachedPassword]);
            }

            return result;
        }

        public List<PasswordEntry> GetDuplicateEntries()
        {
            List<PasswordEntry> result = new List<PasswordEntry>();

            foreach (string breachedPassword in BreachedPasswords)
            {
                if(PasswordMap[breachedPassword].Count > 1)
                {
                    result.AddRange(PasswordMap[breachedPassword]);
                }
            }

            return result;
        }
    }
}
