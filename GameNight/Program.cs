/*
* Name: Phoenix Rojas
* Course: CSCI 1250, Section 001
* Assignment: Lab 08, Game Night
* Date: November 18, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";

const int MAX_POINTS = 20;
const int PAD_LENGTH = 11;

// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

string[] playerArray = File.ReadAllLines(PLAYERS_FILE);
string[] pointsArray = File.ReadAllLines(POINTS_FILE);

// Part 1: The Standings
Console.WriteLine("\n\nPLAYER".PadRight(PAD_LENGTH) + " POINTS");
// for: since we're using the index across playerArray and pointsArray
for (int i = 0; i < playerArray.Length; i++)
{
    Console.WriteLine($"{playerArray[i].PadRight(PAD_LENGTH)} {pointsArray[i]}");
}
int leadIdx = LeaderIndex(pointsArray);
Console.WriteLine($"Leader: {playerArray[leadIdx]} with {pointsArray[leadIdx]}");
Console.WriteLine($"Season total: {TotalPoints(pointsArray)}\n\n");

// Methods
static int LeaderIndex(string[] points)
{
    int index = 0;
    int highest = 0;
    // for: since we're returning the index, it needs to be tracked
    for (int i = 0; i < points.Length; i++)
    {
        int value = Convert.ToInt32(points[i]);
        if (value > highest)
        {
            highest = value;
            index = i;
        }
    }
    return index;
}

static int TotalPoints(string[] points)
{
    int sum = 0;
    // foreach: since only the values of the array are counted
    foreach (string str in points)
    {
        int value = Convert.ToInt32(str);
        sum += value;
    }
    return sum;
}

static string HistoryEntry(int night, string winner, int points)
{
    return $"Night {night}: {winner} won with {points} points";
}
