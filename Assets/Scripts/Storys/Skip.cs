using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void change_Main()
    {
        SceneManager.LoadScene("Tycoon Scene");
    }
}
