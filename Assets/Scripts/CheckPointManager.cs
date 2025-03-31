using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("Checkpoint destroyed!");
        //Timer will be notified here
    }
}