# AR Heart Demo

This repository contains a Unity-based augmented reality (AR) project that demonstrates how to overlay a video of a beating heart onto a real-world image target. The application is built using the Vuforia Engine.

## How it Works

The application uses the device's camera to recognize a specific image target. Once the target is detected, a video of an animated heart is played over it, creating an augmented reality effect. When the target is no longer in view, the video pauses.

### Key Components:

*   **Unity:** The core 3D development platform used to build the application.
*   **Vuforia:** An augmented reality software development kit (SDK) that enables the creation of AR experiences.
*   `VideoController.cs`: This script manages the AR interaction. It uses Vuforia's `ITrackableEventHandler` to detect when the image target is found or lost, and controls the playback of the heart video accordingly.
*   `DelayInt.cs`: This script creates a simple fade-out effect for a UI element at the start of the application, likely for a splash screen.

## Getting Started

To run this project, you will need to have Unity and the Vuforia Engine package installed. You can then clone this repository and open the project in the Unity Editor. You will also need to provide your own image target or use the one included in the project assets.