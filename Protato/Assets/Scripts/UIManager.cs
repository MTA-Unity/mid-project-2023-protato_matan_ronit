using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text pointsText;
    
    public static int Health;
    public static int Money;
    
    public Button popup;
    public Button stayPopup;
    public Button leavePopup;

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
        UpdateHealthText();
        UpdatePointsText();
    }

    public void UpdateHealthText()
    {
        livesText.text = $"{Health} HP";
    }

    public void UpdatePointsText()
    {
        pointsText.text = $"{Money} $";
    }

    public void DecreaseLives()
    {
        Health--;
        UpdateHealthText();

        if (Health <= 0)
        {
            // Game over logic
        }
    }

    public void IncreasePoints(int amount)
    {
        Money += amount;
        UpdatePointsText();
    }
    
    private void ShowPopup()
    {
        Debug.Log("creating popup");
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