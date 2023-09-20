using UnityEngine;

public class Line : MonoBehaviour
{
    private Vector2 direction;
    private Transform BallRefStartPoint { get; set; }
    private LineRenderer LineRender { get; set; }

    [SerializeField] LayerMask mask;

    private void Awake()
    {
        LineRender = GetComponent<LineRenderer>();
        BallRefStartPoint = GameObject.Find("ball").transform;

        Ball.OnBallDestroy += Ball_OnBallDestroy;
    }

    private void OnDestroy()
    {
        Ball.OnBallDestroy -= Ball_OnBallDestroy;
    }

    private void Ball_OnBallDestroy()
    {
        if(ResultUI.Instance)
        {
            return;
        }

        BallRefStartPoint.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(TouchArea.dragDistance < 0.2f || Ball.Instance || ResultUI.Instance)
        {
            LineRender.positionCount = 0;
            return;
        }

        if(TouchArea.isPressing)
        {
            var inputPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = ((Vector2)BallRefStartPoint.position - inputPosition).normalized;

            var result = Physics2D.Raycast(BallRefStartPoint.position, direction, Mathf.Infinity, mask);
            if (result.collider)
            {
                LineRender.positionCount = 3;

                LineRender.SetPosition(0, BallRefStartPoint.position);
                LineRender.SetPosition(1, result.point);

                var reflectionDirection = Vector2.Reflect(direction, result.normal);
                var reflectionResult = Physics2D.Raycast(result.point + reflectionDirection.normalized, reflectionDirection, Mathf.Infinity, mask);
                if (reflectionResult.collider)
                {
                    LineRender.SetPosition(2, reflectionResult.point);
                }
            }
        }

        if(!TouchArea.isPressing)
        {
            BallRefStartPoint.gameObject.SetActive(false);
            var ballPrefab = Resources.Load<Rigidbody2D>("ball");
            var ball = Instantiate(ballPrefab, BallRefStartPoint.position, Quaternion.identity, null);
            ball.AddForce(direction * 5.0f, ForceMode2D.Impulse);
            TouchArea.dragDistance = 0.0f;
        }
    }
}
