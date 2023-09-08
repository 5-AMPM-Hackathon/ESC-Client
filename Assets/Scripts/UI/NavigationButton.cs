using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationButton : MonoBehaviour
{
    public Transform mainUI;

   void start(){
        WorldVar.mainUI = mainUI;
   }

   public void onClick()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < mainUI.childCount; i++)
        {
            Transform panel = mainUI.GetChild(i);
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
