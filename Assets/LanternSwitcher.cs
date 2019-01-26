using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanternSwitcher : MonoBehaviour
{

    public float batteryCharge = 99;
    public TextMeshProUGUI batteryText;
    public float depletionRate = 5;
    public float rechargeRate = 10;
    public Scrollbar batteryScrollbar;
    public Color emptyColor, fullColor;


    public bool LightIsOn()
    {
        return flashlight.activeSelf;
    }

    void Start()
    {
        flashlight = transform.Find("Flashlight").gameObject;
        lightnessHighlight = transform.Find("LightnessHighlight").gameObject;
        darknessHighlight = transform.Find("DarknessHighlight").gameObject;
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        var point = Camera.main.ScreenToWorldPoint(
          new Vector3(mousePos.x, mousePos.y, 10));
        flashlight.transform.LookAt(point);

        if ( flashlight.activeSelf )
        {
            batteryCharge -= Time.deltaTime * depletionRate;
            if ( batteryCharge <= 0 )
            {
                flashlight.SetActive(false);
                lightnessHighlight.SetActive(false);
                darknessHighlight.SetActive(true);
            }
        } else
        {   
            if (batteryCharge < 100)
            {
                batteryCharge += Time.deltaTime * rechargeRate;
            }
            
        }

        // should make it key down only
        if (Input.GetKeyDown("space"))
        {
            if (flashlight.activeSelf)
            {
                flashlight.SetActive(false);
                lightnessHighlight.SetActive(false);
                darknessHighlight.SetActive(true);
            }
            else if (darknessHighlight.activeSelf)
            {
                flashlight.SetActive(true);
                lightnessHighlight.SetActive(true);
                darknessHighlight.SetActive(false);
            }
        }

        ColorBlock cb = batteryScrollbar.colors;
        cb.normalColor = Color.Lerp(emptyColor, fullColor, batteryCharge / 100);
        //cb.normalColor = fullColor;
        batteryScrollbar.colors = cb;
        batteryScrollbar.size = batteryCharge / 100;
        batteryText.text = Mathf.Round(batteryCharge).ToString() + "%";
    }

    private GameObject flashlight;
    private GameObject lightnessHighlight;
    private GameObject darknessHighlight;
}
