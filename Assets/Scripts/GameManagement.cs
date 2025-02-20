using TMPro;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private int money;
    private int karma;
    private int supplies;

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI karmaText;
    [SerializeField] TextMeshProUGUI suppliesText;

    public int day = 1;
    public GameObject[] customers;
    public Transform shopEntrance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
        SpawnCustomers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to update the ui.
    public void UpdateUI()
    {
        moneyText.text = "Money: " + money.ToString() ;
        karmaText.text = "Karma: " + karma.ToString();
        suppliesText.text ="Supplies: " + supplies.ToString();
    }

    //Methods to remove from resources in dialogue and buttons responses.
    public int DeductMoney(int newMoney)
    {
        return money-=newMoney;
        
    }
    public int DeductKarma(int newKarma)
    {
        return karma-=newKarma;
    }
    public int DeductSupplies(int newSupplies)
    {
        return supplies-=newSupplies;
    }

    //Methods to get the money, karma and supplies if needed anywhere in other scripts.
    public int GetMoney()
    {
        return money;
    }
    public int GetKarma()
    {
        return karma;
    }
    public int GetSupplies()
    {
        return supplies;
    }
    public void SpawnCustomers()
    {
        foreach (GameObject cust in customers)
        {
            if(day == 1)
            {
                GameObject newCust = Instantiate(cust, shopEntrance);
            }


        }
    }
    
    //some sort of function that UI can use for 
}
