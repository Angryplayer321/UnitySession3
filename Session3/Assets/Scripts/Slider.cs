using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private float period;
    [SerializeField] private int speed;
    [SerializeField] private int degree = 0;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        degree+=speed;
        float rad = (float)(degree * Mathf.PI) / 180f;
        float value = Mathf.Sin(rad) * period;
        Vector3 position = new Vector3(initialPosition.x + value, initialPosition.y, initialPosition.z);
        transform.position = position;
    }
}
