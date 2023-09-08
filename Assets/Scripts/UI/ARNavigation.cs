using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ARNavigation : MonoBehaviour
{


    void start(){

    }

   public void onClick()
    {
        SceneManager.LoadScene("Main");
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < WorldVar.mainUI.childCount; i++)
        {
            Transform panel = WorldVar.mainUI.GetChild(i);
            if(panel.gameObject.name == "navigation") continue;
            if (btn.transform.name == panel.name)
            {
                panel.gameObject.SetActive(true);
            }
            else {
                panel.gameObject.SetActive(false);
            }
        }
    }
}
