using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour
{

    [SerializeField]
    List<CustomerData> fullCustomerList = new List<CustomerData>();

    int currentCustomerIndex = 0;
    bool allCustomerServed = false;

    [SerializeField]
    GameManager gameManager;

    //Getter
    public CustomerData CurrentCustomer { get {return fullCustomerList[currentCustomerIndex];}}
    public bool AllCustomersServed { get { return allCustomerServed; } }
    public int CurrentCustomerIndex => currentCustomerIndex;
    public int CustomersServed => currentCustomerIndex;
    public int TotalCustomers => fullCustomerList.Count;
    public int CustomersRemaining => Mathf.Max(0, TotalCustomers - CustomersServed);
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCustomer()
    {
        if (currentCustomerIndex +1 < fullCustomerList.Count)
        {
            currentCustomerIndex++;
        }
        else
        {
            allCustomerServed = true;
            Debug.Log("All customer served: " + allCustomerServed);
        }
    }
}
