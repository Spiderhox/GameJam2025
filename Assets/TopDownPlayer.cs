using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;


public class TopDownPlayer : MonoBehaviour
{
    public float speed = 4.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 targetPosition;
    //public static Action CallPlayerDead;

    public TextMeshProUGUI vidasTexto;
    private Animator animator;

    private bool PuedeMoverse = false;

    public int vidas = 3; // Número de vidas inicial
    public Transform spawnPoint; // Punto de aparición
    private bool estaMuerto = false;


    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D JugadorCollider;

    public GameObject gameOverPanel;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
        ActualizarTextoVidas();

        gameOverPanel.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();
        JugadorCollider = GetComponent<CapsuleCollider2D>();

    }

    private void Update()
    {
        animator.SetFloat("Magnitude", rb.velocity.magnitude);

        if (!PuedeMoverse) return;

        if (Input.GetMouseButton(0)) // Left-click to move
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        }


        // Girar el personaje según la dirección
        if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Mirando a la derecha
        }
        else if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Mirando a la izquierda
        }


        /*input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;*/
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));
        if(Vector2.Distance(rb.position, targetPosition) < 0.1f) rb.position = targetPosition;
        //rb.velocity = input * speed;
    }
    public void OnJugadorMuerto()
    {

        if (estaMuerto) return;

        estaMuerto = true;
        vidas--;

        ActualizarTextoVidas();

        if (vidas > 0)
        {
            StartCoroutine(Reaparecer());
        }
        else
        {

            if (vidas > 0)
            {
                StartCoroutine(Reaparecer());
            }
            else
            {
                Debug.Log("Game Over");
                //ReiniciarJuego();
                MostrarPantallaGameOver();
            }

            // Aquí puedes mostrar una pantalla de derrota o reiniciar el juego
            //this.gameObject.SetActive(false);

        }
        //CallPlayerDead?.Invoke();
        //this.gameObject.SetActive(false);

    }

    
public void ReiniciarJuego()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}


    private void MostrarPantallaGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }


    private IEnumerator Reaparecer()
    {

        spriteRenderer.enabled = false;
        JugadorCollider.enabled = false;
        PuedeMoverse = false;

        yield return new WaitForSeconds(1f);

        transform.position = spawnPoint.position;
        targetPosition = spawnPoint.position;
        estaMuerto = false;

        PuedeMoverse = true;

        spriteRenderer.enabled = true;
        JugadorCollider.enabled = true;
        ActivarMovimientoConDelay(0.5f);

    }


    public void ActivarMovimientoConDelay(float delay)
    {
        StartCoroutine(DelayMovimiento(delay));
    }

    private IEnumerator DelayMovimiento(float segundos)
    {
        PuedeMoverse = false;
        yield return new WaitForSeconds(0.5f);
        targetPosition = rb.position; // Reinicia destino
        PuedeMoverse = true;
    }

    public void ResetTargetPosition()
    {
        targetPosition = rb.position;
    }

    private void ActualizarTextoVidas()
    {
        if (vidasTexto != null)
        {
            vidasTexto.text = "Vidas: " + vidas;
        }
    }

}
