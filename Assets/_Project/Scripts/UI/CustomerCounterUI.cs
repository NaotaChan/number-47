using UnityEngine;
using TMPro;

public class CustomerCounterUI : MonoBehaviour
{
        [SerializeField]
    private CustomerManager customerManager;

    [SerializeField]
    private TextMeshProUGUI counterText;

    void Start()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        counterText.text = $"{customerManager.CustomersServed}\n ________ \n {customerManager.TotalCustomers}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
