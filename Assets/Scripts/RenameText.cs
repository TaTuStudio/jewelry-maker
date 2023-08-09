using System;
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
    [SerializeField] private Sprite onSelectSprite;
    [SerializeField] private Sprite onDeSelectSprite;
    private Button button;
    public delegate void OnSelectClic();
    public static event OnSelectClic ClickEvent;
    
    // Start is called before the first frame update
    private void Start()
    {
        //print(transform.Find("Image"));
        //print(transform.Find("Text (TMP)"));

        txt = transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        img = transform.Find("Image").gameObject.GetComponent<Image>();

        txt.text = img.sprite.name;
        btn = GameObject.FindGameObjectWithTag("next");
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            btn.SetActive(true);
            ClickEvent?.Invoke();
            button.image.sprite = onSelectSprite;
        });
    }

    private void OnEnable()
    {
        ClickEvent += Clicked;
    }

    private void OnDisable()
    {
        ClickEvent -= Clicked;
    }

    private void Clicked()
    {
        button.image.sprite = onDeSelectSprite;
    }
    
}
