using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    private float _currentTime = 10f;
    private GameObject _gameObject;
    private bool _shouldShowGameOver =  false;
    public void Start() 
    {
       
    }
    public void Update()
    {

        if (_currentTime >= 0f)
        {
            _currentTime -= Time.deltaTime;
            _timer.text = _currentTime.ToString("00");
        }
        else
            _shouldShowGameOver = true;
        if(_shouldShowGameOver )
        {
            ShowGameOver();
        }
        
    }
   
    public void ShowGameOver()
    {
        GameOver.Show();
        _shouldShowGameOver = false;
        _currentTime = 10f;
    }
}
