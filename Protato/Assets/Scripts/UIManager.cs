using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text pointsText;
    public TMP_Text counterText;

    [SerializeField] private HealthBar slider;

    
    public static int Health;
    public static int MaxHealth;
    public static int Money;
    
    public static double Speed;
    public static int Damage;
    
    public Button popup;
    public Button stayPopup;
    public Button leavePopup;
    
    public static float EnemyCounter;
    public static float Killcounter;
    
    public GameObject activePopup;

    public static bool IsPaused { get; private set; }
    

    private void Start()
    {
        IsPaused = false;
        var btn = popup.GetComponent<Button>();
        btn.onClick.AddListener(ShowPopup);
        var stay = stayPopup.GetComponent<Button>();
        stay.onClick.AddListener(ClosePopup);
        var leave = leavePopup.GetComponent<Button>();
        leave.onClick.AddListener(LeaveGame);
    }

    
    private void Update()
    {
        if (Store.IsStore) return;
        
        UpdateHealthText();
        UpdatePointsText();
        UpdateEnemyText();
    }

    
    private void UpdateHealthText()
    {
        livesText.text = $"{Health} HP";
        slider.SetSlider(Health);
    }

    private void UpdateEnemyText()
    {
        counterText.text = $"remaining enemies: {Killcounter}";
    }

    private void UpdatePointsText()
    {
        pointsText.text = $"{Money} $";
    }

    private void ShowPopup()
    {
        activePopup.SetActive(true);
        IsPaused = true;
    }
    
    private void ClosePopup()
    {
        activePopup.SetActive(false);
        IsPaused = false;
    }

    private void LeaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StayAndPlay()
    {
        ClosePopup();
    }
}