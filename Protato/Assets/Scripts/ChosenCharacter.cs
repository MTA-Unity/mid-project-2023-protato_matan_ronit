using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChosenCharacter : MonoBehaviour
{
    [SerializeField] private Button speedyBtn;
    [SerializeField] private Button tankyBtn;
    [SerializeField] private Button startBtn;

    public Color normalColor = Color.black;      // The normal color of the button
    public Color highlightColor = Color.yellow;  // The highlight

    public static int _chosen;

    private void Start()
    {
        speedyBtn.onClick.AddListener(highlightSpeedy);
        tankyBtn.onClick.AddListener(highlightTanky);
        startBtn.onClick.AddListener(startGame);
    }


    private void highlightSpeedy()
    {
        _chosen = 0;
        var outlinePressed = speedyBtn.GetComponent<Outline>();
        var outlineCancel = tankyBtn.GetComponent<Outline>();
        outlinePressed.effectColor = highlightColor;
        outlineCancel.effectColor = normalColor;
    }
    
    private void highlightTanky()
    {
        _chosen = 1;
        var outlinePressed = tankyBtn.GetComponent<Outline>();
        var outlineCancel = speedyBtn.GetComponent<Outline>();
        outlinePressed.effectColor = highlightColor;
        outlineCancel.effectColor = normalColor;
    }

    private void startGame()
    {
        Debug.Log("starting game");
        SceneManager.LoadScene("Gameplay");
    }
}
