using UnityEngine;
using UnityEngine.InputSystem;

public class PausarJuego : MonoBehaviour
{

    public GameObject menuPausa; // El objeto panel que creamos
    public bool juegoPausado = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            if (juegoPausado)
                Reanudar();
            else
                Pausar();

        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false); // Oculta el panel menuPausa
        Time.timeScale = 1; // Velocidad a la que el juego se ejecuta(1 es normal, 2 el doble de rapido)
        juegoPausado = false;   
    }
    public void Pausar()
    {
        menuPausa.SetActive(true); // Muestra el panel menuPausa
        Time.timeScale = 0; // Velocidad a la que el juego se ejecuta(1 es normal, 0 se detiene)
        juegoPausado = true; 
    }
}
