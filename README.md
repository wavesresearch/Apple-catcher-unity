# Apple-catcher-unity
A made with unity realistic version of the apple catcher game in python

## Apple Catcher Unity–Python Socket Integration

**Unity version:** 6000.19f1
**Python version:** 3.10

---

### Overview

This project demonstrates real-time communication between a Python script and a Unity 3D game (`Apple_catcher.exe`) using TCP sockets. A simulated EEG signal generator in Python sends commands to Unity, which triggers hand animations to catch falling apples, and Unity responds with apple position outcomes.

---

### Prerequisites

* **Operating System:** Windows 10 or higher
* **Python:** 3.10 installed and added to PATH
* **Unity Build:** `Apple_catcher.exe` and `Player.exe` built from Unity 6000.19f1
* **Network Configuration:** Localhost (`127.0.0.1`) communication over port `5005`

---

### Files

* **Player.exe**: Python-driven client simulator for EEG-based hand selection.
* **Apple\_catcher.exe**: Unity-built game executable that animates falling apples and hand catch logic.
* **player.py**: Python script implementing socket client logic.
* **Demonstration.mp4** shows how the working project should look like

---

### How It Works

1. **Python (Player.exe)**

   * Connects to Unity server at `127.0.0.1:5005`.
   * Waits for Unity to start the game (e.g., Play button pressed).
   * Periodically chooses a random hand (1 = Left, 2 = Right) to catch the apple.
   * Sends the hand selection to Unity via TCP.

2. **Unity (Apple\_catcher.exe)**

   * Hosts a TCP server listening on `127.0.0.1:5005`.
   * Randomly determines which side an apple will fall (1 = Left, 2 = Right).
   * On receiving a hand selection from Python, triggers the corresponding hand animation.
   * Sends back the actual apple side to Python (1 or 2) indicating whether the catch was correct.

---

### Usage

1. **Launch Python Client**

   ```bash
   cd path/to/Player
   python player.py
   ```


1. **Launch Unity Game Server**

   ```bash
   cd path/to/Apple_catcher
   Apple_catcher.exe
   ```


---

### Configuration

* **IP Address & Port:** Adjust `HOST` and `PORT` constants in `player.py` and Unity socket script if needed.
* **Timing & Frequency:** Modify `sleep` intervals in `player.py` to change selection frequency.

---

### Troubleshooting

* **Connection Refused:** Ensure no firewall blocks port 5005 and both executables target `127.0.0.1`.
* **No Response from Unity:** Verify Python  is running and ready to accept connections before starting `Apple_catcher.exe`.
* **Unexpected Values:** Log raw messages in both scripts to debug encoding or line-break issues.

---

### License & Credits

* Developed by \[Mathias] 2025
* Inspired by EEG-based interaction research

---

For questions or contributions, please open an issue or pull request on the project repository.
