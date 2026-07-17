using UnityEngine;

public class GameManager : MonoBehaviour
{

    MentalStateSystem mentalStateSystem = new MentalStateSystem();
    NarrativePhasesSystem narrativePhaseSystem = new NarrativePhasesSystem();

    //Getter
    public MentalStateSystem MentalStateSystem { get {return mentalStateSystem;}}
    public NarrativePhasesSystem NarrativePhaseSystem { get {return narrativePhaseSystem;}}

    void Awake()
    {
        mentalStateSystem.UpdateMentalState();
        narrativePhaseSystem.SetPhase(NarrativePhases.Enthusiasm);
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