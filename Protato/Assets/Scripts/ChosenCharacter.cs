using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChosenCharacter : MonoBehaviour
{
    [SerializeField] private Button speedyBtn;
    [SerializeField] private Button tankyBtn;
    [SerializeField] private Button startBtn;

    public Color normalColor = Color.black;      // The normal color of the button
    public Color highlightColor = Color.yellow;  // The highlight

    public static int Chosen;

    private void Start()
    {
        speedyBtn.onClick.AddListener(HighlightSpeedy);
        tankyBtn.onClick.AddListener(HighlightTanky);
        startBtn.onClick.AddListener(StartGame);
    }


    private void HighlightSpeedy()
    {
        Chosen = 0;
        var outlinePressed = speedyBtn.GetComponent<Outline>();
        var outlineCancel = tankyBtn.GetComponent<Outline>();
        outlinePressed.effectColor = highlightColor;
        outlineCancel.effectColor = normalColor;
    }
    
    private void HighlightTanky()
    {
        Chosen = 1;
        var outlinePressed = tankyBtn.GetComponent<Outline>();
        var outlineCancel = speedyBtn.GetComponent<Outline>();
        outlinePressed.effectColor = highlightColor;
        outlineCancel.effectColor = normalColor;
    }

    private void StartGame()
    {
        Debug.Log("starting game");
        SceneManager.LoadScene("Gameplay");
    }
}
