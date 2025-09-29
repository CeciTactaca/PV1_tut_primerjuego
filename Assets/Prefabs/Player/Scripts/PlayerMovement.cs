using UnityEngine;
/// <summary>
/// Permite el comportamiento del movimiento del jugador
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    /// <summary>
    /// Fuerza utilizada para aplicar movimiento 
    /// </summary>
    private Vector3 fuerzaPorAplicar;
    /// <summary>
    /// Representa el tiempo que ha transcurrido
    /// desde la ultima aplicación de fuerza
    /// </summary>
    private float tiempoDesdeUltimaFuerza;
    /// <summary>
    /// Indica cada cuanto tiempo debe aplicarse la fuerza
    /// </summary>
    private float intervaloTiempo;
    /// <summary>
    /// Indica la velocidad aplicada en el movimiento lateral
    /// </summary>
    private float velocidadLateral;
    /// <summary>
    /// Representa la estrategia de movimiento
    /// </summary>
    private IMovementStrategy strategy;

    #endregion

    #region Ciclo de vida del Script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0,0,10f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
        velocidadLateral = 5f;
        //SetStrategy(new MovimientoLateral());
        SetStrategy(new MovimientoAcelerado());
    }

    private void Update()
    {
        strategy.Move(transform, velocidadLateral);
    }

    //Lógica para aplicacion de fuerzas
    private void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if(tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }

    #endregion

    #region Logica del Script

    public void SetStrategy(IMovementStrategy strategy)
    {
        this.strategy = strategy;
    }

    #endregion

}


