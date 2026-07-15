using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Managers References")]
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    CustomerManager customerManager;

    [Header("Customer Data")]
    [SerializeField]
    Image npcPortraitImage;

    [Header("UI References")]
    [SerializeField]
    TextMeshProUGUI dialogueText;

    [SerializeField]
    Button[] responseButtons;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowCurrentCustomerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(customerManager.AllCustomersServed == true)
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
        }*/
    }

    public void HandleResponse(int responseIndex)
    {
        Debug.Log(customerManager.CurrentCustomer.CustomerName);
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
        dialogueText.text = customerManager.CurrentCustomer.DialogueText;
        npcPortraitImage.sprite = customerManager.CurrentCustomer.CustomerPortrait;

        for (int i = 0; i < responseButtons.Length; i++)
        {
            var buttonText = responseButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = customerManager.CurrentCustomer.CustomerResponses[i].text;
        }
    }
}
