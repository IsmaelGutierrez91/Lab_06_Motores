using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        popUp.SetActive(false);
    }
    public void PauseGame()
    {
        popUp.SetActive(true);
        Time.timeScale = 0f;
    }
}
