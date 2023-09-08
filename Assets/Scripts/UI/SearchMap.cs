using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Text;
using System;

public class SearchMap : MonoBehaviour

{
    public TextMeshProUGUI contextText;
    public GameObject BtnItem;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void search() {
        StartCoroutine(FetchJsonData(contextText.text));
    }

    JArray Maps = new JArray();
    IEnumerator FetchJsonData(string key)
    {

        Debug.Log("https://minework.shop/search?searchKeyword=" + key);
        string encodedKey = UnityWebRequest.EscapeURL(key);
        using (UnityWebRequest www = UnityWebRequest.Get("https://minework.shop/search?searchKeyword=" + encodedKey))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                try
                {
                    GameObject name = BtnItem.transform.GetChild(0).gameObject;
                    string JSON = Encoding.Default.GetString(www.downloadHandler.data);
                    Maps = JArray.Parse(JSON);
                    for (int i = 0; i < Maps.Count; i++)
                    {
                        Debug.Log(Maps[i]["name"].ToString());
                        // BtnItem 프리팹을 복사하여 새로운 객체를 생성합니다.
                        GameObject newBtnItem = Instantiate(BtnItem);

                        // 부모 객체(Parent)의 자식으로 추가합니다.
                        newBtnItem.transform.SetParent(Parent.transform, false);

                        // 새로운 객체의 위치를 설정합니다.
                        RectTransform btnTransform = newBtnItem.GetComponent<RectTransform>();
                        btnTransform.anchoredPosition = new Vector2(btnTransform.anchoredPosition.x, -i * 50);

                        // Maps 리스트에서 이름을 가져와 TextMeshProUGUI에 설정합니다.
                        TextMeshProUGUI nameText = newBtnItem.GetComponentInChildren<TextMeshProUGUI>();
                        nameText.text = Maps[i]["name"].ToString();

                        // 이름을 설정할 때, BtnItem의 이름을 i로 설정합니다.
                        newBtnItem.name = i.ToString();
                    }

                }
                catch (Exception e)
                {
                    Debug.Log(www.downloadHandler.data);
                    Debug.Log(e);
                }
            }
        }
    }
}

[System.Serializable]
public class MyDataObject
{
    public string name;
    public string path;
    // 필요한 다른 필드들을 여기에 추가하세요
}
