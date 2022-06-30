using UnityEngine;

public class BoatOneAnim : MonoBehaviour
{
    public void ReduceAnimSpeed()
    {
        gameObject.GetComponent<Animator>().speed = 0.35f;
    }
}
