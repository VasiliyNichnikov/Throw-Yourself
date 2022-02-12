using UnityEngine;

public static class WorkingWithPlayerPrefs
{
    public static void SaveData(string key, object param)
    {
        switch (param)
        {
            case float numberFloat:
                PlayerPrefs.SetFloat(key, numberFloat);
                break;
            case int numberInt:
                PlayerPrefs.SetInt(key, numberInt);
                break;
            case string str:
                PlayerPrefs.SetString(key, str);
                break;
        }
    }

    public static float GetDataFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public static int GetDataInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static string GetDataString(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}