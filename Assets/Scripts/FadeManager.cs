using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            DontDestroyOnLoad(this);
            return;
        }
        instance = this;

    }

    public IEnumerator FadeOut(Image fadeImage,int sceneIndex)
    {
        float alpha = 0f;
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        while(alpha < 1f)
        {
            alpha += Time.deltaTime;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }
        
        color.a = 1f;
        fadeImage.color = color;
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator FadeIn(Image fadeImage)
    {
        float alpha = 1f;
        fadeImage.gameObject.SetActive(true);

        Color color = fadeImage.color;

        while(alpha > 0f)
        {
            alpha -= Time.deltaTime;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.gameObject.SetActive(false);

    }



}
