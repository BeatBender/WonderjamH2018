using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using TMPro; // Add the TextMesh Pro namespace to access the various functions.



public class MenuPrincipal : MonoBehaviour {

    public Slider loadingSlider;

//    public TextMeshProUGUI progressText;

    public void Zone1() {
        LoadLevel(1);

        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().ChangeMusic("Musique2", .05f, 1f);
        }
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

  //          progressText.text = progress * 100f + "%";
 

            yield return null;
        }

    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
