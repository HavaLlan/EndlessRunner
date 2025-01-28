using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float[] lanePosition = {-3.0f, 0, 3};
    private int currentLane = 1;
    public float laneChangeSpeed = 10.0f;
    public float forwardSpeed = 10.0f;

    private Vector3 targetPositon = Vector3.zero;

    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanePosition.Length - 1)
            {
                currentLane++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
            }
        }
        // oyuncunun bastýðý tuþa göre hedef pos bilgisi tutuluyor  
        targetPositon = new Vector3(lanePosition[currentLane], transform.position.y, transform.position.z);
        // Vector3 sýnýfýndaki Lerp kullanýlarak bir sonraki yola yumuþak bir geçiþ saðilanýyor 
        transform.position = Vector3.Lerp(transform.position, targetPositon, laneChangeSpeed * Time.deltaTime);

        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
}
