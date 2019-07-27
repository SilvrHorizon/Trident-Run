using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruchPillar : MonoBehaviour
{

    public enum PillarState
    {
        GoingUp,
        GoingDown,
        WaitBottom,
        WaitTop
    };

    [SerializeField] PillarState currentState = PillarState.WaitTop;
    bool modeChanged = true;

    Vector2 velocity = new Vector2(0, 0);

    [SerializeField] bool fromTop = true;
    [SerializeField] GameObject head;

    [SerializeField] float timeToBottom = 5.0f;
    [SerializeField] float timeToTop = 5.0f;

    [SerializeField] float waitTimeBottom = 5.0f;
    [SerializeField] float waitTimeTop = 5.0f;

    [SerializeField] GameObject topTarget;
    [SerializeField] GameObject bottomTarget;

    [SerializeField] GameObject pillarTop;
    [SerializeField] GameObject pillarBottom;

    float timer;

    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        if (modeChanged)
        {
            if (currentState == PillarState.WaitTop || currentState == PillarState.GoingDown)
            {
                Vector2 vToTop = topTarget.transform.position - pillarTop.transform.position;
                gameObject.GetComponent<Transform>().position += new Vector3(0, vToTop.y, 0);
            }
            else if (currentState == PillarState.WaitBottom || currentState == PillarState.GoingUp)
            {
                Vector2 vToBottom = bottomTarget.transform.position - pillarBottom.transform.position;
                gameObject.GetComponent<Transform>().position += new Vector3(0, vToBottom.y, 0);
            }

            if (currentState == PillarState.GoingDown)
            {
                timer = timeToBottom;
                velocity = new Vector2(0, bottomTarget.transform.position.y - pillarBottom.transform.position.y) / timeToBottom;
            }
            else if (currentState == PillarState.GoingUp)
            {
                timer = timeToTop;
                velocity = new Vector2(0, topTarget.transform.position.y - pillarTop.transform.position.y) / timeToTop;
            }
            else if (currentState == PillarState.WaitBottom)
            {
                velocity = new Vector2(0,0);
                timer = waitTimeBottom;
            }
            else if (currentState == PillarState.WaitTop)
            {
                velocity = new Vector2(0, 0);
                timer = waitTimeTop;
            }
            modeChanged = false;
        }

        GetComponent<Transform>().position += new Vector3(0, velocity.y, 0) * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            TestMode();
        }

    }

    void TestMode()
    {
        switch (currentState)
        {
            case PillarState.GoingDown:
                ChangeMode(PillarState.WaitBottom);
                break;
            case PillarState.WaitBottom:
                ChangeMode(PillarState.GoingUp);
                break;
            case PillarState.GoingUp:
                ChangeMode(PillarState.WaitTop);
                break;
            case PillarState.WaitTop:
                ChangeMode(PillarState.GoingDown);
                break;

        }
    }

    void ChangeMode(PillarState newState)
    {
        modeChanged = true;
        currentState = newState;

    }
}
