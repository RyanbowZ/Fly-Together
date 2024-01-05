using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitFullScreenToggle : MonoBehaviour
{
    public Toggle _tggle;
    // Start is called before the first frame update
    void Start()
    {
        _tggle.isOn = GameManager.instance.isFullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
