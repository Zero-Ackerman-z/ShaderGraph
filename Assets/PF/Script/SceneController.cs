using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using UnityEngine.UI; // Necesario para interactuar con los botones del UI

public class SceneController : MonoBehaviour
{
    [Header("Configuración de botones UI")]
    [SerializeField] private Button changeSceneButton; // Botón para cambiar de escena
    [SerializeField] private Button exitGameButton; // Botón para salir del programa

    [Header("Configuración de la escena")]
    [SerializeField] private string nextSceneName; // Nombre de la próxima escena a cargar

    void Start()
    {
        // Asignar métodos a los botones
        if (changeSceneButton != null)
        {
            changeSceneButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("El botón para cambiar de escena no está asignado.");
        }

        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogWarning("El botón para salir del programa no está asignado.");
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
            Debug.LogWarning("El nombre de la próxima escena no está configurado.");
        }
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        // Detener la ejecución en el editor de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Cerrar la aplicación en una compilación
        Application.Quit();
#endif
    }
}
