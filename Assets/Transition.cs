using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Transition : MonoBehaviour {
    
    public GameObject TransitionPanel;
    public GameObject NextPanel;

    public void BeginTransition() {
        StartCoroutine("StartTransition");
    }



    IEnumerator StartTransition() {
        for (float f = 0f; f <= 2; f += 0.1f) {
            Color c = TransitionPanel.GetComponent<Image>().color;
            c.a = f;
            TransitionPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        NextPanel.SetActive(true);
        for (float f = 1f; f >= 0; f -= 0.1f) {
            Color c = TransitionPanel.GetComponent<Image>().color;
            c.a = f;
            TransitionPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        TransitionPanel.SetActive(false);

    }
}
