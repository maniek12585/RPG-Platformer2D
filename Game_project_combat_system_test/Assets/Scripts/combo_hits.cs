using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combo_hits : MonoBehaviour
{
    public Animator _animator;
    public float _comboDelay = 0.9f;
    private int _numberOfHits = 0;
    private float _timeAfterClick = 0;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time - _timeAfterClick > _comboDelay)
            _numberOfHits = 0;

        if(Input.GetMouseButtonDown(0))
        {
            _timeAfterClick = Time.time;
            _numberOfHits++;

            if (_numberOfHits == 1)
                _animator.SetBool("attack1", true);

            _numberOfHits = Mathf.Clamp(_numberOfHits, 0, 3);
        }
    }

    public void comboHit2()
    {
        if (_numberOfHits >= 2)
            _animator.SetBool("attack2", true);
        else
        {
            _animator.SetBool("attack1", false);
            _numberOfHits = 0;
        }
    }

    public void comboHit3()
    {
        if (_numberOfHits >= 3)
            _animator.SetBool("attack3", true);
        else
        {
            _animator.SetBool("attack2", false);
            _numberOfHits = 0;
        }
    }

    public void comboEnd()
    {
        _animator.SetBool("attack1", false);
        _animator.SetBool("attack2", false);
        _animator.SetBool("attack3", false);
        _numberOfHits = 0;
    }
}
