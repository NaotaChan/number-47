using UnityEngine;
using TMPro;
using UnityEngine.UI;
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

    [Header("Customer Data")]
    [SerializeField]
    Image npcPortraitImage;

    [Header("UI References")]
    [SerializeField]
    TextMeshProUGUI dialogueText;

    [SerializeField]
    Button[] responseButtons;

    private Coroutine typingCoroutine;
    private bool isTyping;

    void Start()
    {
        responseManager.Hide();
        ShowCurrentCustomerDialogue();
    }

    void Update()
    {
        
    }

    public void HandleResponse(int responseIndex)
    {
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
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        
        typingCoroutine = StartCoroutine(TypeDialogue(customerManager.CurrentCustomer));
    }

    IEnumerator TypeDialogue(CustomerData customer)
    {
        isTyping = true;
        responseManager.Hide();
        dialogueText.text = "";

        portraitManager.SetPortrait(customer.CustomerPortrait);
        Coroutine animCoroutine = StartCoroutine(portraitManager.PlayAnimation(customer));

        string fullText = customer.DialogueText;
        foreach (char c in fullText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        StopCoroutine(animCoroutine);
        portraitManager.SetPortrait(customer.animationFrames[0]);

        responseManager.SetButtons(customer.CustomerResponses);
        StartCoroutine(responseManager.FadeIn());

        isTyping = false; 
    }
}