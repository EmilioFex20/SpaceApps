using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Cambtotlun: MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;


    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarNivel(indiceNivel);
        }
        if (pasarNivel)
        {
            
            CambiarNivel(indiceNivel);
        }
    }

    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(20);
    }
}
