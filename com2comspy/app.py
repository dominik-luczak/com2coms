import tkinter as tk
from tkinter import ttk, messagebox
import webbrowser
import serial
from serial.tools import list_ports


BAUD_RATES = [
    "600",
    "1200",
    "2400",
    "4800",
    "9600",
    "14400",
    "19200",
    "38400",
    "57600",
    "115200",
    "128000",
    "230400",
    "256000",
    "460800",
    "500000",
    "576000",
    "921600",
    "1000000",
    "1152000",
    "1500000",
    "2000000",
    "2250000",
]
POLL_INTERVAL_MS = 5


class Com2ComApp:
    def __init__(self, root: tk.Tk) -> None:
        self.root = root
        self.root.title("com2coms")
        self.root.geometry("720x500")
        self.root.minsize(800, 600)

        self.port_in = None
        self.port_out1 = None
        self.port_out2 = None

        self._build_ui()
        self._load_ports()

        self.root.protocol("WM_DELETE_WINDOW", self.on_close)
        self.root.after(POLL_INTERVAL_MS, self.timer_read_tick)

    def _build_ui(self) -> None:
        top = ttk.Frame(self.root, padding=10)
        top.pack(fill=tk.X)

        ttk.Label(top, text="BaudRate").grid(row=0, column=0, sticky=tk.W, padx=(0, 6))

        self.baud_var = tk.StringVar(value="2250000")
        self.baud_combo = ttk.Combobox(top, textvariable=self.baud_var, values=BAUD_RATES, state="readonly", width=10)
        self.baud_combo.grid(row=0, column=1, sticky=tk.W)

        port_frame = ttk.Frame(top)
        port_frame.grid(row=0, column=2, padx=(40, 0), sticky=tk.W)

        self.port_out1_var = tk.StringVar()
        self.port_out2_var = tk.StringVar()
        self.port_in_var = tk.StringVar()

        ttk.Label(port_frame, text="SerialPort 1", foreground="red").grid(row=0, column=0, sticky=tk.W, padx=(0, 6))
        self.port_out1_combo = ttk.Combobox(port_frame, textvariable=self.port_out1_var, state="readonly", width=14)
        self.port_out1_combo.grid(row=0, column=1, sticky=tk.W)

        ttk.Label(port_frame, text="SerialPort 2", foreground="blue").grid(row=1, column=0, sticky=tk.W, padx=(0, 6), pady=(4, 0))
        self.port_out2_combo = ttk.Combobox(port_frame, textvariable=self.port_out2_var, state="readonly", width=14)
        self.port_out2_combo.grid(row=1, column=1, sticky=tk.W, pady=(4, 0))

        ttk.Label(port_frame, text="SerialPort 3", foreground="green").grid(row=2, column=0, sticky=tk.W, padx=(0, 6), pady=(4, 0))
        self.port_in_combo = ttk.Combobox(port_frame, textvariable=self.port_in_var, state="readonly", width=14)
        self.port_in_combo.grid(row=2, column=1, sticky=tk.W, pady=(4, 0))

        button_frame = ttk.Frame(self.root, padding=(10, 0))
        button_frame.pack(fill=tk.X)

        self.open_button = ttk.Button(button_frame, text="OpenALL", command=self.open_close_all)
        self.open_button.pack(side=tk.LEFT)

        clear_button = ttk.Button(button_frame, text="Clear", command=self.clear_logs)
        clear_button.pack(side=tk.LEFT, padx=(8, 0))

        body = ttk.Frame(self.root, padding=10)
        body.pack(fill=tk.BOTH, expand=True)

        ascii_frame = ttk.Frame(body)
        ascii_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        ttk.Label(ascii_frame, text="ASCII").pack(anchor=tk.W)

        hex_frame = ttk.Frame(body)
        hex_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, padx=(8, 0))
        ttk.Label(hex_frame, text="HEX").pack(anchor=tk.W)

        self.text_ascii = tk.Text(ascii_frame, wrap="word")
        self.text_ascii.pack(fill=tk.BOTH, expand=True)

        self.text_hex = tk.Text(hex_frame, wrap="word")
        self.text_hex.pack(fill=tk.BOTH, expand=True)

        self.text_ascii.tag_configure("red", foreground="red")
        self.text_ascii.tag_configure("blue", foreground="blue")
        self.text_ascii.tag_configure("green", foreground="green")

        self.text_hex.tag_configure("red", foreground="red")
        self.text_hex.tag_configure("blue", foreground="blue")
        self.text_hex.tag_configure("green", foreground="green")

        footer = ttk.Frame(self.root, padding=(10, 0, 10, 8))
        footer.pack(fill=tk.X)
        ttk.Label(footer, text="v 1.03").pack(side=tk.RIGHT)
        ttk.Label(footer, text="Serial config 8N1 (8 data bits, no parity, 1 stop bit); Author: Dominik Luczak").pack(side=tk.LEFT)

        link = tk.Label(footer, text="Designed by Luczak.eu", fg="gray", cursor="hand2")
        link.pack(side=tk.RIGHT, padx=(0, 10))
        link.bind("<Button-1>", lambda _e: webbrowser.open("http://luczak.eu"))

    def _load_ports(self) -> None:
        ports_raw = sorted([port.device for port in list_ports.comports()])

        len4_ports = [port for port in ports_raw if len(port) == 4]
        other_ports = [port for port in ports_raw if len(port) != 4]
        ports = len4_ports + other_ports

        self.port_in_combo["values"] = ports
        self.port_out1_combo["values"] = ports
        self.port_out2_combo["values"] = ports

    def clear_logs(self) -> None:
        self.text_ascii.delete("1.0", tk.END)
        self.text_hex.delete("1.0", tk.END)

    def open_close_all(self) -> None:
        if self.open_button.cget("text") == "OpenALL":
            selected_count = sum(
                [
                    bool(self.port_in_var.get()),
                    bool(self.port_out1_var.get()),
                    bool(self.port_out2_var.get()),
                ]
            )

            if selected_count <= 1:
                messagebox.showwarning("Warning", "Two ports are required")
                return

            try:
                baud_rate = int(self.baud_var.get())
            except ValueError:
                messagebox.showwarning("Warning", "Invalid baud rate")
                return

            try:
                if self.port_in is None and self.port_in_var.get():
                    self.port_in = serial.Serial(self.port_in_var.get(), baudrate=baud_rate, timeout=0)

                if self.port_out1 is None and self.port_out1_var.get():
                    self.port_out1 = serial.Serial(self.port_out1_var.get(), baudrate=baud_rate, timeout=0)

                if self.port_out2 is None and self.port_out2_var.get():
                    self.port_out2 = serial.Serial(self.port_out2_var.get(), baudrate=baud_rate, timeout=0)

                self.open_button.config(text="CloseALL")
            except (ValueError, serial.SerialException, OSError) as ex:
                messagebox.showwarning("Warning", f"Could not open ports. {ex}")
                self.close_all_ports()
                return

        else:
            self.close_all_ports()
            self.open_button.config(text="OpenALL")

    def close_all_ports(self) -> None:
        for port in [self.port_in, self.port_out1, self.port_out2]:
            if port is not None:
                try:
                    if port.is_open:
                        port.close()
                except serial.SerialException:
                    pass

        self.port_in = None
        self.port_out1 = None
        self.port_out2 = None

    @staticmethod
    def bytes_to_hex(data: bytes) -> str:
        return " ".join(f"{byte:02X}" for byte in data) + (" " if data else "")

    def append_colored(self, widget: tk.Text, text: str, color_tag: str) -> None:
        widget.insert(tk.END, text, color_tag)
        widget.see(tk.END)

    def _forward_and_log(self, source, destination_a, destination_b, color_tag: str) -> None:
        if source is None or not source.is_open:
            return

        waiting = source.in_waiting
        if waiting <= 0:
            return

        data = source.read(waiting)
        if not data:
            return

        for destination in [destination_a, destination_b]:
            if destination is not None and destination.is_open:
                destination.write(data)

        decoded = data.decode("utf-8", errors="replace")
        self.append_colored(self.text_ascii, decoded, color_tag)
        self.append_colored(self.text_hex, self.bytes_to_hex(data), color_tag)

    def timer_read_tick(self) -> None:
        try:
            self._forward_and_log(self.port_in, self.port_out1, self.port_out2, "green")
            self._forward_and_log(self.port_out1, self.port_in, self.port_out2, "red")
            self._forward_and_log(self.port_out2, self.port_in, self.port_out1, "blue")
        except (serial.SerialException, OSError) as ex:
            messagebox.showwarning("Warning", f"Port I/O error. {ex}")
            self.close_all_ports()
            self.open_button.config(text="OpenALL")

        self.root.after(POLL_INTERVAL_MS, self.timer_read_tick)

    def on_close(self) -> None:
        self.close_all_ports()
        self.root.destroy()


def main() -> None:
    root = tk.Tk()
    Com2ComApp(root)
    root.mainloop()


if __name__ == "__main__":
    main()
