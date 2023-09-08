using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadGallery : MonoBehaviour
{

    public byte[] filedata;
    public RawImage img;
    public void OnClickIamgeLaod() {
        NativeGallery.GetImageFromGallery((file) => {
            FileInfo selected = new FileInfo(file);
            if (selected.Length >= 500000) {
                return;
            }
            if (!string.IsNullOrEmpty(file)) {
                StartCoroutine(LoadImage(file));
            }
        });
    }

    IEnumerator LoadImage(string path) {
        yield return null;
        filedata = File.ReadAllBytes(path);
        string fileName = Path.GetFileName(path).Split(",")[0];

        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(filedata);

        img.texture = tex;
        img.color = Color.white;
    }

    public void clearIAMGE() {
        img.texture = null;
        Color color;
        ColorUtility.TryParseHtmlString("#FF7E7E", out color);
        color.a = 0.47f;
        img.color = color;
    }
    
}
