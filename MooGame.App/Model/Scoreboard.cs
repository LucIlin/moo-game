// MooGame.App/Scoreboard.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MooGame.App.Model;

namespace MooGame.App
{
    /// <summary>
    /// Persists each game as a CSV row: When (ISO8601), PlayerName (escaped), Guesses (int).
    /// Aggregates to Player objects when printing. Lower average guesses ranks higher.
    /// </summary>
    public sealed class Scoreboard
    {
        private readonly string _path;
        private readonly Encoding _encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        public Scoreboard(string path = "data/scoreboard.csv")
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path is required.", nameof(path));
            _path = path;
        }

        /// <summary>
        /// Append one finished game. Only writes to the file; aggregation happens when printing.
        /// </summary>
        public void WriteResult(string playerName, int guesses)
        {
            if (string.IsNullOrWhiteSpace(playerName)) throw new ArgumentException("Player name is required.", nameof(playerName));
            if (guesses < 0) throw new ArgumentOutOfRangeException(nameof(guesses), "Guesses must be >= 0.");

            var directory = Path.GetDirectoryName(Path.GetFullPath(_path));
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var line = string.Join(",",
                DateTimeOffset.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                EscapeCsv(playerName.Trim()),
                guesses.ToString(CultureInfo.InvariantCulture));

            File.AppendAllText(_path, line + Environment.NewLine, _encoding);
        }

        /// <summary>
        /// Reads the CSV and aggregates to Player objects.
        /// </summary>
        public IReadOnlyList<Player> GetPlayers()
        {
            var players = new Dictionary<string, Player>(StringComparer.OrdinalIgnoreCase);

            if (!File.Exists(_path))
                return players.Values.ToList();

            foreach (var line in File.ReadLines(_path, _encoding))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = SplitCsv(line).ToArray();
                if (parts.Length != 3) continue;

                // parts[0] = timestamp (ignored if invalid)
                // parts[1] = name
                // parts[2] = guesses
                if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out var guesses))
                    continue;

                var name = parts[1].Trim();
                if (name.Length == 0) continue;

                if (players.TryGetValue(name, out var p))
                {
                    p.Update(guesses);
                }
                else
                {
                    players[name] = new Player(name, guesses);
                }
            }

            return players.Values.ToList();
        }

        /// <summary>
        /// Prints the scoreboard to the console (freshly loaded from file).
        /// Sorted by Average ascending, then by NumberOfGames descending, then by Name.
        /// </summary>
        public void Print(int top = 10)
        {
            var data = GetPlayers()
                .OrderBy(p => p.Average())
                .ThenByDescending(p => p.NumberOfGames)
                .ThenBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                .Take(top > 0 ? top : int.MaxValue)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("=== SCOREBOARD (lower average guesses is better) ===");

            if (data.Count == 0)
            {
                Console.WriteLine("No results yet. Play a game to create the first score!");
                Console.WriteLine();
                return;
            }

            int rankWidth  = data.Count.ToString().Length;
            int nameWidth  = Math.Clamp(data.Max(p => p.Name.Length), 8, 22);
            int gamesWidth = Math.Max(5, data.Max(p => p.NumberOfGames.ToString().Length));
            const int avgWidth = 7;

            Console.WriteLine($"{Pad("#", rankWidth)}  {Pad("Player", nameWidth)}  {PadLeft("Games", gamesWidth)}  {PadLeft("Avg", avgWidth)}");
            Console.WriteLine(new string('-', rankWidth + 2 + nameWidth + 2 + gamesWidth + 2 + avgWidth));

            int rank = 1;
            foreach (var p in data)
            {
                Console.WriteLine(
                    $"{Pad(rank.ToString(), rankWidth)}  " +
                    $"{Pad(p.Name, nameWidth)}  " +
                    $"{PadLeft(p.NumberOfGames.ToString(), gamesWidth)}  " +
                    $"{PadLeft(p.Average().ToString("0.00", CultureInfo.InvariantCulture), avgWidth)}");
                rank++;
            }

            Console.WriteLine();
        }
        
        private static string EscapeCsv(string s)
        {
            if (s.Contains('"') || s.Contains(',') || s.Contains('\n') || s.Contains('\r'))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        private static IEnumerable<string> SplitCsv(string line)
        {
            var sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"'); i++; 
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            yield return sb.ToString();
        }
        
        private static string Pad(string s, int width)     => s.Length >= width ? s[..width] : s + new string(' ', width - s.Length);
        private static string PadLeft(string s, int width) => s.Length >= width ? s : new string(' ', width - s.Length) + s;
    }
}
