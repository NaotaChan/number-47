using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour
{

    [SerializeField]
    List<CustomerData> fullCustomerList = new List<CustomerData>();

    int currentCustomerIndex = 0;


    //Getter
    public CustomerData CurrentCustomer { get {return fullCustomerList[currentCustomerIndex];}}
    
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
            //TODO: finished customers
        }
    }
}
