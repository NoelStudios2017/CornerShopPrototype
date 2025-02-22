using System;
using System.Collections.Generic;
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
    public GameObject dialogueServingCustomers;
    GameObject newCust;
    public int day;
    public bool isServingCustomer = false;
    public bool customerSeved=false;
    public List<GameObject> activeCustomers = new List<GameObject>();
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
        //clear the list of old stuff replace it with new.
        activeCustomers.Clear();

        for(int i=0;i<day+1;i++)
        {
          newCust = Instantiate(customers[UnityEngine.Random.Range(0,customers.Length)], shopEntrance);
          activeCustomers.Add(newCust);
        }

    }

    //some sort of function that UI can use for 
    public void CustomerServed()
    {
        foreach (GameObject cust in activeCustomers)
        {
            CustomerMovement customerMovement = cust.GetComponent<CustomerMovement>();
            if (customerMovement != null && customerMovement.isServed)
            {
                cust.SetActive(false);
                customerMovement.isServed = false;
                isServingCustomer = false;
                activeCustomers.Remove(cust);
                break;
            }
        }
    }
}
