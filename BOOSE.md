## ✏️ Drawing Commands

| Command     | Description                                      |
|-------------|--------------------------------------------------|
| `moveto x,y` | Moves the pen to coordinate (x, y).             |
| `pen r,g,b`  | Sets the pen color using RGB values (0–255).    |
| `circle r`   | Draws a circle with radius `r`.                 |
| `rect w,h`   | Draws a rectangle of width `w` and height `h`.  |
| `write x`    | Writes a value or string to the output.         |

### Example
```
moveto 100,150
pen 0,0,255
circle 150
rect 100,200
write hello
```

## 🔢 Variables
BOOSE supports integer (`int`) and real number (`real`) variables.

### Example
```
real pi = 3.14

int x
x = 200
```

## 🧮 Expressions
You can use arithmetic expressions (+, -, *, /) with both `int` and `real`.

### Example
```
real length = 10.0
real width = 20.5
real area = length * width
```

## 🧰 Arrays
Arrays can be declared and accessed using `poke` and `peek`.
- Set the value:
`poke <array> <index> = <value>`
- Read the value:
`peek <variable> = <array> <index>`

### Example
```
array int nums 10
poke nums 5 = 99
peek x = nums 5
```

## 🔁 Control Flow
### if, else
```
if condition
    // true block
else
    // false block
end if
```

### while
```
while condition
    // repeat block
end while
```

### for
```
for var = start to end step increment
    // loop block
end for
```

## 🧩 Methods
### Example
```
int radius = 30
pen 255,0,0
moveto 100,100
circle radius

method int area int r
    area = 3 * r * r
end method

call area radius
write area
```
