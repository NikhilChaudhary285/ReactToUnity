# 🚀 React Native & Unity — Complete Integration Manual

### React Native • Unity 6 • IL2CPP • Android Build Pipeline • Native Bridge Communication

A production-ready integration workflow demonstrating seamless communication between React Native and Unity, including:

- Unity ↔ React Native bridge communication
- Scene management via native messaging
- Android IL2CPP build fixes
- Gradle pipeline customization
- NDK / SDK environment setup
- Release APK workflow
- Wireless debugging setup

---

# 👨‍💻 Project Information

Author: Nikhil Chaudhary

Project Type: React Native + Unity Integration Prototype

Platform: Android

Unity Version: Unity 6 (6000.x LTS)

Rendering Pipeline: Universal Render Pipeline (URP)

---

# 🏗 Overview

This project demonstrates a complete integration pipeline between a React Native application and an embedded Unity experience.

The system allows React Native to:

- Launch Unity scenes
- Send commands directly to Unity
- Control gameplay flow from React Native UI
- Return back from Unity to React Native seamlessly

The implementation focuses on:

- Stability
- Scalable bridge architecture
- Production-ready Android builds
- Reliable IL2CPP compilation
- Mobile deployment workflows

---

# ✨ Core Features

✅ React Native ↔ Unity communication bridge

✅ Dynamic scene loading from React Native

✅ IL2CPP Android support

✅ Custom Gradle IL2CPP build task

✅ NDK 27 support

✅ Android API 34 compatible

✅ Multi-ABI support (ARMv7 + ARM64)

✅ Wireless debugging support

✅ Production-ready APK pipeline

✅ Scene-based gameplay launcher

✅ Persistent Unity bridge manager

✅ Decoupled architecture between app layers

---

# 📦 Technology Stack

| Technology | Purpose |
|---|---|
| React Native | Main mobile application |
| Unity 6 | Embedded game engine |
| TypeScript | React Native logic |
| C# | Unity gameplay bridge |
| IL2CPP | Native Unity compilation |
| Gradle | Android build pipeline |
| Android SDK | Android development |
| Android NDK | Native IL2CPP toolchain |

---

# ⚙️ SECTION 1 — SYSTEM ENVIRONMENT SETUP

Before building the project, configure the environment exactly as shown below.

---

## 🔧 System Variables

### JAVA_HOME

C:\Program Files\Java\jdk-17.0.12

### ANDROID_SDK_ROOT

C:/Users/Unity/AppData/Local/Android/Sdk

### PATH Variables

Add both:

%JAVA_HOME%\bin

%ANDROID_SDK_ROOT%\platform-tools

---

## 📌 Required Versions

| Tool | Version |
|---|---|
| JDK | 17 |
| NDK | 27.1.12297006 |
| Node.js | v18 or v20 |
| Unity | Unity 6 |
| Android API | API 34+ |

---

# 🎮 SECTION 2 — UNITY SIDE (BRIDGE SETUP)

# 🛠 Unity Build Settings

Open:

File → Build Settings → Android

Enable:

Export Project

---

## 📌 Player Settings

### Scripting Backend

IL2CPP

### API Compatibility

.NET Framework

### Target Architectures

ARMv7

ARM64

---

# 🧩 Unity Bridge Object Setup

Create an Empty GameObject named:

UnityBridge

Attach:

BridgeController.cs

This object becomes the permanent communication bridge between React Native and Unity.

---

# 📄 Unity Bridge Responsibilities

The Unity bridge handles:

- Incoming React Native commands
- Scene loading
- UI updates
- Persistent runtime communication
- Multi-scene support

---

# 🔄 Unity Communication Flow

React Native

│

├── postMessage()

│

▼

UnityBridge GameObject

│

├── LoadSpecificLevel()

│

▼

SceneManager.LoadSceneAsync()

│

▼

Scene UI Updates

---

# 📱 SECTION 3 — REACT NATIVE SIDE

The React Native application acts as the launcher and UI layer.

---

# 🎯 React Native Responsibilities

The app handles:

- Main menu UI
- Unity lifecycle management
- Scene selection
- Bridge communication
- Exit handling
- Device UI management

---

# 🔄 React Native → Unity Bridge Call

unityRef.current.postMessage(
    'UnityBridge',
    'LoadSpecificLevel',
    sceneName
);

---

# 🧠 Bridge Communication Structure

(GameObjectName, MethodName, Parameter)

Example:

('UnityBridge', 'LoadSpecificLevel', 'Scene1')

---

# 📂 Scene Selection Workflow

React Native Button

        │

        ▼

UnityView Mounted

        │

        ▼

postMessage Sent

        │

        ▼

UnityBridge Receives Command

        │

        ▼

Scene Loads

        │

        ▼

UI Updates

---

# ⚙️ SECTION 4 — ANDROID SYSTEM FIXES

# 📄 AndroidManifest Configuration

The Unity activity runs inside its own Android process:

android:process=":Unity"

Benefits:

- Better memory isolation
- Improved app stability
- Cleaner Unity lifecycle management

---

# 🔒 ProGuard Rules

Prevent Unity bridge stripping during release builds:

-keep class com.azesmwayreactnativeunity.** { *; }

---

# 🧱 Advanced IL2CPP Gradle Fix

A custom Gradle task manually controls:

- IL2CPP execution
- NDK path mapping
- ABI compilation
- Environment variables
- Native library generation

---

# ❓ Why This Fix Is Needed

Default Unity exports can fail during React Native integration because:

- Gradle loses NDK references
- Environment variables are not propagated correctly
- IL2CPP compilation becomes unstable
- Multi-ABI builds fail intermittently

---

# ✅ Solution

The custom Gradle task uses:

ProcessBuilder

to directly invoke:

il2cpp.exe

with controlled environment variables.

---

# 🧠 IL2CPP Build Pipeline

Gradle Build

    │

    ▼

Custom BuildIl2CppTask

    │

    ▼

ProcessBuilder

    │

    ▼

IL2CPP Native Compilation

    │

    ▼

libil2cpp.so Generated

    │

    ▼

APK Packaging

---

# 📦 Multi-ABI Support

The project compiles:

armeabi-v7a

arm64-v8a

Benefits:

- Wider Android compatibility
- Better performance on modern devices
- Google Play compliance

---

# 🚀 SECTION 5 — COMMAND LINE WORKFLOW

# 📱 Developer Mode

Check connected devices:

adb devices

Run the app:

npx react-native run-android

---

# 📦 Release APK Build

Navigate:

cd android

Clean project:

./gradlew clean

Build release APK:

./gradlew assembleRelease

Generated APK location:

android/app/build/outputs/apk/release/app-release.apk

---

# 📡 Wireless Debugging Setup

## Step 1

Open Developer Menu by shaking the device.

## Step 2

Open:

Settings → Debug server host

## Step 3

Enter:

192.168.x.x:8081

Replace with your local machine IP.

## Step 4

Run Metro Bundler and test over WiFi.

---

# 🧠 Architecture Overview

The project follows a layered architecture.

React Native Layer

│

├── UI Navigation

├── Scene Selection

├── Unity Lifecycle

└── Native Bridge Calls

        │

        ▼

Unity Native Bridge

│

├── Scene Loading

├── UI Updates

├── Persistent Runtime

└── Gameplay Logic

        │

        ▼

Android Native System

│

├── Gradle Pipeline

├── IL2CPP Build System

├── NDK Toolchain

└── APK Packaging

---

# 🏗 Design Principles Used

# ✅ Separation of Concerns

React Native handles:

- Mobile UI
- Navigation
- Native controls

Unity handles:

- Rendering
- Gameplay
- Scene management

---

# ✅ Persistent Bridge Architecture

DontDestroyOnLoad() ensures:

- Stable communication
- Cross-scene persistence
- Reduced initialization overhead

---

# ✅ Async Scene Loading

Unity uses:

SceneManager.LoadSceneAsync()

Benefits:

- Smooth transitions
- Non-blocking scene loading
- Better mobile performance

---

# ✅ Production Build Stability

Custom Gradle scripting ensures:

- Reliable IL2CPP builds
- Controlled environment setup
- Multi-architecture compilation

---

# 📂 Recommended Project Structure

ReactNativeProject/

│

├── android/

├── ios/

├── src/

├── App.tsx

└── package.json

UnityExport/

│

├── unityLibrary/

├── launcher/

└── gradle/

---

# 🔥 Key Learnings

This project demonstrates:

- Native bridge communication
- Unity embedding inside React Native
- Android IL2CPP troubleshooting
- Gradle automation
- NDK environment management
- Mobile build optimization
- Cross-platform architecture
- Production Android deployment
- Scene-based Unity control systems

---

# ⚡ Performance Considerations

The project is optimized for:

- Reduced bridge overhead
- Stable Unity lifecycle handling
- Async scene loading
- Native IL2CPP performance
- Android memory isolation
- ABI compatibility

---

# 🧪 Possible Extensions

| Feature | Extension Approach |
|---|---|
| Multiplayer | Add Socket.IO or Photon |
| Authentication | Firebase Auth |
| Save System | Cloud Firestore |
| Analytics | Firebase Analytics |
| Push Notifications | FCM |
| Asset Streaming | Addressables |
| Deep Linking | React Navigation + Native Modules |
| Live Events | Remote Config |

---

# 📚 Final Summary

This project provides a complete production-ready workflow for integrating Unity into a React Native mobile application.

It covers:

- Environment setup
- Native bridge communication
- Scene management
- Android build fixes
- IL2CPP compilation
- Gradle automation
- APK generation
- Wireless debugging

The architecture is designed to be scalable, maintainable, and stable for real-world mobile applications that combine React Native and Unity together.

---

# 👨‍💻 Author

Nikhil Chaudhary

React Native & Unity Developer

---

# 📄 License

This project is provided for educational and development reference purposes.

---

⭐ Feel free to explore my repositories and connect with me. I’m always open to discussions around Unity development, React Native integration, mobile architecture, IL2CPP pipelines, and scalable game systems.
