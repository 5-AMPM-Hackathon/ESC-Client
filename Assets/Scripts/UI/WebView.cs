using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gpm.WebView;

public class WebView : MonoBehaviour
{

    public void ShowUrl()
    {

        GpmWebView.ShowUrl(
            "https://safetymap-nextjs.vercel.app/map?type=TemporaryHousing",
            new GpmWebViewRequest.Configuration()
            {
                style = GpmWebViewStyle.FULLSCREEN,
                isClearCookie = false,
                isClearCache = false,
                isNavigationBarVisible = true,
                title = "The page title.",
                isBackButtonVisible = true,
                isForwardButtonVisible = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
#endif
        },
            OnOpenCallback,
            OnCloseCallback,
            new List<string>()
            {
            "USER_ CUSTOM_SCHEME"
            },
            OnSchemeEvent);
    }

    private void OnOpenCallback(GpmWebViewError error)
    {
        if (error == null)
        {
            Debug.Log("[OnOpenCallback] succeeded.");
        }
        else
        {
            Debug.Log(string.Format("[OnOpenCallback] failed. error:{0}", error));
        }
    }

    private void OnCloseCallback(GpmWebViewError error)
    {
        if (error == null)
        {
            Debug.Log("[OnCloseCallback] succeeded.");
        }
        else
        {
            Debug.Log(string.Format("[OnCloseCallback] failed. error:{0}", error));
        }
    }

    private void OnSchemeEvent(string data, GpmWebViewError error)
    {
        if (error == null)
        {
            Debug.Log("[OnSchemeEvent] succeeded.");

            if (data.Equals("USER_ CUSTOM_SCHEME") == true || data.Contains("CUSTOM_SCHEME") == true)
            {
                Debug.Log(string.Format("scheme:{0}", data));
            }
        }
        else
        {
            Debug.Log(string.Format("[OnSchemeEvent] failed. error:{0}", error));
        }
    }
}
