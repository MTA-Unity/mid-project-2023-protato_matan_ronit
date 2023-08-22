using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Button exitBtn;
    
   
    private void Start()
    {
        exitBtn.onClick.AddListener(ReturnMainMenu);
    }

    // Update is called once per frame
    private static void ReturnMainMenu()
    {
        Debug.Log("ReturnMainMenu function called");
        Rounds.RoundNumber = 3;
        SceneManager.LoadScene("MainMenu");
    }
}
