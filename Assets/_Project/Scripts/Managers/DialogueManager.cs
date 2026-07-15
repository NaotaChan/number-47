using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    CustomerManager customerManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (CustomerResponse response in customerManager.CurrentCustomer.CustomerResponses)
        {
            Debug.Log(response.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
