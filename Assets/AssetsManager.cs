using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Cuanto m�s abajo est� el objeto, mayor ser� el sortingOrder
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }



}
