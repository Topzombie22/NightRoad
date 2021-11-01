using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverColorFlash : MonoBehaviour
{

    public GameObject image;
    public Color lerpedColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        image.GetComponent<RawImage>().color = lerpedColor;
        lerpedColor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
        image.GetComponent<RawImage>().CrossFadeAlpha(255, 1, false);
    }
}
