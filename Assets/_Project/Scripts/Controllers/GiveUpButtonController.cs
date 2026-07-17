using UnityEngine;
using UnityEngine.SceneManagement;

public class GiveUpButtonController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject giveUpButton;

    void Start()
    {
        giveUpButton.SetActive(false);
        gameManager.MentalStateSystem.OnMentalStateChanged += HandleMentalStateChanged;
    }

    void HandleMentalStateChanged(MentalStates newState)
    {
        giveUpButton.SetActive(newState == MentalStates.BREAKING);
    }

    public void GiveUp()
    {
        SceneManager.LoadScene("OutroScene");
    }
}