using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject rabbit;
    public GameObject bear;

    public EnemyNum num;

    void Awake()
    {
        if (gameObject.name == "Ground1") Ground1Enemy();
        else if (gameObject.name == "Ground2") Ground2Enemy();
        else if (gameObject.name == "Ground3") Ground3Enemy();
        else if (gameObject.name == "Ground4") Ground4Enemy();
        else if (gameObject.name == "Ground5") Ground5Enemy();
    }

    void Ground1Enemy()
    {
        for (int i=0; i<5; i++)
        {
            Vector3 pos = new Vector3(Random.Range(45f, 125f), 16f, 0);
            Instantiate(rabbit, pos, Quaternion.Euler(0f, 0f, 0f));
            num.rabbitNum++;
            //Debug.Log(stateMachine.RabbitNum);
        }
        for (int i =0; i<3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(45f, 125f), 16f, 0);
            Instantiate(bear, pos, Quaternion.Euler(0f, 0f, 0f));
            num.bearNum++;
        }
    }

    void Ground2Enemy()
    {
        Vector3 pos = new Vector3(Random.Range(137f, 151f), -1f, 0);
        Instantiate(rabbit, pos, Quaternion.Euler(0f, 0f, 0f));
        num.rabbitNum++;

        pos = new Vector3(Random.Range(137f, 151f), -1f, 0);
        Instantiate(bear, pos, Quaternion.Euler(0f, 0f, 0f));
        num.bearNum++;
    }
    void Ground3Enemy()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(60f, 95f), -15f, 0);
            Instantiate(rabbit, pos, Quaternion.Euler(0f, 0f, 0f));
            num.rabbitNum++;
        }
        for (int i = 0; i < 2; i++)
        {
            Vector3 pos = new Vector3(Random.Range(60f, 95f), -15f, 0);
            Instantiate(bear, pos, Quaternion.Euler(0f, 0f, 0f));
            num.bearNum++;
        }
    }
    void Ground4Enemy()
    {
        for (int i=0; i<3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(155f, 216f), -39f, 0);
            Instantiate(rabbit, pos, Quaternion.Euler(0f, 0f, 0f));
            num.rabbitNum++;
        }
        for (int i =0; i<3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(155f, 216f), -39f, 0);
            Instantiate(bear, pos, Quaternion.Euler(0f, 0f, 0f));
            num.bearNum++;
        }
    }
    void Ground5Enemy()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(236f, 270f), -78f, 0);
            Instantiate(rabbit, pos, Quaternion.Euler(0f, 0f, 0f));
            num.rabbitNum++;
        }
        for (int i = 0; i < 2; i++)
        {
            Vector3 pos = new Vector3(Random.Range(236f, 270f), -78f, 0);
            Instantiate(bear, pos, Quaternion.Euler(0f, 0f, 0f));
            num.bearNum++;
        }
    }

}
