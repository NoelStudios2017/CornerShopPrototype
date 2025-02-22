using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private float money=5;
    private int karma=3;
    private int supplies=3;

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI karmaText;
    [SerializeField] TextMeshProUGUI suppliesText;
    [SerializeField] GameObject badEnding;
    [SerializeField] GameObject goodEnding;
    [SerializeField] GameObject middleEnding;
    public GameObject dialogueServingCustomers;
    GameObject newCust;
    public int day;
    //bool that stops customers from going into the isServed area.
    public bool isServingCustomer = false;
    //clearing the is served area bool.
    public bool customerSeved = false;
    //List of spawned active customers.
    public List<GameObject> activeCustomers = new List<GameObject>();
    //Array of customers that I have defined so can be a thief, a honest customer, one that wants to pay next week.
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
        WinGame();
        LostByKarma();
        MiddleEnding();
        UpdateUI();
        //if(customerSeved)
        //{
        //    StopAllCustomers();
        //}

    }


    //private void StopAllCustomers()
    //{
    //    foreach (GameObject cust in activeCustomers)
    //    {
    //        CustomerMovement customerMovement = cust.GetComponent<CustomerMovement>();
    //        if (customerMovement != null)
    //        {
    //            customerMovement.isMoving = false;
    //        }
    //    }

    //}

    //method to update the ui.
    public void UpdateUI()
    {
        moneyText.text = "Money:£ " + money.ToString();
        karmaText.text = "Karma: " + karma.ToString();
        suppliesText.text = "Supplies: " + supplies.ToString();
    }

    //Methods to remove from resources in dialogue and buttons responses.
    public float DeductMoney(float newMoney)
    {
        return money -= newMoney;

    }
    public float AddMoney(float newMoney)
    {
        return money += newMoney;

    }
    public int DeductKarma(int newKarma)
    {
        return karma -= newKarma;
    }
    public int AddKarma(int newKarma)
    {
        return karma += newKarma;
    }
    public int DeductSupplies(int newSupplies)
    {
        return supplies -= newSupplies;
    }

    //Methods to get the money, karma and supplies if needed anywhere in other scripts.
    public float GetMoney()
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
        //clear the list of old stuff replace it with new.
        activeCustomers.Clear();

        for (int i = 0; i < day + 1; i++)
        {
            newCust = Instantiate(customers[UnityEngine.Random.Range(0, customers.Length)], shopEntrance);
            activeCustomers.Add(newCust);
        }

    }

    //some sort of function that UI can use for 
    public void CustomerServed()
    {
        foreach (GameObject cust in activeCustomers)
        {
            CustomerMovement customerMovement = cust.GetComponent<CustomerMovement>();
            if (customerMovement != null && customerMovement.inPositionToBeServed)
            {
                //turn the customer off as he has been served.
                cust.SetActive(false);
                AddMoney(+0.2f);
                DeductSupplies(1);
                AddKarma(+1);
                UpdateUI();
                //clear the customer toggle for when respawning customers.
                customerMovement.inPositionToBeServed = false;
                //release the customer from the block
                isServingCustomer = false;
                //remove them from list.
                activeCustomers.Remove(cust);
                //get out of the foreach loop. 
                break;
            }
        }
    }
    public void DontServeCustomer()
    {
        foreach (GameObject cust in activeCustomers)
        {
            CustomerMovement customerMovement = cust.GetComponent<CustomerMovement>();
            if (customerMovement != null && customerMovement.inPositionToBeServed)
            {
                //turn the customer off as he has been served.
                cust.SetActive(false);
                DeductKarma(1);
                UpdateUI();
                //clear the customer toggle for when respawning customers.
                customerMovement.inPositionToBeServed = false;
                //release the customer from the block
                isServingCustomer = false;
                //remove them from list.
                activeCustomers.Remove(cust);
                //get out of the foreach loop. 
                break;
            }
        }
    }
    public void WinGame()
    {
        if(karma>=6)
        {
            goodEnding.SetActive(true);
        }
    }
    public void LostByKarma()
    {
        if(karma<=0)
        {
            badEnding.SetActive(true);
        }

    }
    public void MiddleEnding()
    {
        if (money>=5.2 && karma >1)
        {
            middleEnding.SetActive(true);
        }
    }

}
