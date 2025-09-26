using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer mVideoPlayer;

    [SerializeField]
    private GameObject mHandTarget;

    [SerializeField]
    private ARTrackedImageManager m_TrackedImageManager;

    private bool _isAnyImageTracking = false;

    private void OnEnable()
    {
        if (m_TrackedImageManager != null)
        {
            m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    private void OnDisable()
    {
        if (m_TrackedImageManager != null)
        {
            m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        bool isCurrentlyTracking = false;
        // Check all trackables (tracked images)
        foreach (var trackedImage in m_TrackedImageManager.trackables)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                isCurrentlyTracking = true;
                // Move the video player to the tracked image's position and rotation.
                // This assumes one video player controlled by any tracked image.
                mVideoPlayer.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
                break; // Exit after finding the first tracked image.
            }
        }

        if (isCurrentlyTracking && !_isAnyImageTracking)
        {
            OnTrackingFound();
        }
        else if (!isCurrentlyTracking && _isAnyImageTracking)
        {
            OnTrackingLost();
        }

        _isAnyImageTracking = isCurrentlyTracking;
    }

    protected virtual void OnTrackingFound()
    {
        mVideoPlayer.Play();
        if (mHandTarget != null)
        {
            mHandTarget.SetActive(false);
        }
    }

    protected virtual void OnTrackingLost()
    {
        mVideoPlayer.Pause();
        if (mHandTarget != null)
        {
            mHandTarget.SetActive(true);
        }
    }
}