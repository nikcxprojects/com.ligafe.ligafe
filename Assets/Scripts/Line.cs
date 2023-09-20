using UnityEngine;

public class Line : MonoBehaviour
{
    private Vector2 direction;
    private Transform BallRefStartPoint { get; set; }
    private LineRenderer LineRender { get; set; }

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
            LineRender.positionCount = 2;
            var inputPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = ((Vector2)BallRefStartPoint.position - inputPosition).normalized;

            LineRender.SetPosition(0, BallRefStartPoint.position);
            LineRender.SetPosition(1, (Vector2)BallRefStartPoint.position + direction.normalized * 2.0f);
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
