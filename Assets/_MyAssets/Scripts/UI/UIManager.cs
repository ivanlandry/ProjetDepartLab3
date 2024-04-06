using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _panneauInstructions = default;
    [SerializeField] private GameObject _panneauBoutons = default;
    public void Quitter()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ChangerScene()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }

    public void AfficherInsructions()
    {
        _panneauInstructions.SetActive(true);
        _panneauBoutons.SetActive(false);
    }

    public void AfficherBoutons()
    {
        _panneauInstructions.SetActive(false);
        _panneauBoutons.SetActive(true);
    }

    public void RetourDebut()
    {
        SceneManager.LoadScene(0);
    }
}
