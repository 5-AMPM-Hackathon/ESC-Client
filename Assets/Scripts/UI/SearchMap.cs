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
                        // BtnItem �������� �����Ͽ� ���ο� ��ü�� �����մϴ�.
                        GameObject newBtnItem = Instantiate(BtnItem);

                        // �θ� ��ü(Parent)�� �ڽ����� �߰��մϴ�.
                        newBtnItem.transform.SetParent(Parent.transform, false);

                        // ���ο� ��ü�� ��ġ�� �����մϴ�.
                        RectTransform btnTransform = newBtnItem.GetComponent<RectTransform>();
                        btnTransform.anchoredPosition = new Vector2(btnTransform.anchoredPosition.x, -i * 50);

                        // Maps ����Ʈ���� �̸��� ������ TextMeshProUGUI�� �����մϴ�.
                        TextMeshProUGUI nameText = newBtnItem.GetComponentInChildren<TextMeshProUGUI>();
                        nameText.text = Maps[i]["name"].ToString();

                        // �̸��� ������ ��, BtnItem�� �̸��� i�� �����մϴ�.
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
    // �ʿ��� �ٸ� �ʵ���� ���⿡ �߰��ϼ���
}
