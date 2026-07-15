using UnityEngine;
using System.Collections.Generic;



//Customer Response Struct
[System.Serializable]
public struct CustomerResponse 
{
    public string text;
    public int stressEffect;

}



[CreateAssetMenu(fileName = "CustomerData", menuName = "Scriptable Objects/CustomerData")]
public class CustomerData : ScriptableObject
{
    [SerializeField]
    string customerName = "Sconosciuto";

    [SerializeField]
    string dialogueText = "Place holder text";

    [SerializeField]
    List<CustomerResponse > customerResponses = new List<CustomerResponse>();

    //Getter
    public string CustomerName { get { return customerName;}}
    public string DialogueText { get {return dialogueText;}}
    public IReadOnlyList<CustomerResponse> CustomerResponses { get { return customerResponses; } }
}
