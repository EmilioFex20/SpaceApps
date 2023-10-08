using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBoss : MonoBehaviour
{
    private bool isPlayerInRange;
    public GameObject dialogueMark; // Asegúrate de tener una referencia al objeto de marcador de diálogo

    void Start()
    {
        // Inicializa la variable isPlayerInRange en false
        isPlayerInRange = false;
        // Asegúrate de desactivar el marcador de diálogo al inicio
        dialogueMark.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
