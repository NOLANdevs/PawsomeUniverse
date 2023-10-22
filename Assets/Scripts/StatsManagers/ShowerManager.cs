using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    public CleanBar cleanBar;
    public Item showerItem;
    private bool isDragging;

    public GameObject particleSystemHolder;
    private ParticleSystem showerParticleSystem;

    private ParticleSystem.EmissionModule em;

    [SerializeField] private AudioSource showerSound;


    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private void Start()
    {
        showerParticleSystem = particleSystemHolder.GetComponent<ParticleSystem>();
        em = showerParticleSystem.emission;

    }

    private void Update()
    {
        if (isDragging)
        {
            // Activate the particle system
            if (showerParticleSystem != null && em.enabled != true)
            {
                em.enabled = true;
            }
        }
        else
        {
            // Deactivate the particle system
            if (showerParticleSystem != null && em.enabled == true)
            {
                em.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Increase cleanliness
        if (cleanBar != null && other.CompareTag("Player"))
        {
            if (!(other.GetComponent<Animal>().isDragged))
            {
                showerSound.Play();
                cleanBar.CleanAnimal(showerItem.statsIncreaseAmount);
            }
        }
    }
}
