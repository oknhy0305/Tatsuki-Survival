using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI 요소")]
    public TMP_Text dialogueText;

    [Header("대사 데이터")]
    [TextArea(3,5)]
    public string[] sentences;

    [Header("출력 설정")]
    public float typingSpeed = 0.05f;

    [Header("씬 전환 설정")]
    public Image fadeImage;
    private int currentIndex = 0;
    private bool isTyping = false;
    private bool isEnding = false;
    public int nextSceneNumber;
    private Coroutine typingCoroutine;


    
    void Start()
    {
        if(fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 0f;
            fadeImage.color = color;
            fadeImage.gameObject.SetActive(false);
        }

        StartDialogue();
    }

    void Update()
    {
        if(isEnding) return;

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                FinishSentenceEarly();
            }
            else
            {
                NextDialogue();
            }
        }
    }

    public void StartDialogue()
    {
        currentIndex = 0;
        NextDialogue();
    }

    public void NextDialogue()// 다음 dialogue로
    {
        if(currentIndex >= sentences.Length)
        {
            EndDialogue();
            return;
        }

        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeSentence(sentences[currentIndex]));
        currentIndex++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        isTyping = true;

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void FinishSentenceEarly()// dialogue 한번에 출력 
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = sentences[currentIndex-1];
        isTyping = false;
    }

    void EndDialogue()//끝내기
    {
        Debug.Log("대화 종료");
        isEnding = true;
        dialogueText.text = "";
        StartCoroutine(FadeManager.instance.FadeOut(fadeImage,nextSceneNumber));
    }
}
