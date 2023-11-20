using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;
    float hp = 50;
    public static float _hp = 1; //GameOver에 공유할 hp 값

    void Start()
    {
        gameManager = GameManager.Instance;
        hp += gameManager._score;
        Debug.Log(hp);
    }

    void Update()
    {
        slider.value = hp;
        _hp = slider.value;
    }
}
