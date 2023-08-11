using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public Button retBtn;

    private void Start()
    {
        retBtn.onClick.AddListener(returnToMainMenu);
    }

    private static void returnToMainMenu()
    {
        Debug.Log("going to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
