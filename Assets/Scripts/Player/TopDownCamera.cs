using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float zoomSpeed = 5f; // Yakınlaştırma ve uzaklaştırma hızı
    public float minDistance = 5f; // Minimum uzaklık
    public float maxDistance = 20f; // Maksimum uzaklık

    void LateUpdate()
    {
        // Yakınlaştırma ve uzaklaştırma işlemi
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance); // Uzaklığı sınırla

        // Kamera pozisyonunu ve bakış açısını ayarla
        Vector3 desiredPosition = target.position - transform.forward * distance;
        transform.position = desiredPosition;
        transform.LookAt(target.position);
    }
}