using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManagerGame : MonoBehaviour
{

    public static UIManagerGame Instance;

    [SerializeField] private TMP_Text _textTenps = default;
    [SerializeField] private TMP_Text _txtCollisions = default;
    [SerializeField] private GameObject _panneauPause = default;

    private bool _enPause = false;


    private void Start()
    {
        _txtCollisions.text = "Collisions : " + GestionJeu.Instance.Pointage;
        Time.timeScale = 1;
       
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
        _textTenps.text = "Temps : " + GestionJeu.Instance.Timer.ToString("f2");
        // float temps = Time.time - GestionJeu.Instance.TempsDepart;
        // _textTenps.text = "Temps : " + temps.ToString("f2");



        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _panneauPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void EnleverPause()
    {
        _panneauPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ChangerCollisions(int pointage)
    {
        _txtCollisions.text = "Collisions : " + pointage.ToString();
    }

    public void Quiter()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Recommencer()
    {
        SceneManager.LoadScene(0);
    }
}