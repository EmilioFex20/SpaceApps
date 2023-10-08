using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador a seguir
    public Vector3 offset;   // Desplazamiento opcional para ajustar la posición de la cámara

    void Update()
    {
        // Combinar la posición del objetivo (jugador) con el desplazamiento
        Vector3 targetPosition = target.position + offset;

        // Establecer la posición de la cámara igual a la posición del objetivo
        transform.position = targetPosition;
    }
}
