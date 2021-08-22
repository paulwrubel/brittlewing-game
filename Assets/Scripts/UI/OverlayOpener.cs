using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayOpener : MonoBehaviour
{

    public GameObject overlayToOpen;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            overlayToOpen.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
