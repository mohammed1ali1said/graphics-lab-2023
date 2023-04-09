using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scenestart : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("normal");
    }
}
