using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARUILogic : MonoBehaviour
{
    public TextMeshProUGUI loreText;
    public TextMeshProUGUI remainText;
    public TextMeshProUGUI warningText;
    public GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        WorldVar.disRemain = 32;
        WorldVar.lore = "411호 반도체 나노구조 연구실에서 화재가 발생했습다!";
        WorldVar.warningText = warningText;
        WorldVar.warning = warning;
    }

    // Update is called once per frame
    void Update()
    {
        remainText.text = WorldVar.disRemain.ToString() + "M";
        loreText.text = WorldVar.lore.ToString();
    }
}
