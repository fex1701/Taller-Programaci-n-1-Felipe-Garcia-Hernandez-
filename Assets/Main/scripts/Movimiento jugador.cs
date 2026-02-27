using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PlinkoGameManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_Text uiLabel;

    [Header("Referencias Física")]
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Lanzamiento Inicial")]
    [SerializeField] private float _fuerzaImpulso = 300f;
    [SerializeField] private float _velocidad = 8f;

    [Header("Punto de Parada y Random Caída")]
    [SerializeField] private float xParada = -10f;           // donde empieza el random (se multiplica × -1)
    [SerializeField][Range(-10f, 10f)] private float minVelCaida = -8f;
    [SerializeField][Range(-10f, 10f)] private float maxVelCaida = 8f;

    [Header("Datos Personales")]
    [SerializeField] private string _nombre = "Felipe";
    [SerializeField] private int _edad = 18;
    [SerializeField] private int _añoActual = 2026;

    private bool haParado = false;
    private float velCaidaHorizontal;

    private void Start()
    {
        ConfigurarTextoUI();
        LanzarInicial();
    }

    private void ConfigurarTextoUI()
    {
        if (uiLabel != null)
        {
            int _añoNacimiento = _añoActual - _edad;
            uiLabel.text = $"Mi nombre es {_nombre} y nací en {_añoNacimiento}";
        }
        else
        {
            Debug.LogWarning("Falta asignar TMP_Text (uiLabel)");
        }
    }

    private void LanzarInicial()
    {
        if (_rb2d != null)
        {
            // Impulso inicial hacia la derecha
            _rb2d.AddForce(Vector2.right * _fuerzaImpulso, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Falta asignar Rigidbody2D");
        }
    }

    private void FixedUpdate()
    {
        if (_rb2d == null || haParado) return;

        float puntoParada = xParada * -1f;

        if (_rb2d.position.x < puntoParada)
        {
            // Mantiene velocidad constante horizontal (gravedad actúa en Y)
            _rb2d.linearVelocity = new Vector2(_velocidad, _rb2d.linearVelocity.y);
        }
        else
        {
            // Llega al punto → para el movimiento fijo y aplica random en X
            haParado = true;
            velCaidaHorizontal = Random.Range(minVelCaida, maxVelCaida);
            _rb2d.linearVelocity = new Vector2(velCaidaHorizontal, _rb2d.linearVelocity.y);
        }
    }
}








