using UnityEngine;

public class PlayerMover : MonoBehaviour, IPlayerMover
{
    private Rigidbody rb;

    private float turnSpeed = 25.0f;
    [SerializeField]
    public float speed { get; set; }
    //private PlayerMover playerMover;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //playerMover = new PlayerMover();
        speed = 10f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var dir = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * speed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * turnSpeed);
    }

}

public interface IPlayerMover
{
    public float speed { get; set; }
}
