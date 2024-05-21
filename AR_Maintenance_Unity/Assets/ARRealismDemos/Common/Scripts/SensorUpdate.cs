using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Net.Http;
using UnityEngine.Networking;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.UI;

public class SensorUpdate : MonoBehaviour
{
    public TMP_Text SensorName;
    public TMP_Text SensorID;
    //public TMP_Text StationID;
    public Image img;


    IEnumerator LoadImageFromUrl(string url)
    {
        Debug.Log("start update image");
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            Debug.Log("before update image");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                // Gan hinh anh moi vao thanh phan img

                //Image img = GetComponent<Image>();
                img.sprite = sprite;
                Debug.Log("end update image");
            }
            else
            {
                Debug.Log("Error when download img " + webRequest.error);
            }
        }
    }

    private void Start()
    {
        DataControler.DataReady += OnDataReady;
        //Debug.Log("AHihi maintenance start");
       /* OnDataReady();*/
    }

    private void OnDataReady()
    {
        //Xu ly khi du lieu san sang
        if (DataControler.IsDataReady())
        {
            //Debug.Log("Data  ready");

            string url = DataControler.objectTransforms[DataControler.currentIndex].sensorDevice.sensorImageUrl;
            //Debug.Log(url);
            string sensorName = DataControler.objectTransforms[DataControler.currentIndex].sensorDevice.sensorname;
            object sensorID = DataControler.objectTransforms[DataControler.currentIndex].sensorDevice.sensorId;
            //string stationID = DataControler.objectTransforms[DataControler.currentIndex].sensorDevice.stationId.ToString();
            //Debug.Log("ahjhj" + url);
            StartCoroutine(LoadImageFromUrl(url));
            SensorName.text = sensorName;
            SensorID.text = sensorID.ToString();
            /*SensorName.text = ;*/
        }

    }


    // Start is called before the first frame update
    /*    void Start()
        {
            OnDataReady();
        }*/

    // Update is called once per frame
    void Update()
    {
        OnDataReady();

    }
}
