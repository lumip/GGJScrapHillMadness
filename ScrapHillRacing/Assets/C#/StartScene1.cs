using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScene1 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Instructions");
    }
}
