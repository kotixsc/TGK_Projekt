using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    private float distance;

    void Update()
    {
        if (target)
        {
            distance = (gameObject.transform.position - target.transform.position).magnitude;
            if (distance < 5)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position + new Vector3(0, 0, gameObject.transform.position.z), Time.deltaTime / 2);
            }
            else
            {
                print("cannot reach");
            }
        }
        else
        {
            target = GameObject.Find("Player(Clone)");
        }
        if (target.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
