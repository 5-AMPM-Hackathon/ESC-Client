using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class reportSituationLogic : MonoBehaviour
{
    public GameObject chatList;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI contextText;
    public TextMeshProUGUI reportContext;
    public int temp = 30;
    public Image buttonHeart;
    public TextMeshProUGUI buttonHeartText;
    public Image markerHeart;
    public TextMeshProUGUI markerHeartText;
    public TextMeshProUGUI reportSituationLore;
    public LoadGallery selectPicture;
    public NotificationLogic notification;

    public RawImage picture;
    public void setHeartState() {
        Color color = new Color();
        color.r = 1f;
        color.g = 1f - 0.01f * temp; // temp 값에 따라서 0부터 1까지 변화
        color.b = 0f;
        color.a = 1f;
        buttonHeart.color = color;
        markerHeart.color = color;

        buttonHeartText.text = temp.ToString() + "C";
        markerHeartText.text = temp.ToString() + "C";
    }

    public void addHeartTemp()
    {
        temp += 10;
        if (temp >= 100) {
            temp = 100;
        }
        setHeartState();
    }


    public void reportButton() {
        DateTime currentTime = DateTime.Now;
        string formattedTime = currentTime.ToString("yy.MM.dd HH:mm");
        timetext.text = formattedTime;
        contextText.text = reportContext.text;
        WorldVar.lore = reportContext.text;
        reportSituationLore.text = reportContext.text;
        notification.runNotifi();
        StartCoroutine(LoadImage());
        setHeartState();
    }

    public void startEscapeScene() {
        SceneManager.LoadScene("ARNavigation");
        DontDestroyOnLoad(WorldVar.mainUI);
    }


    IEnumerator LoadImage()
    {
        yield return null;

        if (selectPicture.filedata != null) {
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(selectPicture.filedata);

            picture.texture = tex;
        }
    }



}
