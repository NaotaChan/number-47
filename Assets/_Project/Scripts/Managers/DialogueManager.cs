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
            HandleResponse(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandleResponse(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandleResponse(2);
        }
    }

    void HandleResponse(int responseIndex)
    {
        Debug.Log(customerManager.CurrentCustomer.CustomerResponses[responseIndex].text);

            gameManager.MentalStateSystem.ModifyStress(customerManager.CurrentCustomer.CustomerResponses[responseIndex].stressEffect);
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
    

    void ShowCurrentCustomerDialogue()
    {
        foreach (CustomerResponse response in customerManager.CurrentCustomer.CustomerResponses)
        {
            Debug.Log(response.text);
        }
    }
}
