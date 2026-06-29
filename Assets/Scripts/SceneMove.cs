using UnityEngine;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public Image fadeImage;
    public int nextSceneNumber;

    public void Start()
    {
        StartCoroutine(FadeManager.instance.FadeIn(fadeImage));
    }
    public void Scene()
    {
        StartCoroutine(FadeManager.instance.FadeOut(fadeImage,nextSceneNumber));
    }
}