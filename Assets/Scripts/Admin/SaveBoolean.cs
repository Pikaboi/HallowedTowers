using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBoolean : MonoBehaviour
{
    public bool load = false;
    // Start is called before the first frame update

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLoad()
    {
        load = true;
    }
}
