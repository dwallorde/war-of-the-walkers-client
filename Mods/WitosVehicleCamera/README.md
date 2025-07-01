# 🚗 Vehicle Camera Mod - Complete XML Configuration Tutorial

This document provides a complete guide to configuring XML files used by the Vehicle Camera Mod for *7 Days to Die*. It explains file structure, individual sections, and integration with the mod's code to adjust camera behavior in vehicles, including cinematic mode activation, shader effects, seat position corrections, and third-person camera overrides.

---

## 📌 1. Introduction

The Vehicle Camera Mod uses two primary XML files:

- **CameraConfigs.xml**: Global camera configuration.
- **vehicles.xml**: Specific vehicle properties.

These files allow extensive customization without recompiling the mod code.

---

## 📂 2. XML File Structure

XML files control:

- Cinematic mode and visual filters
- Shader effects
- Position corrections (SeatPoses)
- Vehicle-specific properties (seat, rotation, etc.)

---

## 🔧 3. CameraConfigs.xml

Located at: `Mods/WitosVehicleCamera/Config/CameraConfigs.xml`

### 🎬 CinematicCamera

```xml
<CinematicCamera cinematic="true" filter="true" />
```

- `cinematic`: Enables cinematic orbit camera.
- `filter`: Applies visual effects from asset bundles.

### 🎨 Shaders

```xml
<Shaders>
  <Shader id="NightVision" BundlePath="camerafilters.unity3d" MaterialName="NightVisionEffectMaterial" active="true" />
</Shaders>
```

Press `F5` to toggle visual filters if active.

### 🎯 SeatPoses

```xml
<SeatPoses>
  <SeatPose id="40" x="0.0" y="1.2" z="-0.24" />
</SeatPoses>
```

| Attribute            | Description                       |
|----------------------|-----------------------------------|
| `id`                 | Seat pose ID used by vehicle seat.|
| `x, y, z`            | Camera position correction.       |

### ⚙️ Other Sections

```xml
<Commands>
  <Command name="reloadcameraxml" />
</Commands>
```

## 🚘 4. vehicles.xml

### 🛋️ Seat Example

```xml
<property class="seat0">
  <property name="class" value="Seat"/>
  <property name="pose" value="40"/>
  <property name="position" value="-0.38, 0.46, 0"/>
  <property name="rotation" value="350, 0, 0"/>
  <property name="VehicleThirdPerson" value="false"/>
</property>
```

---

## 🛠️ 5. Code Integration

### 📥 XML Loading

`BuildCameraModes()` creates:
- Seat  						<property name="VehicleCameraSeat" value="true"/>		
- DefaultThirdPerson on off 	<property name="VehicleThirdPerson" value="false"/>
- CinematicCamera          		<CinematicCamera cinematic="true" filter="true" />
- Unity/CameraXML modes 		<property name="VehicleCameraModel" value="true"/>

### 🔄 Seat Mode: Correction and Rotation

- Reads seat position and rotation.
- Applies corrected and rotated pose.

### 🚫 Overriding DefaultThirdPerson Mode

Disable the game's native third-person camera:

```xml
<property name="VehicleThirdPerson" value="false"/>
```

---

## 📷 6. Custom Cameras (XML)

Define multiple cameras using `Camera0`, `Camera1`, etc.:

```xml
<property class="Camera0">
    <property name="VehicleCameraCustom" value="0.0,1.0,-4"/>
    <property name="CameraXMLMode" value="180" />
    <property name="CameraXMLRotation" value="90,90,0" />
</property>

<property class="Camera1">
    <property name="VehicleCameraCustom" value="0,20,0"/>
    <property name="CameraXMLMode" value="fixed" />
    <property name="CameraXMLRotation" value="90,90,0" />
</property>

<property class="Camera2">
    <property name="VehicleCameraCustom" value="3,3,3"/>
</property>

add more cameras no limits
```

| Property                | Description                                  |
|-------------------------|----------------------------------------------|
| `VehicleCameraCustom`   | Local camera position (x,y,z).               |
| `CameraXMLMode`         | Camera type: `180`, `fixed`, `360` (default).|
| `CameraXMLRotation`     | Camera rotation (x,y,z) if mode is 180/fixed.|

**CameraXMLMode Types:**
- **180:** Free camera limited to 180 degrees rotation (mouse control).
- **fixed:** Static camera.
- **360:** Fully free camera (default).

---

## ✅ 7. Tips and Best Practices

- Define multiple cameras for spectacular views.
- Use `VehicleThirdPerson` to toggle native third-person camera.
- If the first-person camera looks incorrect, review the corresponding `SeatPose` corrections in `CameraConfigs.xml`.

---

## 📃 8. Complete CameraConfigs.xml Example

See detailed examples in provided sections above.

---

## 🎮 Camera Cycling In-game

Press `L` to cycle between:

1. Seat (First person)
2. Native third-person
3. Custom cameras (`Camera0`, `Camera1`, ...)
4. Cinematic camera (if enabled)



---

Enjoy customizing your vehicle cameras! 

Witos