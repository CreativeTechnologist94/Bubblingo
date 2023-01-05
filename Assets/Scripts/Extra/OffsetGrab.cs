using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrab : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        StoreInteractor(args);
        MatchAttachmentPoints(args);
    }

    private void StoreInteractor(SelectEnterEventArgs args)
    {
        interactorPosition = args.interactorObject.GetAttachTransform(args.interactableObject).localPosition;
        interactorRotation = args.interactorObject.GetAttachTransform(args.interactableObject).localRotation;
    }

    private void MatchAttachmentPoints(SelectEnterEventArgs args)
    {
        bool hasAttach = attachTransform != null;
        args.interactorObject.GetAttachTransform(args.interactableObject).position = hasAttach ? attachTransform.position : transform.position;
        args.interactorObject.GetAttachTransform(args.interactableObject).rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ResetAttachmentPoint(args);
        ClearInteractor(args);
    }

    private void ResetAttachmentPoint(SelectExitEventArgs args)
    {
        args.interactorObject.GetAttachTransform(args.interactableObject).localPosition = interactorPosition;
        args.interactorObject.GetAttachTransform(args.interactableObject).localRotation = interactorRotation;
    }

    private void ClearInteractor(SelectExitEventArgs args)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
