using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("Managers References")]
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    CustomerManager customerManager;

    [Header("New System References")] 
    [SerializeField]
    PortraitAnimationManager portraitManager;

    [SerializeField]
    ResponseManager responseManager;

    [Header("UI References")]
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    TextMeshProUGUI customerName;

    [Header("Counter")]
    [SerializeField]
    CustomerCounterUI customerCounterUI;
    


    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private bool isSpeedingUp = false;

    void Start()
    {
        responseManager.Hide();
        ShowCurrentCustomerDialogue();
    }

    void Update()
    {
        CheckSpeedUpInput();
    }

    private void CheckSpeedUpInput()
    {
        isSpeedingUp = Input.GetMouseButton(0);
        
    }
    public void HandleResponse(int responseIndex)
    {
        gameManager.MentalStateSystem.ModifyStress(customerManager.CurrentCustomer.CustomerResponses[responseIndex].stressEffect);
        customerManager.NextCustomer();
        customerCounterUI.UpdateCounter();

        if(customerManager.AllCustomersServed == true)
        {
            Debug.Log($"Tutti i clienti serviti. Totale in lista: {customerManager.TotalCustomers}, indice attuale: {customerManager.CurrentCustomerIndex}");
            customerName.text = "";
            dialogueText.text = "";
            return;
        }
        else
        {
            ShowCurrentCustomerDialogue();
        }
    } 
    
    void ShowCurrentCustomerDialogue()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        
        typingCoroutine = StartCoroutine(TypeDialogue(customerManager.CurrentCustomer));
    }

    IEnumerator TypeDialogue(CustomerData customer)
    {
        isTyping = true;
        responseManager.Hide();
        dialogueText.text = "";

        customerName.text = customer.CustomerName;

        portraitManager.SetPortrait(customer.CustomerPortrait);
        Coroutine animCoroutine = StartCoroutine(portraitManager.PlayAnimation(customer));

        string fullText = customer.DialogueText;
        foreach (char c in fullText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(isSpeedingUp ? 0.01f : 0.05f);            
        }

        StopCoroutine(animCoroutine);
        portraitManager.SetPortrait(customer.CustomerPortrait);

        responseManager.SetButtons(customer.CustomerResponses);
        StartCoroutine(responseManager.FadeIn());

        isTyping = false; 
    }
}