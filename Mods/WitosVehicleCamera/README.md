# 🛞 VehicleCameraCycle - Advanced Vehicle Camera Mod for 7 Days to Die

🎥 First-person seat views, custom XML cameras, cinematic orbit mode, and real-time visual filters!

---

## 🚀 Features

- Switch between multiple vehicle camera modes with `L`
- Enable cinematic filters with `F5`
- First-person seat camera with optional HUD (reticle)
- Third-person camera (native)
- XML-defined cameras (360°, 180°, fixed)
- Unity prefab-based cameras (`Camera`, `Camera180`, `Camera360`)
- Cinematic orbiting camera with zoom and rotation
- Shader-based filters using AssetBundles

---

## 🎮 Controls

| Key     | Action                                  |
|---------|------------------------------------------|
| `L`     | Cycle camera mode                        |
| `F5`    | Change cinematic filter (if enabled)     |
| Mouse   | Rotate in supported camera modes         |
| Scroll  | Zoom in/out (cinematic mode only)        |

---

## 🛠 Installation

Place the mod inside your `Mods/` directory:

7DaysToDie/Mods/VehicleCameraCycle/

kotlin
Copiar
Editar

Structure should look like this:

VehicleCameraCycle/
├── Config/
│ └── CameraConfigs.xml
├── Resources/
│ └── yourShader.bundle
└── VehicleCameraCycle.dll

yaml
Copiar
Editar

---

## 🔧 Vehicle Camera Setup (Example)

### Seat View (1st person):
```xml
<property name="position" value="0.3,1.1,0.2" />
<property name="rotation" value="0,180,0" />
<property name="reticle" value="true" />
Rear Camera:
xml

<property name="CameraRear.CameraXMLMode" value="180" />
<property name="CameraRear.VehicleCameraCustom" value="0,2,-5" />
<property name="CameraRear.CameraXMLRotation" value="0,180,0" />
Hood Camera:
xml

<property name="CameraHood.VehicleCameraCustom" value="0,1.5,2.5" />
🎬 Enable Cinematic Mode & Filters
In CameraConfigs.xml:

xml

<CameraConfigs>
  <CinematicCamera cinematic="true" filter="true" />
</CameraConfigs>
Add filters:
xml

<Shader id="RetroVHS" active="true"
        BundlePath="Shaders/vhs"
        MaterialName="RetroMat" />
✅ Compatible With:
Vanilla and modded vehicles

Multiplayer

Unity prefab-based cameras

Canvas-based HUDs (reticle)

👤 Credits
Mod created by: [Witos]
Designed for immersive gameplay, video creation, and full vehicle camera control.
