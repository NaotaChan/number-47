using UnityEngine;

public class GameManager : MonoBehaviour
{

    MentalStateSystem mentalStateSystem = new MentalStateSystem();
    NarrativePhaseSystem narrativePhaseSystem = new NarrativePhaseSystem();



    //Getter
    public MentalStateSystem MentalStateSystem { get {return mentalStateSystem;}}

    void Awake()
    {
        mentalStateSystem.UpdateMentalState();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
