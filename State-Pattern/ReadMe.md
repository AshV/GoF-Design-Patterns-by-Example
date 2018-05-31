# State Design Pattern by Example

![State Design Pattern - Game Character States](assets/header.png)

In object oriented programming State Pattern is one of the way to implement *Finite State Machines*. This pattern falls under *Behavioral Design Patterns*.

When in our software, object can transit between multiple possible states, and changes it's behaviour accoring to state, Then this type of problems can be easily solved using *[Finite State Machines](https://en.wikipedia.org/wiki/Finite-state_machine)*, and this pattern helps us to achive  this.

Here I'm taking example of **Super Mario** game, most of the people must already aware of ths nostalgic game. In this mario changes, its states and behaviour based on events occurred, which you can see in below image which I got from [Mario Wiki](https://www.mariowiki.com/Super_Mario_World)

![Super Mario States](assets/mario-finite-state-machine.jpg)

We can see these states in image.

1. Mario (We will refer as Small Mario here after)
2. Super Mario
3. Fire Mario
4. Cape Mario

And posscible transition between states

Current State | Event Occured | New State
---|---|---
| 
Small Mario | Got Mushroom | Super Mario
Small Mario | Got Fire Flower | Fire Mario
Small Mario | Got Feather | Cape Mario
|
Super Mario | Got Fire Flower | Fire Mario
Super Mario | Got Feather | Cape Mario
|
Fire Mario | Got Feather | Cape Mario
|
Cape Mario | Got  | Fire Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
Mario | Got  | Mario
