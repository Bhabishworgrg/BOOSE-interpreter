# BOOSE Interpreter

**BOOSE (Basic Object-Oriented Software Engineering)** is a small custom graphical language. This interpreter is an all-in-one solution to write and run BOOSE programs.

---

## Features

- **Write BOOSE Programs**  
  Use the built-in code editor to type or paste BOOSE scripts.

- **Run Code Instantly**  
  Click **Run** and your code will be interpreted and executed right away.

- **Visual Drawing Output**  
  Drawing commands like `moveto`, `drawto`, `circle`, and `rect` display their result in a visual output window.

- **Change Pen Colours**  
  Use the `pencolour` command to draw in red, green, blue, and more.

- **Use Loops and Logic**  
  Run BOOSE programs that include `for`, `while`, and `if` statements to create dynamic patterns.

- **Call Methods and Use Variables**  
  Use reusable code with method definitions and store data using integer, real, and array variables.

- **Error Feedback**  
  Syntax and runtime errors are shown clearly so you know what went wrong in your script.

## Prerequisites
- .NET 8.0 SDK

## Usage

> BOOSE Interpreter is currently only available for Windows (net8.0-windows).

1. Publish the project.
```bash
dotnet publish .\BOOSE-interpreter.csproj
```
2. Run the interpreter.
```bash
.\bin\Release\net8.0-windows\BOOSE-interpreter.exe
```

## Sample BOOSE Program

```
moveto 100,100
pencolour red
circle 50

for i = 1 to 5
    drawto i*10, i*20
endfor
```

> See more examples [here](examples).
> See BOOSE's documentation [here](BOOSE.md).

---

# License

This project is licensed under the GNU v3 License. See [LICENSE](LICENSE) for details.

# Get in Touch

[<img src="https://img.shields.io/badge/email-white?&style=for-the-badge&logo=gmail" alt="Email"/>](mailto:bhabishworgrg@gmail.com)
[<img src="https://img.shields.io/badge/linkedin-blue?&style=for-the-badge" alt="LinkedIn"/>](https://www.linkedin.com/in/bhabishwor-gurung/)
