using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPuzzle : MonoBehaviour
{

    private bool _move;
    private Vector2 _mousePosition;

    private float _startPositionX;
    private float _startPositionY;
    [SerializeField] private GameObject _form;
    private bool _finish;
    [SerializeField] private float _offset = 5;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _move = true;
            _mousePosition = Input.mousePosition;
            _startPositionX = _mousePosition.x - transform.localPosition.x;
            _startPositionY = _mousePosition.y - transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        _move = false;

        if(MathF.Abs(transform.localPosition.x - _form.transform.localPosition.x) <= _offset && 
        MathF.Abs(transform.localPosition.y - _form.transform.localPosition.y) <= _offset)
        {
            transform.position = new Vector2(_form.transform.position.x, _form.transform.position.y);
            _finish = true;
        }
    }

    private void Update()
    {
        if(_move && !_finish)
        {
            _mousePosition = Input.mousePosition;

            gameObject.transform.localPosition = new Vector2(_mousePosition.x - _startPositionX, _mousePosition.y - _startPositionY);
        }
    }

}
