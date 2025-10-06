using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offSet;
    private PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offSet = new Vector3(0, 1, -4);
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void LateUpdate()
    {
        gameObject.transform.position = playerMovement.transform.position + offSet;
    }
}
