using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFontAsset : MonoBehaviour
{
    public TMPro.TMP_Text t;
    public string resourceString;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMPro.TMP_Text>();
        t.font = Resources.Load<TMPro.TMP_FontAsset>("Font/" + resourceString);
    }
}
