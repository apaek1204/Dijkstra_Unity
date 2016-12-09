Final Project for CSE30331
---------------------------

To open the program, the user can simply download the executable ?????? and open it.

The entire Unity project, the directory towerDefense, can also be downloaded to open and run the project in Unity.

Click on the different environment tiles to switch between grass, mountain, and tree (in increasing order of cost). The red panda uses the A* algorithm to dynamically change its path towards the apple.

A glitch happens when you click on the panda as it’s moving, or on the panda when it arrives on the apple. This will cause the panda to deviate from the ‘correct’ path, but it eventually calculates the path again.

To look for the C# script with A* and Dijkstra’s algorithm, go to ConsoleApplication2/ConsoleApplication2/Dijkstras.cs

The executable of Dijkstras.cs can be found in ConsoleApplication2/ConsoleApplication2/bin/Debug/ConsoleApplication2.exe

To see how the C# script with the algorithms connects with the user interface made in Unity, go to towerDefense/Assets/Dijkstras.cs

(The files may be named Dijkstras, but they include implementation of A*)

Benchmarking was done with Powershell on a Windows machine. These Powershell scripts can be found under the directory powershellscripts. We then compared the performance between A* and Dijkstra’s.

Memory usage, execution time, and correctness of result were all checked on a Windows machine.

Results from the benchmark:

| Algorithm  | Elapsed Time (ms) |
|------------|-------------------|
| Dijkstra's | 80                |
| A*         | 84                |


| Algorithm  | Memory usage (MB) |
|------------|-------------------|
| Dijkstra's | 12.322            |
| A*         | 12.322            |

Number of nodes visited:

| Algorithm  | Input0 | Input1 | Input2 | Input3 |
|------------|--------|--------|--------|--------|
| Dijkstra's | 16     | 32     | 9      | 101    |
| A*         | 16     | 32     | 9      | 101    |