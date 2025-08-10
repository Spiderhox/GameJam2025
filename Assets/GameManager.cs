using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /*public GameObject player;
    public Transform spawnPoint;

    private void OnEnable()
    {
        TopDownPlayer.CallPlayerDead += RevivirJugador;
    }

    private void OnDisable()
    {
        TopDownPlayer.CallPlayerDead -= RevivirJugador;
    }

    private void RevivirJugador()
    {
        StartCoroutine(Reaparecer());
    }

    private IEnumerator Reaparecer()
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = spawnPoint.position;
        player.SetActive(true);

        player.GetComponent<TopDownPlayer>().ResetTargetPosition();
    }*/

}
