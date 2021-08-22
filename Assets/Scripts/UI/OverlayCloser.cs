using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayCloser : MonoBehaviour
{
    public GameObject overlayToClose;

    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseOverlay()
    {
        overlayToClose.SetActive(false);
    }
}
