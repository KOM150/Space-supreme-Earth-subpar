using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        slider.value = gameManager._score;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gameManager._score / 10;
    }
}
