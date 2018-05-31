# State Design Pattern by Example

![State Design Pattern - Game Character States](assets/header.png)

In object oriented programming State Pattern is one of the way to implement *Finite State Machines*. This pattern falls under *Behavioral Design Patterns*.

When in our software, object can transit between multiple possible states, and changes it's behaviour accoring to state, Then this type of problems can be easily solved using *[Finite State Machines](https://en.wikipedia.org/wiki/Finite-state_machine)*, and this pattern helps us to achive  this.

Here I'm taking example of **Super Mario** game, most of the people must already aware of ths nostalgic game. In this mario changes, its states and behaviour based on events occurred, which you can see in below image which I got from [Mario Wiki](https://www.mariowiki.com/Super_Mario_World)

![Super Mario States](assets/mario-finite-state-machine.jpg)

Let's observe states/behaviour and events in above image.

#### States
1. Mario (We will refer as Small Mario here after)
2. Super Mario
3. Fire Mario
4. Cape Mario
5. Lost Life (Apart from image considering this state)

#### Events
1. Got Mushroom 🍄
2. Got Fire Flower 🔥
3. Got Feather 🍃
4. Met Monster 👹 (Not shown in image, but you know Mario game. right?😉)

Below table demonstrates how state changes on diferent events

Current State | Event Occured | New State
---|---|---
Small Mario | Got Mushroom 🍄 | Super Mario
Small Mario | Got Fire Flower 🔥 | Fire Mario
Small Mario | Got Feather 🍃 | Cape Mario
Small Mario | Met Monster 👹 | Lost Life
Super Mario | Got Fire Flower 🔥 | Fire Mario
Super Mario | Got Feather 🍃 | Cape Mario
Super Mario | Met Monster 👹 | Small Mario
Fire Mario | Got Feather 🍃 | Cape Mario
Fire Mario | Met Monster 👹 | Small Mario
Cape Mario | Got Fire Flower 🔥 | Fire Mario
Cape Mario | Got Fire Flower 🔥 | Small Mario

Apart from state change, coins are also earned on occurrence of events