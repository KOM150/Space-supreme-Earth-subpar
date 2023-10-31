using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void change_scene()
    {
        SceneManager.LoadScene("Shooting Space Ship");
    }
}
