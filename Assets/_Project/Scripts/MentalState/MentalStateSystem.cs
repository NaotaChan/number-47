using UnityEngine;
using System;



//Mental states enum
public enum MentalStates
{
    NONE,
    NORMAL,
    TIRED,
    OVERLOADED,
    BREAKING
}


public class MentalStateSystem
{
    int stressValue = 0;

    MentalStates currentState;
    
    //Getter
    public MentalStates CurrentState { get {return currentState;}}

    //Events
    public event Action<MentalStates> OnMentalStateChanged;






    public void ModifyStress (int amount)
    {
        stressValue += amount;
        stressValue = Mathf.Clamp(stressValue, 0, 100);
        UpdateMentalState();
    }

    public void UpdateMentalState()
    {
        MentalStates previousState = currentState;  //snapshot before calculations

        if (stressValue <= 25)
        {
            currentState = MentalStates.NORMAL;
        }
        else if (stressValue <= 50)
        {
            currentState = MentalStates.TIRED;

        }
        else if (stressValue <= 75)
        {
            currentState = MentalStates.OVERLOADED;
        }
        else if (stressValue <= 100)
        {
            currentState = MentalStates.BREAKING;
        }
        else
        {
            currentState = MentalStates.NONE;
        }

        if (previousState != currentState)
        {
            OnMentalStateChanged?.Invoke(currentState);
        }
    }
}
