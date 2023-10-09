using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Corrección de la siguiente línea
using UnityEngine.SceneManagement;

public class Cambiarnivel : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debe ser "Input.GetKeyDown" en lugar de "Input.GetDown"
       
        if (pasarNivel)
        {
            // Debe tener un punto y coma al final de la línea
            CambiarNivel(indiceNivel);
        }
    }

    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(1);
    }
}
