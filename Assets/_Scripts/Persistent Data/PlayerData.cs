using UnityEngine;

public class PlayerData : MonoBehaviour {
    public static PlayerData instance = null;

    //private int highscore;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        if (Application.isPlaying) {
            DontDestroyOnLoad(this.gameObject);
        }

        LoadPlayer();
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PersistentPlayerData data = SaveSystem.LoadPlayer();

        if (data != null) {
            //highscore = data.highscore;
        }
        else {
            //If save file doesn't exist, set default values and create it
            //TODO:add control mechanism for existing save file
            SetDefault();
            SavePlayer();
        }
    }

    public void SetDefault() {
        //highscore = 0;
        SavePlayer();
    }

    //#region Highscore
    //public int GetHighscore() { return highscore; }
    //public void SetHighscore(int value) { highscore = value; SavePlayer(); }
    //#endregion
}
