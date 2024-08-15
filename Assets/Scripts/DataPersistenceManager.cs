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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
