using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("Static Instance")]
    public static LoadingScreenManager instance;

    [Header("Spinning Circle")]
    public RectTransform imgRect;
    public float rotateSpeed = -200f;

    [Header("Loading Texts")]
    public string[] loadingTexts;
    public Text loadingTextDisplay;

    [SerializeField]
    public string WhichScene;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Kick off the LoadingTexts function
        StartCoroutine(ShowLoadingTexts());
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the Circle Spinner
        imgRect.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    public IEnumerator ShowLoadingTexts()
    {
        //Loop through the texts and show each one, then
        //pause for 3 seconds
        for (int i = 0; i < loadingTexts.Length; i++)
        {
            loadingTextDisplay.text = loadingTexts[i];
            yield return new WaitForSeconds(3f);
        }

        Debug.Log("Loading the Main Menu");
        //Then load the main player lobby
        StartCoroutine(LoadScene(WhichScene));
    }

    public IEnumerator LoadScene(string newScene)
    {
        //For now we will wait a short bit.  Later this will work out how much
        //longer we need to wait.
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(WhichScene);
    }
}
