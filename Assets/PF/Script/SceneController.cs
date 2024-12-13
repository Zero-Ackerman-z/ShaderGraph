using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using UnityEngine.UI; // Necesario para interactuar con los botones del UI

public class SceneController : MonoBehaviour
{
    [Header("Configuraci�n de botones UI")]
    [SerializeField] private Button changeSceneButton; // Bot�n para cambiar de escena
    [SerializeField] private Button exitGameButton; // Bot�n para salir del programa

    [Header("Configuraci�n de la escena")]
    [SerializeField] private string nextSceneName; // Nombre de la pr�xima escena a cargar

    void Start()
    {
        // Asignar m�todos a los botones
        if (changeSceneButton != null)
        {
            changeSceneButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("El bot�n para cambiar de escena no est� asignado.");
        }

        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogWarning("El bot�n para salir del programa no est� asignado.");
        }
    }

    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("El nombre de la pr�xima escena no est� configurado.");
        }
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        // Detener la ejecuci�n en el editor de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Cerrar la aplicaci�n en una compilaci�n
        Application.Quit();
#endif
    }
}
