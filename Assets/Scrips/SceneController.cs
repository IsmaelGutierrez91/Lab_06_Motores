using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Color fadeInColor;
    [SerializeField] private float fadeInTime;
    [SerializeField] private Color fadeOutColor;
    [SerializeField] private float fadeOutTime;

    public static SceneController Instance { get; private set; }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void Start()
    {
        CallFadeIn();
    }
    public void CallFadeIn()
    {
        StartCoroutine(FadeTranstition(fadeInTime, fadeOutColor, fadeInColor));
    }
    public void CallFadeOut()
    {
        StartCoroutine(FadeTranstition(fadeOutTime, fadeInColor, fadeOutColor));
    }
    public void CallFadeTransition()
    {
        StartCoroutine(FadeTranstition(fadeOutTime, fadeInColor, fadeOutColor));

        StartCoroutine(FadeTranstition(fadeInTime, fadeOutColor, fadeInColor, fadeOutTime * 1.25f));
    }
    IEnumerator FadeTranstition(float fadeTime, Color currentColor, Color targetColor, float waitTime = 0f)
    {
        yield return new WaitForSeconds(waitTime);
        float _time = 0;
        fadeImage.color = currentColor;
        while(_time < fadeTime)
        {
            _time += Time.deltaTime;
            float _value = _time / fadeTime;
            fadeImage.color = Color.Lerp(currentColor, targetColor, _value);
            yield return null;
        }
        fadeImage.color = targetColor;
    }
}
