using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitching : MonoBehaviour
{
    public GameObject _player1, _player2;
    private short _charActive = 1;

    void Start()
    {
        _player1.gameObject.SetActive(true);
        _player2.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            _charActive++;

            if (_charActive > 2)
                _charActive = 1;
        }

        switch(_charActive)
        {
            case 1:
                _player1.gameObject.SetActive(true);
                _player2.gameObject.SetActive(false);
                break;

            case 2:
                _player1.gameObject.SetActive(false);
                _player2.gameObject.SetActive(true);
                break;
        }
            
    }
}
