using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void StartBoatScene()
    {
        StartCoroutine(LoadBoatScene());
    }
    private IEnumerator LoadBoatScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BoatScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
