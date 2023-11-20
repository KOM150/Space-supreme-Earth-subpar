using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
=======
using UnityEngine;
>>>>>>> joinyea
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;
<<<<<<< HEAD
    float hp = 50;
    public static float _hp = 1; //GameOver에 공유할 hp 값
=======
>>>>>>> joinyea

    void Start()
    {
        gameManager = GameManager.Instance;
<<<<<<< HEAD
        hp += gameManager._score;
        Debug.Log(hp);
    }

    void Update()
    {
        slider.value = hp;
        _hp = slider.value;
=======
        slider.value = gameManager._score;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gameManager._score / 10;
>>>>>>> joinyea
    }
}
