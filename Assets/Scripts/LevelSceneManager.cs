using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    private int itemCount;

    // Update is called once per frame
    void Update()
    {
        itemCount = GameObject.FindGameObjectsWithTag("Item").Length;
        if (itemCount == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}
