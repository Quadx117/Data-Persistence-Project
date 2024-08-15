using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    public string CurrentPlayerName;
    public int CurrentPlayerBestScore;

    public string BestScorePlayerName;
    public int BestScore;

    public string GetBestScoreString()
    {
        string bestScorePlayerName = string.IsNullOrWhiteSpace(BestScorePlayerName)
                                         ? ""
                                         : $" ({BestScorePlayerName})";
        return $"Best Score: {BestScore}{bestScorePlayerName}";
    }

    public void SaveBestScore()
    {
        SaveData data = new()
        {
            BestScore = BestScore,
            BestScorePlayerName = BestScorePlayerName,
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = $"{Application.persistentDataPath}/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScorePlayerName = data.BestScorePlayerName;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [System.Serializable]
    private class SaveData
    {
        public string BestScorePlayerName;
        public int BestScore;
    }
}
