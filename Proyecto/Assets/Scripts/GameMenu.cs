using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReiniciarJuego2()
    {
        SceneManager.LoadScene("Juego2");
    }
}
