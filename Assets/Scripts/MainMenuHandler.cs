#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI BestScoreText;

    public void StartNewGame()
    {
        DataPersistenceManager.Instance.CurrentPlayerBestScore = 0;
        DataPersistenceManager.Instance.CurrentPlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Start()
    {
        BestScoreText.text = DataPersistenceManager.Instance.GetBestScoreString();
    }
}
