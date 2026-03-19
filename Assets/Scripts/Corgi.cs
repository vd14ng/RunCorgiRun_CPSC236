using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DrunkSprite;
    
    private SpriteRenderer spriteRenderer;
    private bool isDrunk = false;
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
            print("bone hit");
        }

        if (other.tag == "Pill")
        {
            print("pill hit");
        }
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
