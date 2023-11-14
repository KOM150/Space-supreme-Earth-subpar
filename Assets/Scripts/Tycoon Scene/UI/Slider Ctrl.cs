using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;

    float defaultHp = 50;

    void Start()
    {
        gameManager = GameManager.Instance;
        slider.value = defaultHp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = defaultHp + gameManager._score / 10;

        if (slider.value == 0) 
        {
            SceneManager.LoadScene("Game Lose");
        }
        else if (slider.value == 100) 
        {
            SceneManager.LoadScene("Game Win");
        }
    }
}
