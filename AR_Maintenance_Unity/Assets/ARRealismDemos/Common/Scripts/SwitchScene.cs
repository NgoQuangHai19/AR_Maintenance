using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //public string sceenName;
    public void LoadSceen(int sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
