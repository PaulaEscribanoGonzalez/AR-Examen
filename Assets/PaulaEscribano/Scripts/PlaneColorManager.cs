using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneColorManager : MonoBehaviour
{
    ARPlaneManager planeManager;

    public Color colorZona1 = Color.red;
    public Color colorZona2 = Color.gray;

    void Start()
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            Color colorToApply = Color.white;

            if (ZoneSelector.Instance != null)
            {
                if (ZoneSelector.Instance.selectedZone == 1)
                    colorToApply = colorZona1;
                else if (ZoneSelector.Instance.selectedZone == 2)
                    colorToApply = colorZona2;
            }

            var meshRenderer = plane.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = colorToApply;
            }
        }
    }

    private void OnDestroy()
    {
        if (planeManager != null)
            planeManager.planesChanged -= OnPlanesChanged;
    }
}
