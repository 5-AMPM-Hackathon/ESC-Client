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
        WorldVar.lore = "411ȣ �ݵ�ü ���뱸�� �����ǿ��� ȭ�簡 �߻��߽���!";
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
