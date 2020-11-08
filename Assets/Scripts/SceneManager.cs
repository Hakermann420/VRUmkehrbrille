using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public RawImage left;
    public RawImage right;

    public Button btn;
    public GameObject menu;
    public bool menuActive = false;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        WebCamTexture webcamTexture = new WebCamTexture();
        webcamTexture.requestedWidth = 640;
        webcamTexture.requestedHeight = 720;

        left.texture = webcamTexture;
        left.material.mainTexture = webcamTexture;

        right.texture = webcamTexture;
        right.material.mainTexture = webcamTexture;

        webcamTexture.Play();
    }

    void Update()
    {
        if(!menuActive && Input.touchCount > 0)
        {
            StartCoroutine(OptionsWheel());
        }
    }

    public IEnumerator OptionsWheel()
    {
        btn.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        btn.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        btn.gameObject.SetActive(false);
        menu.SetActive(true);
        menuActive = true;
    }

    public void HideMenu()
    {
        btn.gameObject.SetActive(true);
        menu.SetActive(false);
        menuActive = false;
    }

    public void FlipHorizontal()
    {
        left.GetComponent<RectTransform>().Rotate(new Vector3(180, 0, 0));
        right.GetComponent<RectTransform>().Rotate(new Vector3(180, 0, 0));
    }

    public void FlipVertical()
    {
        left.GetComponent<RectTransform>().Rotate(new Vector3(0, 180, 0));
        right.GetComponent<RectTransform>().Rotate(new Vector3(0, 180, 0));
    }

    public void Rotate()
    {
        left.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
        right.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
    }
}
