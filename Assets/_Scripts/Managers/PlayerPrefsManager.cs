using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {
    /// <summary>
    /// Sets the vibration setting with a string.
    /// <para>"On" for vibrationOn, "Off" for vibrationOff.</para>
    /// </summary>
    public static void SetVibration(string vibrationState) {
        PlayerPrefs.SetString("vibrationState", vibrationState);
    }
    /// <summary>
    /// Returns the vibration setting as a string, compare using String.Equals.
    /// <para>"On" for vibrationOn, "Off" for vibrationOff.</para>
    /// </summary>
    public static string GetVibration() {
        if (PlayerPrefs.GetString("vibrationState") == "") {
            PlayerPrefs.SetString("vibrationState", "On");
        }
        return PlayerPrefs.GetString("vibrationState");
    }
}
