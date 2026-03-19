using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
	private bool isDrunk = false;
	private bool isPlastered = false;
    private SpriteRenderer spriteRenderer;
	public Sprite drunkSprite;
	public Sprite soberSprite;
	private Coroutine soberUpCoroutine;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	public void Update()
	{
		if(isPlastered)
		{	
			MoveRandomly();
		}
	}
	
	private void MoveRandomly()
	{
		int direction = Random.Range(0,4);
		switch (direction)
		{
			case 0:
				Move(new Vector2(1,0));
				break;
			case 1:
				Move(new Vector2(-1,0));
				break;
			case 2:
				Move(new Vector2(0,1));
				break;
			case 3:
				Move(new Vector2(0,-1));
				break;
		}
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

	public void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "Moonshine")
		{
			Destroy(other.gameObject);
			GetPlastered();
		}
	}

	private void GetPlastered()
	{
		isPlastered = true;
		ChangeToDrunkSprite();
		StartSoberingUp();
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
		isPlastered = false;
	}
	public void ChangeToSoberSprite()
	{
		spriteRenderer.sprite = soberSprite;
	}
}
