using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScale = 0.3f;
    private float _startFixedDeltaTime;

    [SerializeField] private float _stamina = 1f;
    private float _startStamina;
    [SerializeField] private float _delayBetweenSlowdowns = 5f;
    private float _currentDelayBetweenSlowdowns=0;
    private bool _delay = true;
    public GhargeIcon GhargeIcon;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
        _startStamina = _stamina;
        GhargeIcon.Text.enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _delay == true)
        {
            Time.timeScale = 0.2f;
            _stamina -= Time.fixedDeltaTime;
            if (_stamina <= 0)
            {
                Time.timeScale = 1;
                GhargeIcon.StartCharge();
                _delay = false;
                _stamina = _startStamina;
            }
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            Time.timeScale = 1;
            GhargeIcon.StartCharge();
             _delay = false;
            _stamina = _startStamina;
        }
        else
        {
            Time.timeScale = 1;
        }

        if(_delay == false)
        {
            DelayBetweenSlowdowns();
        }
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }

    private void DelayBetweenSlowdowns()
    {
        _currentDelayBetweenSlowdowns += Time.deltaTime;
        GhargeIcon.SetChargeValue(_currentDelayBetweenSlowdowns, _delayBetweenSlowdowns);
        if (_currentDelayBetweenSlowdowns>=_delayBetweenSlowdowns)
        {
            _currentDelayBetweenSlowdowns = 0;
             _delay = true;
            GhargeIcon.StopCharge();  
        }
    }
}
