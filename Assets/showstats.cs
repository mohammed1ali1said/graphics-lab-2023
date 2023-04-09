using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showstats : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("stats scene");
    }
}
