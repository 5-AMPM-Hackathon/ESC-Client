using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCol : MonoBehaviour
{

    public string text = "";

    private void OnTriggerEnter(Collider collision)
    {
        WorldVar.warning.SetActive(true);
        WorldVar.warningText.text = text;
    }

    private void OnTriggerExit(Collider collision)
    {
        WorldVar.warning.SetActive(false);
        WorldVar.warningText.text = text;
    }

}
