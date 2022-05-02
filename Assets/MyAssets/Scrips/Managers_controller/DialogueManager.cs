using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Comopentes dialogue panel
    [SerializeField]
    private GameObject _dialoguePnl;
    private Button _nextBttn;
    private TextMeshProUGUI _dialogueTxt, _nameTxt, _nextTxt;
    #endregion
    #region Variables NPC
    private string _name;
    private List<string> _dialogueList;
    private int _dialogueIdx;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _dialogueIdx = 0;
        #region Obteniendo e inicializando componentes del dialogue panel
        if (_dialoguePnl == null)
        {
            Debug.LogError("No se asigno un panel de dialos al dialogueManager");
        }
        else
        {
            #region Texto de Dialogo
            //_dialogueTxt = _dialoguePnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _dialogueTxt = _dialoguePnl.GetComponentInChildren<TextMeshProUGUI>();
            if(_dialogueTxt == null)
            {
                Debug.LogError("El panel de dialogos no tiene un TMP de primer hijo");
            }
            else
            {
                _dialogueTxt.text = "Dialo inicializados";

            }
            #endregion
            #region Texto nombre
            // buscar al hijo del segundo hijo del panel
            _nameTxt = _dialoguePnl.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
            if (_nameTxt == null)
            {
                Debug.LogError("El panel de dialogos no tiene un TMP de primer hijo de su degundo hijo");
            }
            else
            {
                _nameTxt.text = "hey hellouuu";

            }
            #endregion
            #region Obtener Boton
            _nextBttn = _dialoguePnl.transform.GetChild(2).GetComponentInChildren<Button>();
            if (_nextBttn == null)
            {
                Debug.LogError("No se encontro un boton como tercer hijo del dialoguePNL");
            }
            else
            {

                _nextBttn.onClick.AddListener(delegate { ContinueDialogue(); });
                #region Obtener Dialogo boton
                _nextTxt = _nextBttn.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
                if (_nextTxt == null)
                {
                    Debug.LogError("El boton de continuar no tiene un hijo TMP");
                }
                else
                {
                    _nextTxt.text = "Boton inicializado";

                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region ocultar panel
        _dialoguePnl.SetActive(false);
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDialogue(string name,string[] dialogue)
    {
        _name = name;
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _nameTxt.text = _name;
        _dialogueTxt.text = _dialogueList[_dialogueIdx];
        _nextTxt.text = "Continuar";
        #region mostrar panel
        _dialoguePnl.SetActive(true);
        #endregion
    }
    private void ShowDialogue()
    {
        Debug.Log("Dialogo #" + _dialogueList);
        _dialogueTxt.text = _dialogueList[_dialogueIdx];
    }
    private void ContinueDialogue()
    {
        if (_dialogueIdx == _dialogueList.Count - 1)
        {
            _dialogueIdx++;
            ShowDialogue();
            _nextTxt.text = "Salir";
        }
        else if (_dialogueIdx == _dialogueList.Count - 2)
        {

        }
        else
        {
            _dialogueIdx++;
            ShowDialogue();
        }
    }
}
