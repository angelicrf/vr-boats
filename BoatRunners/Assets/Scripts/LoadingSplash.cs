using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSplash : MonoBehaviour
{
    public GameObject sliderObj;
    public GameObject splashcam;
    public GameObject splashAnim;
    public GameObject splashPlayer;
    private bool isLoaded = false;
    private bool isTransited = false;
    void FixedUpdate()
    {
        LoadSplashScene();
    }
    private void LoadSplashScene()
    {

        if (sliderObj.GetComponent<Slider>().value <= sliderObj.GetComponent<Slider>().maxValue)
        {
            sliderObj.GetComponent<Slider>().value += splashAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime * 0.042f;
        }
        if (sliderObj.GetComponent<Slider>().value == sliderObj.GetComponent<Slider>().maxValue && !isLoaded)
        {
            isLoaded = true;
        }
        if (isLoaded)
        {
            StartCoroutine(SceneSwitch());
        }
    }
    private IEnumerator SceneSwitch()
    {
        if (!isTransited)
        {
            SceneManager.LoadScene("BoatScene");
            splashPlayer.SetActive(false);
            if (!splashPlayer.activeSelf)
            {
                isTransited = true;
            }
        }
        yield return new WaitUntil(() => isTransited);
        SceneManager.UnloadSceneAsync("SplashScene");
    }
}
