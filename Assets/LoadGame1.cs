using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame1: MonoBehaviour {
    public GameObject TransitionPanel;

    public void load() {
        StartCoroutine("FadeAndLoad");
    }

    public IEnumerator FadeAndLoad() {
        TransitionPanel.SetActive(true);
        Color c = TransitionPanel.GetComponent<Image>().color;
        c = Color.black;
        c.a = 0.0f;
        for (float f = 1f; f >= 0; f -= 0.1f) {
            c.a = 1 - f;
            TransitionPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        c.a = 1.0f;
        TransitionPanel.GetComponent<Image>().color = c;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Game1");
    }

}
