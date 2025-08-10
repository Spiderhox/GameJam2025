using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeInicio : MonoBehaviour
{
    [SerializeField] private TopDownPlayer jugador;
    [SerializeField] private GameObject panelToHide;

    public void HidePanel()
    {
        panelToHide.SetActive(false);
        jugador.ActivarMovimientoConDelay(5f);

    }

}
