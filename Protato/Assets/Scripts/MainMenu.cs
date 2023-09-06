using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startBtn;
    public Button insBtn;
    public Button quitBtn;
    
    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        insBtn.onClick.AddListener(ShowInstructions);
        quitBtn.onClick.AddListener(QuitGame);
    }

    private static void StartGame()
    {
        Debug.Log("StartGame function called");
        SceneManager.LoadScene("ChooseCharacter");
    }
    
    private static void ShowInstructions()
    {
        Debug.Log("ShowInstructions function called");
        SceneManager.LoadScene("Instructions");
    }

    private static void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
