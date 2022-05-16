using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] GameObject mapRoot;

    public void OnClick()
    {
      mapRoot.SetActive(false);
    }
}
