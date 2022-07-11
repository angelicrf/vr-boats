using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSplash : MonoBehaviour
{
    public GameObject sliderObj;
    private bool isLoaded = false;
    void FixedUpdate()
    {
        LoadSplashScene();
    }
    private void LoadSplashScene()
    {

        if (sliderObj.GetComponent<Scrollbar>().value <= 1)
        {
            sliderObj.GetComponent<Scrollbar>().value += gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime * 0.0042f;
        }
        if (sliderObj.GetComponent<Scrollbar>().value > 1 && !isLoaded)
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
        Debug.Log("isLoaded");
        SceneManager.LoadScene("BoatScene", LoadSceneMode.Additive);
        yield return null;
        SceneManager.UnloadSceneAsync("SplashScene");
    }
}
