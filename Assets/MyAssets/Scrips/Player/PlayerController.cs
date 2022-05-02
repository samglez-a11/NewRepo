using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables de Sonido
    [SerializeField]
    private AudioSource audioSource = null;
    #endregion
    #region Variables de Puntuacion
    private int contFragmentos = 0;
    private static int cantidadDeFragmentos = 100;
    #endregion
    private Rigidbody _playerRB;
    #region Animation
    private PlayerAnimation _playerAnim;
    #endregion
    #region Variables de movimiento
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _horizontalInput, _forwardInput;
    private float _maxSpeed = 7f,_minSpeed = 3f;
    private bool isRunning;
    private bool isInAir;
    private bool direccion;
    private float horizontalInicial, verticalInicial;
    #endregion
    #region Salto
    [SerializeField]
    private bool _jumpRequest = false;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _availableJumps = 0,_maxJumps=2;
    #endregion
    #region Variables De Puntaje del jugador
    [SerializeField]
    private int _puntaje = 0;

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
    public int ContFragmentos { get => contFragmentos; set => contFragmentos = value; }
    public static int CantidadDeFragmentos { get => cantidadDeFragmentos; set => cantidadDeFragmentos = value; }
    #endregion
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        if (_playerRB == null)
        {
            Debug.LogWarning("El jugador no tiene cuerpo rigido");
        }
        #region Obtener player animation
        _playerAnim = GetComponent<PlayerAnimation>();
        if(_playerAnim == null)
        {
            Debug.LogWarning("El jugador no tiene el script PlayerAnimation");
        }
        #endregion
        horizontalInicial = Input.GetAxis("Horizontal");
        verticalInicial = Input.GetAxis("Vertical");
        _speed = _minSpeed;
        isRunning = false;
        isInAir = false;
        direccion = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region Revisar si corre, camina o brinca
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
            if(isRunning)
            {
                _speed = _maxSpeed;
            }
            else
            {
                _speed = _maxSpeed / 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _availableJumps > 0)
        {
            _jumpRequest = true;
        }
        #endregion
        #region movimiento
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _forwardInput = Input.GetAxis("Vertical");
        float velocity = Mathf.Max(Mathf.Abs(_horizontalInput),Mathf.Abs(_forwardInput));
        velocity = velocity * _speed / _maxSpeed;
        Vector3 movement = new Vector3(_horizontalInput, 0, _forwardInput);
        transform.Translate(movement * _speed*Time.deltaTime);
        #endregion
        #region Asignacion de Animacion
        /*
            normal 0
            caminar-atras-1
            caminar-frente-2
            brincar-3
            caer-4
            correr-hacia atras-5
            correr-hacia adelante-6
         */
        if (_jumpRequest)
        {
            _playerAnim.setIsJump(true);
        }
        else if (velocity == 0)
        {
            _playerAnim.setSpeed(0f);
        }
        else if (isRunning)
        {            
            if (verticalInicial <= _forwardInput)
            {
                _playerAnim.setSpeed(1f);
            }
            else
            {
                _playerAnim.setSpeed(0.83f);
            }
        }
        else if (!isRunning)
        {
            _playerAnim.setSpeed(0.33f);
            if (verticalInicial <= _forwardInput)
            {
                _playerAnim.setSpeed(0.33f);
            }
            else
            {
                _playerAnim.setSpeed(0.16f);
            }
        }
            
        #endregion
    }
    private void FixedUpdate()
    {
        if (_jumpRequest)
        {
            //Debug.Log("el personaje salto");
            _jumpRequest = false;
            _playerAnim.setIsJump(false);
            _playerAnim.setIsJump(true);
            _availableJumps--;
            _playerRB.velocity=Vector3.up * _jumpForce;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { 
            _availableJumps = _maxJumps; 
            isInAir = false;
            _playerAnim.setIsJump(false);
        }
        
            
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entra al trigger");
        if (collider.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Se encontro un objeto para interactuar");
            Interactable interaction = collider.GetComponent<Interactable>();
            if(interaction == null)
            {
                Debug.Log("pero no es de tipo Interactable");
            }
            else
            {
                interaction.Interact(this);
            }
        }
        
    }
    public void UpdatePuntaje(int pts) {
        _puntaje = _puntaje + pts;
        Debug.Log("Fragmentos de alma recogidos ->"+this.contFragmentos +'\n'+"Puntuacion ->"+this._puntaje);

    } 
}
