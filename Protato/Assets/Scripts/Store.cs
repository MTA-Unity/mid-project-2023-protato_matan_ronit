using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public TMP_Text MoenyOwn;
    public TMP_Text HealthOwn;
    
    public Button buyHealth;
    public Button buySpeed;
    public Button buyDamage;
    public Button conBtn;

    public HealthBar HealthBar;

   

    public static bool IsStore { get; private set; }


    // Start is called before the first frame update
    private void Start()
    {
        IsStore = true;
        var Buyhealth = buyHealth.GetComponent<Button>();
        Buyhealth.onClick.AddListener(AddHealth);
        var Buyspeed = buySpeed.GetComponent<Button>();
        Buyspeed.onClick.AddListener(AddSpeed);
        var Buydamage = buyDamage.GetComponent<Button>();
        Buydamage.onClick.AddListener(AddDamage);
        var continueBtn = conBtn.GetComponent<Button>();
        continueBtn.onClick.AddListener(ContinueOnClick);
    }
    
    private void UpdateMoenyOwnText()
    {
        var money = UIManager.Money;
        MoenyOwn.text = $"{money}$";
    }
    
    private void UpdateHealthOwnText()
    {
        var health = UIManager.MaxHealth;
        HealthOwn.text = $"{health}HP";
    }
    
    private void ContinueOnClick()
    {
        IsStore = false;
        SceneManager.LoadScene("Gameplay");
    }
    private void AddSpeed()
    {
        UIManager.Speed += 0.5;
        UIManager.Money -= 100;
    }
    private void AddDamage()
    {
        UIManager.Damage += 10;
        UIManager.Money -= 100;
    }
    private void AddHealth()
    {
        UIManager.MaxHealth += 10;
        UIManager.Money -= 100;
    }
    
    private void UpdateStoreButtons()
    {
        if (UIManager.Money >= 0) return;
        
        buyHealth.interactable = false;
        buySpeed.interactable = false;
        buyDamage.interactable = false;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateStoreButtons();
        UpdateMoenyOwnText();
        UpdateHealthOwnText();
    }
}
