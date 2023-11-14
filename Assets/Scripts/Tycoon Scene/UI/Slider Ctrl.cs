using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;
    float hp = 50;

    void Start()
    {
        gameManager = GameManager.Instance;
        hp += gameManager._score;
        Debug.Log(hp);
    }
    void Update()
    {
        slider.value = hp;
    }
}
