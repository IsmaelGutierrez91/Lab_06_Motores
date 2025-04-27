using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] string SceneToChange;
    [SerializeField] GameObject popUp;
    private void Awake()
    {
        popUp.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneToChange);
    }
    private void OnEnable()
    {
        PlayerController.OnReachGoal += NextLevel;
    }
    private void OnDisable()
    {
        PlayerController.OnReachGoal -= NextLevel;
    }
}
