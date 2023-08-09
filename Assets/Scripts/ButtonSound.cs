using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button btn;

    [SerializeField] private SoundEffectSO sound;
    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener((() => sound.Play()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
