using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D Rb;
    private SpriteRenderer sprite;
    public bool hasBeenActivated;
    private Camera cam;
    CircleCollider2D collider;
    public enum trajectory { straight, sinusoidal };
    public trajectory objectTrajectory;

    //Straight
    [Header("Setup Straight")]
    public Vector2 direction;
    public float speed;
    //Sinusoide
    [Header("Setup sinusoide")]
    [Range(1,10)]
    public float sinusoideAmplitude;
    public AnimationCurve animationCurve;
    private float initialYPos;
    private float initialXPos;
    private float time = 0;


    //Pour une raison inconnue isVisible = false au start pour deux frame on temporise donc pour éviter la destruction immédiate de l'objet
    IEnumerator ActivEnemy()
    {
        while (GetComponent<SpriteRenderer>().isVisible == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
        hasBeenActivated = true;
        collider.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        cam = Camera.main;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
        initialYPos = transform.position.y;
        initialXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.WorldToScreenPoint(transform.position).x < cam.pixelWidth + 10 && hasBeenActivated == false)
        {
            StartCoroutine(ActivEnemy());
        }

        if (objectTrajectory == trajectory.sinusoidal && hasBeenActivated)
        {
            transform.parent = cam.transform;
            if (time <= 1) time += Time.deltaTime;
            else time = 0;
            float lerpParameter = animationCurve.Evaluate(time);
            float newVelocityX = Mathf.Lerp(-sinusoideAmplitude, sinusoideAmplitude, lerpParameter);

            Rb.velocity = new Vector2(-0.5f, newVelocityX);
        }

        if (objectTrajectory == trajectory.straight && Rb.velocity == Vector2.zero && hasBeenActivated)
        {
            transform.parent = cam.transform;
            launchObject();
        }
        //Si l'object été activé et n'est plus visible sur l'écran
        if (!sprite.isVisible && hasBeenActivated == true)
        {
            Destroy(gameObject);
        }
    }

    void launchObject()
    {
        Rb.velocity = direction * speed;
        StartCoroutine(ActivEnemy());
    }
}
