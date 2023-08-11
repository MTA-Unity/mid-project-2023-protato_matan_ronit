using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text pointsText;
    
    private int _health;
    private int _moeny;
    
    public Button popup;
    public Button stayPopup;
    public Button leavePopup;

    public GameObject activePopup;

    public bool IsPaused { get; private set; }


    private void Start()
    {
        UpdateHealthText();
        UpdatePointsText();
        var btn = popup.GetComponent<Button>();
        btn.onClick.AddListener(ShowPopup);
        var stay = stayPopup.GetComponent<Button>();
        stay.onClick.AddListener(ClosePopup);
        var leave = leavePopup.GetComponent<Button>();
        leave.onClick.AddListener(LeaveGame);
    }

    public void UpdateHealthText()
    {
        livesText.text = $"{_health} HP";
    }

    public void UpdatePointsText()
    {
        pointsText.text = $"{_moeny} $";
    }

    public void DecreaseLives()
    {
        _health--;
        UpdateHealthText();

        if (_health <= 0)
        {
            // Game over logic
        }
    }

    public void IncreasePoints(int amount)
    {
        _moeny += amount;
        UpdatePointsText();
    }
    
    public void ShowPopup()
    {
        Debug.Log("creating popup");
        activePopup.SetActive(true);
        IsPaused = true;  
    }
    
    public void ClosePopup()
    {
        activePopup.SetActive(false);
        IsPaused = false;
    }

    public void LeaveGame()
    {
        Debug.Log ("exit");
        SceneManager.LoadScene("MainMenu");
        
    }

    public void StayAndPlay()
    {
        Debug.Log("stay");
        ClosePopup();
        // Implement logic to continue playing
    }
}