using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    #region Singleton class: Magnet

    public static Magnet Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    #endregion

    float magnetForce = 80f;

    List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
    Transform magnet;

    void Start() {
        magnet = transform;
        affectedRigidbodies.Clear();
    }

    void FixedUpdate() {
        if (!Game.isGameover && Game.isMoving) {
            foreach (Rigidbody rb in affectedRigidbodies) {
                rb.AddForce((magnet.position - rb.position) * magnetForce * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        string tag = other.tag;

        if (!Game.isGameover && (tag.Equals("GoodO") || tag.Equals("BadO"))) {
            AddToMagnetField(other.attachedRigidbody);
        }
    }

    void OnTriggerExit(Collider other) {
        string tag = other.tag;

        if (!Game.isGameover && (tag.Equals("GoodO") || tag.Equals("BadO"))) {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddToMagnetField(Rigidbody rb) {
        affectedRigidbodies.Add(rb);
    }

    public void RemoveFromMagnetField(Rigidbody rb) {
        affectedRigidbodies.Remove(rb);
    }
}
