using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DrunkSprite;
    
    private SpriteRenderer spriteRenderer;
    private bool isDrunk = false;
    private bool isPlastered = false;
    private Coroutine soberUpCoroutine;

    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 4);
            randomMoveCounter = Random.Range(GameParameters.CorgiMinimumRandomMoveLength, GameParameters.CorgiMaximumRandomMoveLength);
            lastRandomDirection = direction;
        }
        switch (direction)
        {
            case 0:
                Move(new Vector3(1, 0));
                break;
            case 1:
                Move(new Vector3(-1, 0));
                break;
            case 2:
                Move(new Vector3(0, 1));
                break;
            case 3:
                Move(new Vector3(0, -1));
                break;
        }

        randomMoveCounter--;
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        Move(direction);
    }
    
    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkeness(direction);
        
        FaceCorrectDirection(direction);
        
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime;
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0);

        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }

    private Vector2 ApplyDrunkeness(Vector2 direction)
    {
        if (!isDrunk)
        {
            return direction;
        }

        direction.x = direction.x * -1;
        direction.y = direction.y * -1;
        return direction;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }

        if (other.tag == "Bone")
        {
            AddPointToScore();
            Destroy(other.gameObject);
        }

        if (other.tag == "Pill")
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    private void AddPointToScore()
    {
        ScoreKeeper.AddPoint();
        print("Score is: " + ScoreKeeper.GetScore());
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Moonshine")
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

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void StartSoberingUp()
    {
        if (soberUpCoroutine != null)
        {
            StopCoroutine(soberUpCoroutine);
        }
        soberUpCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        isPlastered = false;
        ChangeToNormalSprite();
    }

    private void ChangeToNormalSprite()
    {
        spriteRenderer.sprite = NormalSprite;
    }

    private void ChangeToDrunkSprite()
    {
        spriteRenderer.sprite = DrunkSprite;
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
}
