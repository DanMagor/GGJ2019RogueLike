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
        for (float f = 1f; f >= 0; f -= 0.1f) {
            Color c = TransitionPanel.GetComponent<Image>().color;
            c.r = f;
            c.b = f;
            c.g = f;
            c.a = 1 - f;
            TransitionPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("Game1");
    }

}
