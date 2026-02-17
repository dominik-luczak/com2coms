# com2comspy

Python rewrite of the `com2coms` serial bridge tool.

## Author
- Dominik Luczak

## Features
- 3 serial port selectors (SerialPort 1/2/3)
- Shared baud rate setting
- `OpenALL` / `CloseALL` behavior
- Bidirectional forwarding among all opened ports
- ASCII and HEX logs with per-port colors

## Default serial config
- Frame format: `8N1` (8 data bits, No parity, 1 stop bit)
- Flow control: disabled by default

## Requirements
- Python 3.10+
- Windows (tested target)
- `pyserial`

## Install
```bash
pip install -r requirements.txt
```

## Run
```bash
python app.py
```
