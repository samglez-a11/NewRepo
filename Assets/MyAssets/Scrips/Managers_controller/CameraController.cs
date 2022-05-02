using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Inicializar variables camara
    [SerializeField]
    private Transform _player, _playerCamera, _focusPoint;
    /*[SerializeField]
    private float _cameraHeight = 5f;*/
    #endregion
    #region Variables zoom
    [SerializeField]
    private float _zoom = -5f;// _zoomSpeed = 3f;
    /*[SerializeField]
    private float _zoomMin = -15f, _zoomMax = -1.4f;
    */
    #endregion
    #region Variables rotacion
    [SerializeField]
    private float _camRotX, _camRotY;
    [SerializeField]
    private float _cameraSensitivity = 1f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region comprobacion de asignacion
        if (_playerCamera == null)
        {
            Debug.Log("Camara no se asino al camera controller");
        }
        if (_player == null) 
        {
            Debug.Log("Jugador no se asino al camera controller");
        }
        if (_focusPoint == null)
        {
            Debug.Log("Punto focal no se asino al camera controller");
        }
        #endregion
        #region Asignar parentesco
        _focusPoint.SetParent(_player);
        _playerCamera.SetParent(_focusPoint);
        #endregion
        #region Asignar pos, rot , scale
        //_focusPoint.localPosition = new Vector3(0, 5, 0);
        //_focusPoint.localRotation = Quaternion.Euler(0,0,0);
        //_focusPoint.localScale = new Vector3(1,1,1);
        _playerCamera.localPosition = new Vector3(0, 0, _zoom);
        _playerCamera.LookAt(_player);
        _playerCamera.localScale = new Vector3(1, 1, 1);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Zoom camara
        /*_zoom += Input.GetAxis("Mouse ScrollWheel")*_zoomSpeed;
        _zoom = Mathf.Clamp(_zoom,_zoomMin,_zoomMax);*/
        #endregion

        #region rotacion camara
        if (Input.GetMouseButton(1))//1 click derecho 2 izquierdo 3 scroll
        {
            _camRotX += Input.GetAxis("Mouse X") * _cameraSensitivity;
            _camRotY += Input.GetAxis("Mouse Y") * _cameraSensitivity;
            _camRotY = Mathf.Clamp(_camRotY, -45f, 180f);

            _focusPoint.localRotation = Quaternion.Euler(_camRotY, 0, 0);
            _player.localRotation = Quaternion.Euler(0, _camRotX, 0);
            //_focusPoint.localRotation = Quaternion.Euler(0, 0, 0);
            //_player.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow))//1 click derecho 2 izquierdo 3 scroll
        {
            _camRotX -= _cameraSensitivity;
            _focusPoint.localRotation = Quaternion.Euler(_camRotY, 0, 0);
            _player.localRotation = Quaternion.Euler(0, _camRotX, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))//1 click derecho 2 izquierdo 3 scroll
        {
            _camRotX += _cameraSensitivity;
            _focusPoint.localRotation = Quaternion.Euler(_camRotY, 0, 0);
            _player.localRotation = Quaternion.Euler(0, _camRotX, 0);
        }
        #endregion

        #region Actualizar camara
        //_playerCamera.localPosition = new Vector3(0, 0, _zoom);
        _playerCamera.LookAt(_player);
        #endregion
    }
}
