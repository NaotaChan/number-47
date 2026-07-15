using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    CustomerManager customerManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowCurrentCustomerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(customerManager.AllCustomersServed == true)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(customerManager.CurrentCustomer.CustomerResponses[0].text);

            gameManager.MentalStateSystem.ModifyStress(customerManager.CurrentCustomer.CustomerResponses[0].stressEffect);
            customerManager.NextCustomer();

            if(customerManager.AllCustomersServed == true)
            {
                return;
            }
            else
            {
                ShowCurrentCustomerDialogue();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(customerManager.CurrentCustomer.CustomerResponses[1].text);

            gameManager.MentalStateSystem.ModifyStress(customerManager.CurrentCustomer.CustomerResponses[1].stressEffect);
            customerManager.NextCustomer();

            if(customerManager.AllCustomersServed == true)
            {
                return;
            }
            else
            {
                ShowCurrentCustomerDialogue();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(customerManager.CurrentCustomer.CustomerResponses[2].text);

            gameManager.MentalStateSystem.ModifyStress(customerManager.CurrentCustomer.CustomerResponses[2].stressEffect);
            customerManager.NextCustomer();

            if(customerManager.AllCustomersServed == true)
            {
                return;
            }
            else
            {
                ShowCurrentCustomerDialogue();
            }
        }
    }

    void ShowCurrentCustomerDialogue()
    {
        foreach (CustomerResponse response in customerManager.CurrentCustomer.CustomerResponses)
        {
            Debug.Log(response.text);
        }
    }
}
