using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    private void Awake()
    {
        popUp.SetActive(false);
    }
}
