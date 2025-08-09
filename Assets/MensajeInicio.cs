using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeInicio : MonoBehaviour
{

    [SerializeField] private GameObject panelToHide;

    public void HidePanel()
    {
        panelToHide.SetActive(false);

    }

}
