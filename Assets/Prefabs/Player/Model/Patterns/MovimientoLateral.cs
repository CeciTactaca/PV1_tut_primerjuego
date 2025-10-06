using UnityEngine;

public class MovimientoLateral : IMovementStrategy
{
    public void Move(Transform transform, float speed, float direccion)
    {
        //float direccion = Input.GetAxis("Horizontal");
        transform.Translate(direccion * speed * Time.deltaTime, 0, 0);
    }

}
