# shell-upscaler
Windows utility to upscale files or folders right from the explorer.  
Acts as a GUI for [esrgan-launcher](https://github.com/ata4/esrgan-launcher).

# Prerequisites

- Functional ESRGAN installation
- At least one ESRGAN model in [ESRGAN PATH]/models/

# Installation

![](https://i.imgur.com/WrS4hoz.png)

- Copy/Move the executable to any location, e.g. Program Files
- Start it
- Click "Register" to enable Windows Explorer shell integration on images
- Enter the path to your ESRGAN installation (containing "test.py" and other files)
- Click "Install" to copy the required python scripts to your ESRGAN installation (4 tiny files, <30kb)

You should now have the option "Upscale with ESRGAN" in the context menu when clicking on an image (JPG, PNG, etc.)

# Important Notes

- The shell integration will stop working if the executable was moved elsewhere. In this case, set it up again ("Unregister" then "Register")
- There is no uninstaller, so in order to uninstall the program, use "Uninstall" and "Unregister" first

# Usage

![](https://i.imgur.com/wTZpd3x.pnghttps://i.imgur.com/wTZpd3x.png)

Right-click any image in the windows explorer (or any other program that will show the default context menu) and click on "Upscale with ESRGAN."

##### Options:

- Mode: Either upscale the selected image, or all images in the same directory
- ESRGAN Model: Select the model that ESRGAN will use
- Tile Size (HR): Width/Height of tiles processed at a time to avoid running out of VRAM.

The Tile Size option adapts to the output size, so you can use the same size for 1x or 8x models even though they have different memory usages.  

Example: 512px tile size at 8x will actually process 64px tiles, resulting in 512px output tiles.