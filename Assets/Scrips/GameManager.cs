using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] string SceneToChange;
    [SerializeField] GameObject popUp;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;

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
