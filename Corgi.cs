using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Corgi : MonoBehaviour
{
	private bool isDrunk = false;
    private SpriteRenderer spriteRenderer;
	public Sprite drunkSprite;
	public Sprite soberSprite;
	private Coroutine soberUpCoroutine;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
		direction = ApplyDrunkeness(direction);
        FaceCorrectDirection(direction);
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime;
        //make corgi move
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0);
        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }
	public Vector2 ApplyDrunkeness(Vector2 direction)
	{
		if(isDrunk == true)
		{
			direction.x = -direction.x;
			direction.y = -direction.y;
		}
		return direction;
	}
    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;

        }
	}
	public Vector3 GetPosition()
	{
		return spriteRenderer.transform.position;

    }
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Beer")
		{
			GetDrunk();
			Destroy(other.gameObject);
		}
		else if (other.tag == "Bone")
		{
			print("Bone");
		}		
		else if (other.tag == "Pill")
		{
			print("Pill");
		}	
	}
	public void GetDrunk()
	{
		isDrunk = true;
		ChangeToDrunkSprite();
		StartSoberingUp();
	}
	public void ChangeToDrunkSprite()
	{
		spriteRenderer.sprite = drunkSprite;
	}
	IEnumerator CountdownUntilSober()
	{
		yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
		SoberUp();
	}
	public void StartSoberingUp()
	{
		if(soberUpCoroutine != null)
		{
			StopCoroutine(soberUpCoroutine);
		}
		soberUpCoroutine = StartCoroutine(CountdownUntilSober());

		

	}
	public void SoberUp()
	{
		ChangeToSoberSprite();
		isDrunk = false;
	}
	public void ChangeToSoberSprite()
	{
		spriteRenderer.sprite = soberSprite;
	}
}
