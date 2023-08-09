using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenameText : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private Image img;
    private GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        //print(transform.Find("Image"));
        //print(transform.Find("Text (TMP)"));

        txt = transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        img = transform.Find("Image").gameObject.GetComponent<Image>();

        txt.text = img.sprite.name;
        btn = GameObject.FindGameObjectWithTag("next");
        gameObject.GetComponent<Button>().onClick.AddListener(()=> btn.SetActive(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
