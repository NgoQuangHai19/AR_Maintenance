using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceenName;
    public void LoadSceen(string scenceName){
        SceneManager.LoadScene(sceenName);
    }
}
