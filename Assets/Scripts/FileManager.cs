using System;
using System.IO;
using UnityEngine;

public static class FileManager
{
    public static bool WriteToFile(string fileName, string fileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            File.WriteAllText(fullPath, fileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static string LoadFromFile(string fileName)
    {
        var result = "";
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return result;
        }
    }

    public static bool FileExists(string fileName)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        return File.Exists(fullPath);
    }
}