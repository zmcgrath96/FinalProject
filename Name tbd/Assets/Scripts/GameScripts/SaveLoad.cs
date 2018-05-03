using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEditor;

public static class SaveLoad {

    public static List<string> leaderboard;


    private static string path = Application.persistentDataPath + "/leaderboard.txt";


    /* Save
     * @param List<string>
     * @return none
     * Takes in a list of strings with values to write to file
     */
    public static void Save(List<string> stats)
    {
        try
        {
            leaderboard = stats;

            StreamWriter file = new StreamWriter(path, false);

            foreach (string stat in leaderboard) file.WriteLine(stat);


            file.Close();

            //AssetDatabase.ImportAsset(path);

        }
        catch (System.Exception e)
        {
            Debug.Log("Error thrown from SaveLoad Save(): " +e);
        }

    }


    /* Load
     * @param none
     * @return List<string>
     * Reads a file, makes it a list of strings and returns that list
     */
    public static List<string> Load()
    {
        leaderboard = new List<string>();
        try
        {
            StreamReader file = new StreamReader(path);
            string line = file.ReadLine();
            while (line != null)
            {
                leaderboard.Add(line);
                line = file.ReadLine();
            }
        }
        catch(System.Exception e)
        {
            Debug.Log("Thrown from SaveLoad Load(): "+e);
        }
        return leaderboard;
    }
}
