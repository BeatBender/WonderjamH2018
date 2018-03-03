using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPrincipal : MonoBehaviour {

    public Slider loadingSlider;
    

    public void Zone1() {
        LoadLevel(1);
    }

    public void DemoEnnemi() {
        LoadLevel(2);
    }

    public void LoadLevel(int sceneIndex) {

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingSlider.gameObject.SetActive(true);

        while (!operation.isDone) {

            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
          

            yield return null;
        }

    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
