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
        UIManager.Money = 1000;
        UIManager.Health = Chosen switch
        {
            0 => 150,
            1 => 250,
            _ => UIManager.Health // Use current value if none of the cases match
        };
        
        UIManager.MaxHealth = Chosen switch
        {
            0 => 150,
            1 => 250,
            _ => UIManager.MaxHealth // Use current value if none of the cases match
        };
        
        UIManager.Speed = Chosen switch
        {
            0 => 7,
            1 => 2,
            _ => UIManager.Speed // Use current value if none of the cases match
        };
        
        UIManager.Damage = Chosen switch
        {
            0 => 3,
            1 => 5,
            _ => UIManager.Damage // Use current value if none of the cases match
        };

        Debug.Log("chose UIManager.Health = " + UIManager.Health);
        Debug.Log("chose UIManager.Money = " + UIManager.Money);
        SceneManager.LoadScene("Gameplay");
    }
}
