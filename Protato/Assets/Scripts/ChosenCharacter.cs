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

    public float normalOutlineSize = 0;         // The normal size of the outline
    public float highlightOutlineSize = 2;      // The highlight size of the outline

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
        SetButtonOutline(speedyBtn, highlightOutlineSize);
        SetButtonOutline(tankyBtn, normalOutlineSize); // Reset outline size of the other button
    }
    
    private void HighlightTanky()
    {
        Chosen = 1;
        SetButtonOutline(tankyBtn, highlightOutlineSize);
        SetButtonOutline(speedyBtn, normalOutlineSize); // Reset outline size of the other button
    }
    
    private void SetButtonOutline(Button button, float size)
    {
        var outline = button.GetComponent<Outline>();
        if (outline != null)
        {
            outline.effectDistance = new Vector2(size, size);
        }
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

        SceneManager.LoadScene("Gameplay");
    }
}
