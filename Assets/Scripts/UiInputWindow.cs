using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiInputWindow : MonoBehaviour
{

    private void Awake()
    {
        Hide();
    }
    

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
