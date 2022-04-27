using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScoreSaver : MonoBehaviour
{
    public static BestScoreSaver instance;

    public string playerName;
    public int bestScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;
            bestScore = data.score;
        }
    }
}
