using UnityEngine;

public class player_movment : MonoBehaviour
{
    public float _velocity = 3f;

    void FixedUpdate()
    {
        Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + _movement * _velocity * Time.deltaTime;
    }


}
