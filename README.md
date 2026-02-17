# com2coms

Serial bridge utility project.

## C# original (`com2coms/com2coms`)

The original implementation is a C# WinForms application located in `com2coms/com2coms`.

It provides the baseline serial bridging behavior that the Python version mirrors.

## Python rewrite (`com2comspy`)

The repository contains a Python rewrite of the original C# tool in `com2comspy`.

### Features
- 3 COM port selectors with shared baud rate
- Open/Close all selected ports
- Forwarding between opened ports
- ASCII and HEX live logs
- Colored per-port output in the UI

### Run

From `com2comspy`:

```bat
run.bat
```

Or manually:

```bash
pip install -r com2comspy/requirements.txt
python com2comspy/app.py
```

For more details, see `com2comspy/README.md`.