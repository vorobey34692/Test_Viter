using UnityEngine;

public static class Saver
{
    public static void Save(string nameValue, float value)
    {
        PlayerPrefs.SetFloat(nameValue, value);
        PlayerPrefs.Save();
    }

    public static float Load(string nameValue)
    {
        return PlayerPrefs.GetFloat(nameValue);
    }
}